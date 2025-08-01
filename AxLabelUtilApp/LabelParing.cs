using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1;
            dgv.Rows[dgv.Rows.Count - 1].Cells[0].Selected = true;   
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
                gridColumn.HeaderText = gridColumn.HeaderText.Replace("*", "");

                if (gridColumn.Index <= 1)
                {
                    continue;
                }
                gridColumn.ContextMenuStrip = this.ColumnContentOp;
            }

            dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1;
            dgv.Rows[dgv.Rows.Count - 1].Cells[1].Selected = true;


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
                if (col.Index <= 1)
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
            modifiedLabels = new List<KeyValuePair<string, string>>();

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
                //_________________________________________________
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
                if (col.Index == 0)
                {
                    continue;
                }
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow.IsNewRow)
            {
                return;
            }

            if (dgv.CurrentCell.ColumnIndex != 0)
            {
                return;
            }

            string labelId = dgv.CurrentRow.Cells[1].Value.ToString();
            //_________________________________________________
            Clipboard.SetText($"@{LabelIdSelected}:{labelId}");

          

        }

        private void dgv_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Bitmap resizedImage = ResizeImage(Properties.Resources.copy_ico, 24, 24);

                var w = resizedImage.Width;
                var h = resizedImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(resizedImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        public Bitmap ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // Crear nueva imagen con las dimensiones especificadas
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                // Configurar calidad de redimensionado
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                // Dibujar la imagen redimensionada
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        public Bitmap ResizeImageProportional(Image originalImage, int maxWidth, int maxHeight)
        {
            // Calcular nuevas dimensiones manteniendo proporción
            float ratioX = (float)maxWidth / originalImage.Width;
            float ratioY = (float)maxHeight / originalImage.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(originalImage.Width * ratio);
            int newHeight = (int)(originalImage.Height * ratio);

            return ResizeImage(originalImage, newWidth, newHeight);
        }
    }
}
