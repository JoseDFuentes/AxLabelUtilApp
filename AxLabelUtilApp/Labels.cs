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
        public Dictionary<string, string> LangTranslate { get; set; }
        public Dictionary<string, Dictionary<string, string>> dictoLabels { get; set; }

        public List<string> languages = new List<string>();

        DataTable ret;
        public Labels()
        {
            dictoLabels = new Dictionary<string, Dictionary<string, string>>();
        }
        private void addLabel(string _labeldId, string _translation, string _language)
        {
            Dictionary<string, string> dictoLanguages = new Dictionary<string, string>();

            if (!languages.Contains(_language)) languages.Add(_language);

            if (!dictoLabels.ContainsKey(_labeldId))
            {
                dictoLanguages.Add(_language, _translation);
                dictoLabels.Add(_labeldId, dictoLanguages);
                return;
            }

            dictoLanguages = dictoLabels[_labeldId];

            if (!dictoLanguages.ContainsKey(_language))
            {
                dictoLanguages.Add(_language, _translation);
                dictoLabels[_labeldId] = dictoLanguages;
            }

        }

        public void loadFile(string _filename, string _language)
        {

            StreamReader reader = new StreamReader(_filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (!line.Contains("=")) continue;

                string[] splited = line.Split('=');

                if (splited.Length >= 2)
                {
                    this.addLabel(splited[0], splited[1], _language);
                }

            }

            reader.Close();

        }

        public DataTable labelsLanguage()
        {
            ret = new DataTable();

            ret.Columns.Add("LabelId");
            languages.ForEach(l => ret.Columns.Add(l));

            foreach (KeyValuePair<string, Dictionary<string, string>> item in dictoLabels)
            {
                DataRow row = ret.NewRow();

                row["LabelId"] = item.Key;

                foreach (KeyValuePair<string, string> translation in item.Value)
                {
                    row[translation.Key] = translation.Value;
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
                streamWriter.WriteLine($"{row.Cells["LabelId"].Value.ToString()}={row.Cells[_language].Value.ToString()}");
            }
            streamWriter.Close();

            if (File.Exists(_filePath))
            {
                MessageBox.Show($"Archivo {_filePath} escrito");
            }


        }


    }
}
