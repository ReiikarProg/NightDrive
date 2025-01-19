using NightDrive.Enums;
using NightDrive._Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Called to warn the user that some file is unsaved before closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormOnClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !this.CurrentFile.IsSaved)
            {
                DialogResult result = CustomDialogBox.ShowMessage(
                    $"Le document {this.CurrentFile.Name} n'est pas enregistré, voulez-vous le faire maintenant ?",
                    CustomBoxIcon.Info,
                    CustomBoxButton.YesOrNoOrCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        this.Save(saveAs: false);
                        this.SaveLastFileConfig();
                        this.SaveSettings();
                        break;
                    case DialogResult.No:
                        // nothing to do as the file isn't saved, do not update the config
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            else  // Still save the config
            {
                this.SaveLastFileConfig();
                this.SaveSettings();
            }
        }

        /// <summary>
        /// As the text changed, mark the current file as unsaved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichTextBoxOnTextChanged(object sender, EventArgs e)
        {
            if (this.CurrentFile is { IsSaved: true })
            {
                this.CurrentFile.IsSaved = false;
                this.UpdateHeader();
            }

            // Update file length in the footnotes
            this.FileLenghtLabel.Text = $"length: {this.RichTextBox.Text.Length} lines: {this.RichTextBox.Lines.Length}";
        }

        /// <summary>
        /// As the text selection changed, update checked tool buttons about the FontStyle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichTextBoxOnSelectionChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.RichTextBox.Text))
            {
                FontStyle currentFontStyle = this.RichTextBox.SelectionFont?.Style ?? FontStyle.Regular;
                HorizontalAlignment currentAlignment = this.RichTextBox.SelectionAlignment;

                /*
                Logger.Log(LogLevel.Info, $"Selection changed. " +
                                          $"length {this.RichTextBox.SelectionLength}, " +
                                          $"style: {currentFontStyle}, " +
                                          $"alignment: {this.RichTextBox.SelectionAlignment}");
                */

                // Check only what's needed about font style
                this.ToolStripBold.Checked = currentFontStyle.HasFlag(FontStyle.Bold);
                this.ToolStripUnderline.Checked = currentFontStyle.HasFlag(FontStyle.Underline);
                this.ToolStripItalic.Checked = currentFontStyle.HasFlag(FontStyle.Italic);

                // Check only the applied alignment (only once at a time)
                this.ToolStripLeftAlign.Checked = currentAlignment == HorizontalAlignment.Left;
                this.ToolStripCenterAlign.Checked = currentAlignment == HorizontalAlignment.Center;
                this.ToolStripRightAlign.Checked = currentAlignment == HorizontalAlignment.Right;

                // Get the char right before the selection
                int charBeforeSelectionPosition = this.RichTextBox.SelectionStart != 0 ? this.RichTextBox.SelectionStart - 1 : 0;
                char charBeforeSelection = this.RichTextBox.Text[charBeforeSelectionPosition];

                // Continue only if the first char of the text isn't selected
                if (charBeforeSelectionPosition != 0)
                {
                    // Current text selection is not empty, or it is, but the char right before is not
                    if (this.RichTextBox.SelectionLength != 0 ||
                        this.RichTextBox.SelectionLength == 0 && charBeforeSelection != ' ')
                    {
                        // The char before current selection is not empty or a whitespace
                        if (!string.IsNullOrWhiteSpace(charBeforeSelection.ToString()))
                        {
                            this.AppFont.Size = this.RichTextBox.SelectionFont?.Size ?? 10;
                            this.AppFont.Family = this.RichTextBox.SelectionFont?.FontFamily.Name ?? "Times New Roman";
                            this.ToolStripPoliceFamily.Text = this.RichTextBox.SelectionFont?.FontFamily.Name ?? "Times New Roman";
                            this.ToolStripPoliceSize.Text = this.RichTextBox.SelectionFont?.Size.ToString() ?? "10";
                        } 
                        // Else, selection changed but the char right before the selection is null or empty
                    }
                    // Else, selection changed, but nothing is indeed selected 
                }
                // Else, first char select
            }
            // Else, do nothing on empty text
        }
    }
}
