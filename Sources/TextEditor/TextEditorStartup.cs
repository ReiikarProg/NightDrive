using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NightDrive.Enums;
using NightDrive.Helpers;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Called right after the Initialize designer method to populate data dynamically.
        /// </summary>
        private void InitializeTextEditor()
        {
            // RichBox default location & size
            this.RichTextBox.Size = new Size(760, 479);
            this.RichTextBox.Location = new Point(12, 57);
            this.RichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Enables the context menu on rich text box
            this.RichTextBox.EnableContextMenu();

            // Tool strip items
            this.ToolStripPoliceSize.Items.AddRange(new object[]
            {
                "6",
                "7",
                "8",
                "9",
                "10",
                "10,5",
                "11",
                "12",
                "13",
                "14",
                "16",
                "18"
            });

            this.ToolStripPoliceFamily.Items.AddRange(new object[]
            {
                "Microsoft Sans Serif",
                "Courier New",
                "Segoe UI",
                "Times New Roman",
                "Candara"
            });

            // Prevent the user to type itself in the combo box
            this.ToolStripPoliceFamily.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ToolStripPoliceSize.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ToolStripPoliceFamily.AllowDrop = true;
            this.ToolStripPoliceSize.AllowDrop = true;

            Logger.Log(LogLevel.Info, "Text editor init done");
        }
    }
}
