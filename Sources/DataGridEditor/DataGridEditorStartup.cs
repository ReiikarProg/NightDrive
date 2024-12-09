using System.Drawing;
using System.Windows.Forms;

namespace NightDrive
{
    public partial class MainForm
    {
        /// <summary>
        /// Init all components related to the data grid view editor.
        /// </summary>
        public void InitializeDataGridEditor()
        {
            // RichBox default location & size
            this.DataGridView.Size = new Size(760, 479);
            this.DataGridView.Location = new Point(12, 57); 
            this.DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // this.DataGridView.Visible = true;

            // Make every column not sortable
            foreach (DataGridViewColumn c in DataGridView.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Selected = false;
            }
            // Switch selection mode to full column
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            // Force the selection on the first column
            // this.DataGridView.Columns[0].Selected = true;
        }
    }
}
