using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxLabelUtilApp
{
    public partial class LabelParing : Form
    {
        ModelHandler modelHandler = new ModelHandler();
        public LabelParing()
        {
            InitializeComponent();
        }

        private void LabelParing_Load(object sender, EventArgs e)
        {
         
            modelHandler.LoadModelList();

            modelHandler.fillModelList(ref cbModel);

            Utilities.setGridProperties(ref dgv);
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelHandler.ModelsLoaded)
            {
                modelHandler.fillLabelFile(ref cbLabelFiles, cbModel.SelectedValue.ToString());
            }
            
        }

        private void cARGARETIQUETASToolStripMenuItem_Click(object sender, EventArgs e)
        {

            loadLabelFiles(cbLabelFiles.SelectedValue.ToString());
        }

        private void loadLabelFiles(string labelId)
        {
            Labels labels = new Labels();

            LabelFile labelFile = modelHandler.LabelInfo.FirstOrDefault(l => l.ID == labelId);

            labelFile.labelFiles.ForEach(l =>
            {
                string labelTxt = Path.Combine(Properties.Settings.Default.ModelStore, l.RelativeUriInModelStore);
                string language = l.Language == null ? "en-US" : l.Language;

                labels.loadFile(labelTxt, language);
            });

            
            dgv.DataSource = labels.labelsLanguage();
            dgv.Columns[0].Frozen = true;



        }
    }
}
