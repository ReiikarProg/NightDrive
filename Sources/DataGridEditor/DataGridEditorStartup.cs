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

            this.DataGridView.Visible = false;
        }
    }
}
