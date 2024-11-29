using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using NightDrive.Enums;
using NightDrive.Helpers;
using NightDrive.Helpers.Interface;
using NightDrive._Models;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// LastFileModel object.
        /// </summary>
        internal LastFileModel AppLastFile;

        /// <summary>
        /// SettingsModel object.
        /// </summary>
        internal SettingsModel AppSettings;

        /// <summary>
        /// FontEx object.
        /// </summary>
        internal FontEx AppFont;

        /// <summary>
        /// Current file object.
        /// </summary>
        private FileEx _currentFile = null;
        internal FileEx CurrentFile
        {
            get => this._currentFile;
            set
            {
                Logger.Log(LogLevel.Info, $"Current file changed (format: {value.Format})");

                // New current file set
                this._currentFile = value;
                this.UpdateHeader(); 
                this.UpdateFootNotes();
            }
        }

        /// <summary>
        /// Main form constructor.
        /// </summary>
        public MainForm()
        {
            // Clean existing log file if some 
            Logger.Init();

            // Init components from the designer & custom ones
            this.InitializeComponent();

            // Init component related to the text editor
            this.InitializeTextEditor(); 
            
            // Init component related to the image editor
            this.InitializeImageEditor();

            // CreateEmptyFile empty current file
            this.CurrentFile = FileEx.CreateEmptyFile(this, FileFormat.Text);

            this.AppFont = new FontEx();                               // New Font instance, using default values.
            this.AppLastFile = MainForm.LoadLastFileConfig();          // Read JSON file
            this.AppSettings = MainForm.LoadSettings();                // Read JSON files

            // Apply settingsModel and load last opened file
            this.ApplySettingsFromJson();
            this.PresetAppWithLastFile();

            Logger.Log(LogLevel.Info, "----- App Init done -----");
        }

        /// <summary>
        /// Read the json config file then return it.
        /// </summary>
        /// 
        /// <returns>default config object</returns>
        private static LastFileModel LoadLastFileConfig()
        {
            string path = Paths.AbsolutePath + Paths.LastFileConfigPath;

            Logger.Log(LogLevel.Info, $"Loading last file config from {path}");

            string jsonContents = File.ReadAllText(path);
            Logger.Log(LogLevel.Info, $"Retrieved config:\n{jsonContents}");

            LastFileModel conf = JsonConvert.DeserializeObject<LastFileModel>(jsonContents);

            return conf;
        }

        /// <summary>
        /// Save the last file properties into a json file.
        /// </summary>
        private void SaveLastFileConfig()
        {
            string configPath = Paths.AbsolutePath + Paths.LastFileConfigPath;

            // Should always be true
            if (File.Exists(configPath))
            {
                // Delete the old config path
                File.Delete(configPath);

                // Update the current before saving
                this.AppLastFile.LastFileName = this.CurrentFile.ShortName;
                this.AppLastFile.LastFileLocation = this.CurrentFile.Path;
                this.AppLastFile.LastFileFormat = this.CurrentFile.Format.ToString();
                this.AppLastFile.LastFileEncoding = this.CurrentFile.Encoding.ToString();

                // Serialize
                string jsonConfig = JsonConvert.SerializeObject(this.AppLastFile);

                // Edit and save the config file
                // Write data to the file
                using (var fileStream = new FileStream(configPath, FileMode.OpenOrCreate))
                {
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.Write(jsonConfig);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieve the last opened file by reading AppLastFile object.
        /// Places CurrentFile object, then display it
        /// Also set the AppFont object with respect to the newly opened document
        /// </summary>
        private void PresetAppWithLastFile()
        {
            // Default if nothing can be retrieved: an empty text file
            FileEx file = FileEx.CreateEmptyFile(this, FileFormat.Text);

            if (this.AppLastFile == null)
            {
                Logger.Log(LogLevel.Error, "Cannot recover last opened file as AppLastFile was null");
            }

            // Open last used file
            if (Enum.TryParse(this.AppLastFile.LastFileFormat, true, out FileFormat format) &&
                Enum.TryParse(this.AppLastFile.LastFileEncoding, true, out FileEncoding encoding))
            {
                Logger.Log(LogLevel.Info, $"Last opened file properties:  format -> {format}, encoding: {encoding}");

                switch (format)
                {
                    // Text file
                    case FileFormat.Text or FileFormat.RichText:
                        // Activate "text" format
                        this.ActivateFormat(FileFormat.Text);
                        break;
                    // Image file
                    case FileFormat.Image:
                        // Activate "image" format
                        this.ActivateFormat(FileFormat.Image);
                        break;

                    default:
                        throw new Exception($"Unknown last file format: {format}");
                }

                // Create the new file object
                file = FileEx.Create(this, this.AppLastFile.LastFileLocation, this.AppLastFile.LastFileName, format, encoding);
            }
            else
            {
                Logger.Log(LogLevel.Warning, "Failed to parse lastFileFormat from the json config");
            }

            // Set current file, then open it (hence writing in the RichBox)
            this.CurrentFile = file;
            this.CurrentFile.Open();

            // Set newly opened file length in the footnote
            this.FileLenghtLabel.Text = $"length: {this.RichTextBox.Text.Length}   lines: {this.RichTextBox.Lines.Length}";

            // Successfully restored text file 
            if (format is FileFormat.Text or FileFormat.RichText && this.RichTextBox.TextLength != 0)
            {
                Logger.Log(LogLevel.Info, $"Restoring last opened text file font...");

                this.RichTextBox.SelectionStart = this.RichTextBox.TextLength - 1;
                this.RichTextBox.Select();

                // Update current font object
                this.AppFont.Family = this.RichTextBox.SelectionFont.FontFamily.Name;
                this.AppFont.Size = this.RichTextBox.SelectionFont.Size;
                this.AppFont.Style = this.RichTextBox.SelectionFont.Style;
                this.AppFont.Alignment = this.RichTextBox.SelectionAlignment;

                Logger.Log(LogLevel.Info, $"Restored last opened text file, hence applying the given font properties -> " +
                                          $"family: {this.RichTextBox.SelectionFont.FontFamily}, " +
                                          $"size: {this.RichTextBox.SelectionFont.Size}, " +
                                          $"alignment: {this.RichTextBox.SelectionAlignment}");
            }
            else if (format is FileFormat.Image)
            {
                // Nothing to apply especially
            }
            else
            {
                Logger.Log(LogLevel.Warning, "Failed to restore last opened file, default font will be used");
            }
        }
     
    }
}
