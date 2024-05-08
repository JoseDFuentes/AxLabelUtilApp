using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AxLabelUtilApp
{
    public class ModelHandler
    {

        private List<ModelFile> modelFiles = new List<ModelFile>();
        List<LabelFile> labelInfo = new List<LabelFile>();


        public List<ModelFile> ModelFiles { get => modelFiles; set => modelFiles = value; }
        public List<LabelFile> LabelInfo { get => labelInfo; set => labelInfo = value; }
        public bool ModelsLoaded { get; set; }


        public ModelHandler()
        {
            ModelsLoaded = false;
        }

        private string GetModelStore()
        {
            return Properties.Settings.Default.ModelStore;
        }

        public void LoadModelList()
        {
            
            string modelStore = GetModelStore();

            if (modelStore == string.Empty)
            {
                return;
            }

            DirectoryInfo dinfo = new DirectoryInfo(modelStore);

            dinfo.GetDirectories().ToList().ForEach(d =>
            {
                string descriptorPath = Path.Combine(d.FullName, "Descriptor");

                if (Directory.Exists(descriptorPath))
                {
                    new DirectoryInfo(descriptorPath).GetFiles("*.xml").ToList().ForEach(f =>
                    {
                        AxModelInfo modelInfo = this.getModelInfo(f.FullName);

                        if (modelInfo != null)
                        {
                            if (modelInfo.Customization != "DoNotAllow")
                            {

                                modelFiles.Add(new ModelFile()
                                {
                                    Name = modelInfo.Name,
                                    DisplayName = modelInfo.DisplayName,
                                    Path = Path.Combine(d.FullName, Path.GetFileName(f.FullName).Replace(".xml", "")),
                                    ModelInfo = modelInfo
                                });

                            }

                        }


                    });
                }
            });
            ModelsLoaded = true;
        }

        private AxModelInfo getModelInfo(string path)
        {
            AxModelInfo ret = new AxModelInfo();

            XmlSerializer serializer = new XmlSerializer(typeof(AxModelInfo));

            try
            {
                ret = (AxModelInfo)serializer.Deserialize(XmlReader.Create(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return ret;
        }

        private AxLabelFile getLabelInfo(string path)
        {
            AxLabelFile ret = new AxLabelFile();

            XmlSerializer serializer = new XmlSerializer(typeof(AxLabelFile));
            try
            {
                ret = (AxLabelFile)serializer.Deserialize(XmlReader.Create(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        public void fillModelList(ref ComboBox comboBox)
        {
            Dictionary<string, string> dictoModels = new Dictionary<string, string>();

            modelFiles.ForEach(m => dictoModels.Add(m.Name, m.DisplayName));

            comboBox.DataSource = new BindingSource(dictoModels, null);

            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";


        }


        public void fillLabelFile(ref ComboBox comboBox, string modelName)
        {
            ModelFile modelInfo = modelFiles.FirstOrDefault(m => m.Name == modelName);
            LabelInfo.Clear();

            if (modelInfo == null)
            {
                return;
            }

            string labelFilePath = Path.Combine(modelInfo.Path, "AxLabelFile");

            DirectoryInfo labelFileInfo = new DirectoryInfo(labelFilePath);

            labelFileInfo.GetFiles("*.xml").ToList().ForEach(m =>
            {
                AxLabelFile labelFile = this.getLabelInfo(m.FullName);

                if (labelFile != null)
                {
                    var linfo = labelInfo.FirstOrDefault(l => l.ID == labelFile.LabelFileId);

                    if (linfo != null)
                    {
                        linfo.labelFiles.Add(labelFile);
                    }
                    else
                    {
                        List<AxLabelFile> listLabel = new List<AxLabelFile>();

                        listLabel.Add(labelFile);

                        labelInfo.Add(new LabelFile(){ 
                            ID = labelFile.LabelFileId, 
                            labelFiles = listLabel 
                        });
                    }


                }

            });

            Dictionary<string, string> dictoLabels = new Dictionary<string, string>();

            labelInfo.ForEach(m => dictoLabels.Add(m.ID, m.ID));
            

            comboBox.DataSource = new BindingSource(dictoLabels, null);

            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";


        }



    }
}
