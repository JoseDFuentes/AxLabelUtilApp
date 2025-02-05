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
        string LabelIdSelected = string.Empty;
        string modelSelected = string.Empty;

        List<KeyValuePair<string, string>> modifiedLabels = new List<KeyValuePair<string, string>>();

        DataView labelsView;

        bool changesNotSaved = false;

        Dictionary<string, string> columnClipboard = new Dictionary<string, string>();
        public LabelParing()
        {
            InitializeComponent();
        }

        Labels labels;

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

            LabelIdSelected = cbLabelFiles.SelectedValue.ToString();
            modelSelected = cbModel.Text.ToString();

            if (LabelIdSelected == "NoFiles")
            {
                string msgFiles = "No label files were found in selected model";
                MessageBox.Show(msgFiles, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (changesNotSaved)
            {
                string msg = "If a language file is loaded the unsaved changes going to be lost. Do you want to continue?";

                if (MessageBox.Show(msg,"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                changesNotSaved = false;
            }

            checkSaveButton(changesNotSaved);

            lblWorkingOn.Text = $"Selected model: {modelSelected} LabelId: {LabelIdSelected}";

            loadLabelFiles(LabelIdSelected);
        }

        private void loadLabelFiles(string labelId)
        {
            labels = new Labels();

            LabelFile labelFile = modelHandler.LabelInfo.FirstOrDefault(l => l.ID == labelId);

            labelFile.labelFiles.ForEach(l =>
            {
                string labelTxt = Path.Combine(Properties.Settings.Default.ModelStore, l.RelativeUriInModelStore);
                string language = l.Language == null ? "en-US" : l.Language;

                labels.loadFile(labelTxt, language);
            });

            labelsView = new DataView();
            labelsView.Table = labels.labelsLanguage();

            dgv.DataSource = labelsView;
            dgv.Columns[0].Frozen = true;

            foreach (DataGridViewColumn gridColumn in dgv.Columns)
            {
                gridColumn.ContextMenuStrip = gridColumn.Index == 0 ? this.firstColumnContextMenu : this.ColumnContentOp;

            }



        }



        private void ColumnContentOp_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            ContextMenuStrip contextMenu = (ContextMenuStrip)clickedItem.Owner;
            DataGridView dataGridView = (DataGridView)contextMenu.SourceControl;

            Point mousePosition = dataGridView.PointToClient(Control.MousePosition);
            DataGridView.HitTestInfo hitTestInfo = dataGridView.HitTest(mousePosition.X, mousePosition.Y);
            if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
            {
                int columnIndex = hitTestInfo.ColumnIndex;
                DataGridViewColumn column = dataGridView.Columns[columnIndex];
                processContextMenuAction(column.Index, e.ClickedItem.Name);
            }

        }

        private void processContextMenuAction(int languageColumn, string itemOption)
        {

            switch(itemOption)
            {
                case "CopyMenuContent": this.CopyColumn(languageColumn);  break;
                case "PasteColumn": this.PasteColumnProcess(languageColumn, onlyMissing: false); break;
                case "PasteOnlyMissing": this.PasteColumnProcess(languageColumn); break;
                //case "CopyLabelIDMenu": Clipboard.SetText($"{cbLabelFiles.SelectedValue}:{}")
            }

        }

        private void CopyColumn(int languageColumn)
        {
            if (languageColumn == 0)
            {
                MessageBox.Show("The option is not available for the column", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            columnClipboard = new Dictionary<string, string>();

            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                columnClipboard.Add(row.Cells["LabelId"].Value.ToString(), row.Cells[languageColumn].Value.ToString());
            }

        }

        private void PasteColumnProcess(int languageColumn, bool onlyMissing = true)
        {
            if (languageColumn == 0)
            {
                MessageBox.Show("The option is not available for the column", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {

                if (row.IsNewRow)
                {
                    continue;
                }

                if (row.Cells[languageColumn].Value.ToString() != string.Empty && onlyMissing)
                {
                    continue;
                }
                string labelId = row.Cells["LabelId"].Value.ToString();
                row.Cells[languageColumn].Value = columnClipboard.FirstOrDefault(c => c.Key == labelId).Value;
                setCellAsChanged(row.Index, languageColumn);

            }
        }

        private void CopyMenuContent_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         

        }

        private void cbLabelFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sAVECHANGESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveChanges();
        }

        private void saveChanges()
        {
            txtBusqueda.Text = string.Empty;
            string msg = "The action will overwrite the languages marked as modified and cannot be undone. Do you want to continue?";

            if (MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            txtBusqueda.Text = string.Empty;

            LabelFile labelFile = modelHandler.LabelInfo.FirstOrDefault(l => l.ID == cbLabelFiles.SelectedValue);

            foreach (DataGridViewColumn col in dgv.Columns)
            {

                if (!col.HeaderText.Contains("*"))
                {
                    continue;
                }
                if (col.Index == 0)
                {
                    continue;
                }

                AxLabelFile l = labelFile.labelFiles.FirstOrDefault(x => x.Language == col.Name);

                string filePath = Path.Combine(Properties.Settings.Default.ModelStore,  l.RelativeUriInModelStore);

                labels.writeFile(filePath, col.Name, dgv);
            }

            changesNotSaved = false;
            checkSaveButton(changesNotSaved);
            loadLabelFiles(LabelIdSelected);

        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.setCellAsChanged(e.RowIndex, e.ColumnIndex);

            string labelModified = dgv.Rows[e.RowIndex].Cells["LabelId"].Value.ToString();

            if (!modifiedLabels.Exists(l => l.Key == labelModified && l.Value == dgv.Columns[e.ColumnIndex].Name))
            {
                modifiedLabels.Add(new KeyValuePair<string, string>(labelModified, dgv.Columns[e.ColumnIndex].Name));
            }

        }


        private void setCellAsChanged(int RowIndex, int ColumnIndex)
        {
            dgv.Rows[RowIndex].Cells[ColumnIndex].Style.BackColor = Color.FromArgb(241, 207, 207);
            changesNotSaved = true;
            checkSaveButton(changesNotSaved);
            if (!dgv.Columns[ColumnIndex].HeaderText.Contains("*"))
            {
                dgv.Columns[ColumnIndex].HeaderText += "*";
            }
        }

        private void checkSaveButton(bool _changesNotSaved)
        {
            sAVECHANGESToolStripMenuItem.Enabled = _changesNotSaved;
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void mODELSTORESETTINGSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ModelStoreSetting().ShowDialog();
        }

        private void firstColumnContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            ContextMenuStrip contextMenu = (ContextMenuStrip)clickedItem.Owner;
            DataGridView dataGridView = (DataGridView)contextMenu.SourceControl;

            Point mousePosition = dataGridView.PointToClient(Control.MousePosition);
            DataGridView.HitTestInfo hitTestInfo = dataGridView.HitTest(mousePosition.X, mousePosition.Y);
            if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
            {
                int columnIndex = hitTestInfo.ColumnIndex;
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewColumn column = dataGridView.Columns[columnIndex];
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                processFirstContextMenuAction(column.Index, row.Index, e.ClickedItem.Name);
            }
        }

        private void processFirstContextMenuAction(int columnIndex, int rowIndex, string clickedItem)
        {
            if (clickedItem == "copyLabelId")
            {
                string labelId = dgv.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                Clipboard.SetText($"@{LabelIdSelected}:{labelId}");

            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            filterText(txtBusqueda.Text);
        }

        private void filterText(string text)
        {
            string filter = string.Empty;
            
           
            foreach(DataGridViewColumn col in dgv.Columns)
            {
                filter += $" [{col.Name}] LIKE '%{text}%' OR"; 
            }

            filter += "#";
            filter = filter.Replace("OR#", "");

            labelsView.RowFilter = filter;

            changeRowFormating();


        }

        private void changeRowFormating()
        {

            if (modifiedLabels.Count == 0)
            {
                return;
            }

            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (modifiedLabels.Exists(l => l.Key == row.Cells["LabelId"].Value.ToString() && l.Value == column.Name))
                    {
                        setCellAsChanged(row.Index, column.Index);
                    }
                }
            }

        }

    }
}
