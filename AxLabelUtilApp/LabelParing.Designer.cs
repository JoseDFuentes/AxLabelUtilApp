namespace AxLabelUtilApp
{
    partial class LabelParing
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelParing));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cARGARETIQUETASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVECHANGESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mODELSTORESETTINGSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLabelFiles = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblWorkingOn = new System.Windows.Forms.Label();
            this.ColumnContentOp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyMenuContent = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteOnlyMissing = new System.Windows.Forms.ToolStripMenuItem();
            this.firstColumnContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLabelId = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ColumnContentOp.SuspendLayout();
            this.firstColumnContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cARGARETIQUETASToolStripMenuItem,
            this.sAVECHANGESToolStripMenuItem,
            this.mODELSTORESETTINGSToolStripMenuItem,
            this.aBOUTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cARGARETIQUETASToolStripMenuItem
            // 
            this.cARGARETIQUETASToolStripMenuItem.Name = "cARGARETIQUETASToolStripMenuItem";
            this.cARGARETIQUETASToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cARGARETIQUETASToolStripMenuItem.Text = "LOAD LANGUAGE FILE";
            this.cARGARETIQUETASToolStripMenuItem.Click += new System.EventHandler(this.cARGARETIQUETASToolStripMenuItem_Click);
            // 
            // sAVECHANGESToolStripMenuItem
            // 
            this.sAVECHANGESToolStripMenuItem.Name = "sAVECHANGESToolStripMenuItem";
            this.sAVECHANGESToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.sAVECHANGESToolStripMenuItem.Text = "SAVE CHANGES";
            this.sAVECHANGESToolStripMenuItem.Click += new System.EventHandler(this.sAVECHANGESToolStripMenuItem_Click);
            // 
            // mODELSTORESETTINGSToolStripMenuItem
            // 
            this.mODELSTORESETTINGSToolStripMenuItem.Name = "mODELSTORESETTINGSToolStripMenuItem";
            this.mODELSTORESETTINGSToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mODELSTORESETTINGSToolStripMenuItem.Text = "MODEL STORE SETTING";
            this.mODELSTORESETTINGSToolStripMenuItem.Click += new System.EventHandler(this.mODELSTORESETTINGSToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            this.aBOUTToolStripMenuItem.Click += new System.EventHandler(this.aBOUTToolStripMenuItem_Click);
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbModel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(121, 6);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(335, 31);
            this.cbModel.TabIndex = 1;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "MODEL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "LABEL ID";
            // 
            // cbLabelFiles
            // 
            this.cbLabelFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLabelFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLabelFiles.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLabelFiles.FormattingEnabled = true;
            this.cbLabelFiles.Location = new System.Drawing.Point(121, 57);
            this.cbLabelFiles.Name = "cbLabelFiles";
            this.cbLabelFiles.Size = new System.Drawing.Size(335, 31);
            this.cbLabelFiles.TabIndex = 3;
            this.cbLabelFiles.SelectedIndexChanged += new System.EventHandler(this.cbLabelFiles_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.Size = new System.Drawing.Size(843, 240);
            this.dgv.TabIndex = 5;
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 240);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBusqueda);
            this.panel2.Controls.Add(this.lblWorkingOn);
            this.panel2.Controls.Add(this.cbModel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbLabelFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 197);
            this.panel2.TabIndex = 7;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(3, 161);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(622, 30);
            this.txtBusqueda.TabIndex = 6;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // lblWorkingOn
            // 
            this.lblWorkingOn.AutoSize = true;
            this.lblWorkingOn.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingOn.Location = new System.Drawing.Point(9, 117);
            this.lblWorkingOn.Name = "lblWorkingOn";
            this.lblWorkingOn.Size = new System.Drawing.Size(19, 23);
            this.lblWorkingOn.TabIndex = 5;
            this.lblWorkingOn.Text = "_";
            // 
            // ColumnContentOp
            // 
            this.ColumnContentOp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyMenuContent,
            this.PasteColumn,
            this.PasteOnlyMissing});
            this.ColumnContentOp.Name = "ColumnContentOp";
            this.ColumnContentOp.Size = new System.Drawing.Size(206, 70);
            this.ColumnContentOp.Text = "Copiar columna";
            this.ColumnContentOp.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ColumnContentOp_ItemClicked);
            // 
            // CopyMenuContent
            // 
            this.CopyMenuContent.Name = "CopyMenuContent";
            this.CopyMenuContent.Size = new System.Drawing.Size(205, 22);
            this.CopyMenuContent.Text = "Copy column";
            this.CopyMenuContent.Click += new System.EventHandler(this.CopyMenuContent_Click);
            // 
            // PasteColumn
            // 
            this.PasteColumn.Name = "PasteColumn";
            this.PasteColumn.Size = new System.Drawing.Size(205, 22);
            this.PasteColumn.Text = "Paste column";
            // 
            // PasteOnlyMissing
            // 
            this.PasteOnlyMissing.Name = "PasteOnlyMissing";
            this.PasteOnlyMissing.Size = new System.Drawing.Size(205, 22);
            this.PasteOnlyMissing.Text = "Paste only missing labels";
            // 
            // firstColumnContextMenu
            // 
            this.firstColumnContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLabelId});
            this.firstColumnContextMenu.Name = "ColumnContentOp";
            this.firstColumnContextMenu.Size = new System.Drawing.Size(144, 26);
            this.firstColumnContextMenu.Text = "Copiar columna";
            this.firstColumnContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.firstColumnContextMenu_ItemClicked);
            // 
            // copyLabelId
            // 
            this.copyLabelId.Name = "copyLabelId";
            this.copyLabelId.Size = new System.Drawing.Size(143, 22);
            this.copyLabelId.Text = "Copy LabelId";
            // 
            // LabelParing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LabelParing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model label utility";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LabelParing_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ColumnContentOp.ResumeLayout(false);
            this.firstColumnContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLabelFiles;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem cARGARETIQUETASToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ColumnContentOp;
        private System.Windows.Forms.ToolStripMenuItem CopyMenuContent;
        private System.Windows.Forms.ToolStripMenuItem PasteColumn;
        private System.Windows.Forms.ToolStripMenuItem PasteOnlyMissing;
        private System.Windows.Forms.ToolStripMenuItem sAVECHANGESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mODELSTORESETTINGSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip firstColumnContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyLabelId;
        private System.Windows.Forms.Label lblWorkingOn;
        private System.Windows.Forms.TextBox txtBusqueda;
    }
}

