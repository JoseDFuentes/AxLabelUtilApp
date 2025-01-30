using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxLabelUtilApp
{
    public partial class ModelStoreSetting : Form
    {
        public ModelStoreSetting()
        {
            InitializeComponent();
        }

        private void ModelStoreSetting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.ModelStore;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ModelStore = textBox1.Text;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
