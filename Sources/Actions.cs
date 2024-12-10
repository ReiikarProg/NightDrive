using System.Drawing;
using NightDrive.Enums;
using NightDrive._Helpers;
using System.Windows.Forms;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Save current file, if possible
        /// </summary>
        /// <param name="saveAs">If true, just save at the current location, otherwise prompt the user to choose the path</param>
        private void Save(bool saveAs = true)
        {
            if (this.CurrentFile == null)
            {
                Logger.Log(LogLevel.Error, $"Current file is null, nothing to save...");
            }
            else
            {
                // Check the current file format
                
                bool shouldSave = true;

                // If no path exist or Filename equals "nouveau", force the "save as"
                if (this.CurrentFile.Name.Equals("nouveau") || string.IsNullOrWhiteSpace(this.CurrentFile.Path))
                {
                    Logger.Log(LogLevel.Info, "Forcing new file to be \"saved as\"");
                    saveAs = true;
                }

                // Let the user choose a path to save
                if (saveAs)
                {
                    this.SaveFileDialogBox.FileName = this.CurrentFile.Name;

                    // Get a saving location
                    if (this.SaveFileDialogBox.ShowDialog() == DialogResult.OK)
                    {
                        // Update current file (e.g location & name)
                        this.CurrentFile = FileEx.Create(this, this.SaveFileDialogBox.FileName);
                    }
                    else  // Operation cancelled, do not save
                    {
                        shouldSave = false;
                    }
                }

                if (shouldSave)
                {
                    Logger.Log(LogLevel.Info, $"Saving file at {this.CurrentFile.AbsolutePath}");

                    // Do the real saving
                    this.CurrentFile.Save();
                    this.UpdateHeader();
                }
                // Else, operation got canceled
            }
        }

        /// <summary>
        /// Select a file from the file explorer then display it.
        /// </summary>
        private void Open()
        {
            // Successfully retrieved a file
            if (this.OpenFileDialogBox.ShowDialog() == DialogResult.OK)
            {
                string filename = this.OpenFileDialogBox.FileName;

                Logger.Log(LogLevel.Info, $"Opening file located at \"{filename}\" ...");

                // Opening text file
                if (filename.EndsWith(".txt") || filename.EndsWith(".rtf"))
                {
                    this.ActivateFormat(FileFormat.Text);
                    // Update current file
                    this.CurrentFile = FileEx.Create(this, this.OpenFileDialogBox.FileName);

                    // Open the file
                    this.CurrentFile.Open();
                }
                else if (filename.EndsWith(".jpg"))
                {
                    // Activate the format 
                    this.ActivateFormat(FileFormat.Image);

                    // Update current file
                    this.CurrentFile = FileEx.Create(this, this.OpenFileDialogBox.FileName);

                    // Open the file
                    this.CurrentFile.Open();
                }
                else if (filename.EndsWith(".png"))
                {
                    // TODO: support JPG files
                    Logger.Log(LogLevel.Info, "PNG files are not supported yet");
                }
                else if (filename.EndsWith(".dgv"))
                {
                    Logger.Log(LogLevel.Info, "Trying to open dgv files");

                    // Activate the format
                    this.ActivateFormat(FileFormat.Grid);

                    // Update current file
                    this.CurrentFile = FileEx.Create(this, this.OpenFileDialogBox.FileName);

                    // Open the file
                    this.CurrentFile.Open();
                }
                else
                {
                    Logger.Log(LogLevel.Warning, "Unknown file extension, cancel the opening");
                }
            }
            // Else, operation cancelled
        }

        /// <summary>
        /// CreateEmptyFile a new empty file .
        /// </summary>
        private void New()
        {
            // Prompt the user in case the current file isn't saved yet
            if (!this.CurrentFile.IsSaved)
            {
                Logger.Log(LogLevel.Warning, $"Current file ({this.CurrentFile.Name}) is not saved, informing the user");

                DialogResult result = CustomDialogBox.ShowMessage(
                    $"Le document {this.CurrentFile.Name} n'est pas enregistré, voulez-vous le faire maintenant ?\n" +
                    $"(attention, si vous cliquez sur \"Non\", toutes vos données non enregistrées seront perdues).",
                    CustomBoxIcon.Info,
                    CustomBoxButton.YesOrNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        this.Save(saveAs: false);
                        break;
                    case DialogResult.No:
                        Logger.Log(LogLevel.Warning, $"The user refused to save the file before creating a new one");
                        break;
                }
            }

            // Prompt the user to select the new file format: 
            FileFormat format = CustomDialogBox.ShowTextFormatSelector();

            Logger.Log(LogLevel.Info, $"Creating a new file (format: {format})");

            // Process depending on the user's selection
            switch (format)
            {
                case FileFormat.Cancel:
                    // The user canceled the creation.
                    break;

                case FileFormat.Text:
                    this.ActivateFormat(FileFormat.Text);

                    // Create a new text file, then erase the content of the rich text box
                    this.CurrentFile = FileEx.Create(this, "", "nouveau", FileFormat.Text, FileEncoding.Utf8, false);
                    
                    // Erase the existing text
                    this.RichTextBox.Text = string.Empty;
                    break;

                case FileFormat.Image:
                    this.ActivateFormat(FileFormat.Image);

                    // Create a new image file, then erase the content of the image box
                    this.CurrentFile = FileEx.Create(this, "", "nouveau", FileFormat.Image, FileEncoding.None, false);

                    // Re-init image editor components
                    this.InitializeImageEditor();
                    break;

                case FileFormat.Grid:

                    // Activate the format
                    this.ActivateFormat(FileFormat.Grid);

                    // Create new grid view file
                    this.CurrentFile = FileEx.Create(this,"", "nouveau", FileFormat.Grid, FileEncoding.None, false);

                    // Set back data grid view 
                    this.InitializeDataGridEditor();

                    break;
            }

        }
    }
}
