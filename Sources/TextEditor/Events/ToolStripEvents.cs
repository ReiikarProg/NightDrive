using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using NightDrive.Enums;
using NightDrive._Helpers;

namespace NightDrive
{
    public partial class MainForm 
    {
        private void ToolStripMenuOnClick(object sender, EventArgs e)
        {

        }

        private void ToolStripOpenOnClick(object sender, EventArgs e)
        {
            this.Open();
        }

        private void ToolStripNewOnClick(object sender, EventArgs e)
        {
            this.New();
        }

        private void ToolStripSaveOnClick(object sender, EventArgs e)
        {
            this.Save(false);
        }

        private void ToolStripSaveAs_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void ToolStripEraseOClick(object sender, EventArgs e)
        {

        }

        private void ToolStripParametersOnClick(object sender, EventArgs e)
        {

        }

        private void ToolStripPreviousOnClick(object sender, EventArgs e)
        {
            this.RichTextBox.Undo();
        }

        private void ToolStripNextOnClick(object sender, EventArgs e)
        {
            this.RichTextBox.Redo();
        }

        private void ToolStripUnderlineOnClick(object sender, EventArgs e)
        {
            this.ApplyFontStyle(FontStyle.Underline);
        }

        private void ToolStripItalicOnClick(object sender, EventArgs e)
        {
           this.ApplyFontStyle(FontStyle.Italic);
        }

        private void ToolStripBoldOnClick(object sender, EventArgs e)
        {
            this.ApplyFontStyle(FontStyle.Bold);
        }

        private void ToolStripLeftAlignOnClick(object sender, EventArgs e)
        {
            this.ApplyTextAlignment(HorizontalAlignment.Left);
        }

        private void ToolStripCenterOnClick(object sender, EventArgs e)
        {
            this.ApplyTextAlignment(HorizontalAlignment.Center);
        }

        private void ToolStripRightAlignOnClick(object sender, EventArgs e)
        {
            this.ApplyTextAlignment(HorizontalAlignment.Right);
        }

        /// <summary>
        /// Give focus back on Rich Text Box when police family combo box selection changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripPoliceFamilyOnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Give rich text box focus back
            Logger.Log(LogLevel.Info, "Select index changed on Police family combo box, apply new police family");
            this.ApplyFontFamily(this.ToolStripPoliceFamily.Text ?? this.AppFont.Family);
            this.RichTextBox.Focus();
        }

        /// <summary>
        /// Give focus back on Rich Text Box when police size combo box selection changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripPoliceSizeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Give rich text box focus back
            Logger.Log(LogLevel.Info, "Select index changed on Police size combo box, apply new font size");

            if (float.TryParse(this.ToolStripPoliceSize.Text, NumberStyles.Float, null, out float size))
            {
                this.ApplyFontSize(size);
            }
            else
            {
                Logger.Log(LogLevel.Warning, $"Failed to parse police size into float number (value:{size})");
            }
            this.RichTextBox.Focus();
        }

        /// <summary>
        /// The user wants to change text color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripColorOnClick(object sender, EventArgs e)
        {
            Logger.Log(LogLevel.Info, "Changing text color");
            
            using (ColorDialog cd = new ColorDialog())
            {
                cd.ShowDialog();
                
                // If something is selected, change the color of this and only this
                if (!string.IsNullOrWhiteSpace(this.RichTextBox.SelectedText))
                {
                    this.RichTextBox.SelectionColor = cd.Color;
                }
                else // Set the whole color
                {
                    this.RichTextBox.ForeColor = cd.Color;
                }
            }
        }
    }
}
