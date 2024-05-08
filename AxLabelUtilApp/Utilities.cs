using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxLabelUtilApp
{
    class Utilities
    {
        public static void setGridProperties(ref DataGridView _dgv)
        {

            Color formColor = new Color();
            formColor = Color.FromArgb(66, 72, 78);
            _dgv.BackgroundColor = formColor;


            _dgv.DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.Black, ForeColor = Color.White, Font = new Font(new FontFamily("Calibri"), 20) };
            _dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.DarkGray, ForeColor = Color.Black };
            _dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle() { BackColor = formColor, ForeColor = Color.Lavender };
            _dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            _dgv.RowHeadersVisible = false;
            _dgv.MultiSelect = true;
            _dgv.AllowUserToOrderColumns = false;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _dgv.AllowUserToOrderColumns = false;
       

        }



    }
}
