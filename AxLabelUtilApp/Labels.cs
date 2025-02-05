using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxLabelUtilApp
{
    class Labels
    {
        public List<EntryLabel> LangTranslate { get; set; }
        public Dictionary<string, List<EntryLabel>> dictoLabels { get; set; }

        

        public List<string> languages = new List<string>();

        DataTable ret;
        public Labels()
        {
            dictoLabels = new Dictionary<string, List<EntryLabel>>();
        }
        private void addLabel(string _language, string _labeldId, string _translation, string _comment)
        {
             List<EntryLabel> dictoLanguages = new List<EntryLabel>();

            if (!languages.Contains(_language)) languages.Add(_language);

            EntryLabel entryLabel = new EntryLabel()
            {
                Language = _language,
                Translation = _translation,
                Comment = _comment

            };


            if (!dictoLabels.ContainsKey(_labeldId))
            {
               

                dictoLanguages.Add(entryLabel);
                dictoLabels.Add(_labeldId, dictoLanguages);
                return;
            }

            dictoLanguages = dictoLabels[_labeldId];

            if (!dictoLanguages.Exists(l => l.Language == _language))
            {
                dictoLanguages.Add(entryLabel);
                dictoLabels[_labeldId] = dictoLanguages;
            }

        }

        public void loadFile(string _filename, string _language)
        {

            if (!File.Exists(_filename))
            {
                MessageBox.Show($"The file '{_filename}' does not exist","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idlabel = string.Empty, transla = string.Empty, comment = string.Empty;

            StreamReader reader = new StreamReader(_filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line.Contains("="))
                {
                    if (idlabel != string.Empty)
                    {
                        this.addLabel(_language, idlabel, transla, comment);
                    }

                    string[] splited = line.Split('=');
                    if (splited.Length == 2)
                    {
                        idlabel = splited[0];
                        transla = splited[1];
                        comment = string.Empty;
                    }
                }

                if (line.Contains(";"))
                {
                    comment = line.TrimStart().TrimStart(';');
                }
               

            }

            if (idlabel != string.Empty)
            {
                this.addLabel(_language, idlabel, transla, comment);
            }

            reader.Close();

        }

        public DataTable labelsLanguage()
        {
            ret = new DataTable();
            ret.TableName = "data";
            ret.Columns.Add("LabelId");
            languages.ForEach(l => ret.Columns.Add(l));

            foreach (KeyValuePair<string, List<EntryLabel>> item in dictoLabels)
            {
                DataRow row = ret.NewRow();

                row["LabelId"] = item.Key;

                foreach (EntryLabel translation in item.Value)
                {
                    row[translation.Language] = translation.Translation;
                }

                ret.Rows.Add(row);

            }

            return ret;
        }

        public void writeFile(string _filePath, string _language, DataGridView gridView)
        {
            StreamWriter streamWriter = new StreamWriter(_filePath);

            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Cells[0].Value  == null)
                {
                    continue;
                }
                if (row.Cells[0].Value.ToString() == string.Empty)
                {
                    continue;
                }

                streamWriter.WriteLine($"{row.Cells["LabelId"].Value.ToString()}={row.Cells[_language].Value.ToString()}");

                if (dictoLabels.ContainsKey(row.Cells["LabelId"].Value.ToString()))
                {
                    var ListLang = dictoLabels[row.Cells["LabelId"].Value.ToString()];
                    var lbl = ListLang.Find(l => l.Language == _language);

                    if (lbl != null)
                    {
                        if (lbl.Comment != string.Empty)
                        {
                            streamWriter.WriteLine($" ;{lbl.Comment}");
                        }
                    }
                }



                //streamWriter.WriteLine($"{row.Cells["LabelId"].Value.ToString()}={value2write}");
            }
            streamWriter.Close();

            if (File.Exists(_filePath))
            {
                MessageBox.Show($"The file '{Path.GetFileName(_filePath)}' has been saved");
            }


        }


    }

    public class EntryLabel
    {
        public string Language { get; set; }
        public string Translation { get; set; }
        public string Comment { get; set; }
    }


}
