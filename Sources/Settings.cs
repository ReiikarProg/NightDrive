using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using NightDrive.Enums;
using NightDrive.Helpers;
using NightDrive._Models;
using NightDrive.Helpers.Interface;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        #region Default theme settings
        // MainForm
        public static Color DefaultMainFormBackColor = Color.White;
        public static Color DefaultMainFormForeColor = Color.Black;

        // MenuStrip
        public static Color DefaultMenuStripBackColor = Color.White;
        public static Color DefaultMenuStripForeColor = Color.Black;

        // ToolStrip
        public static Color DefaultToolStripBackColor = Color.White;
        public static Color DefaultToolStripForeColor = Color.Black;

        // RichTextBox
        public static Color DefaultRichTextBoxForeColor = Color.Black;
        public static Color DefaultRichTextBoxBackColor = Color.White;
        public static Cursor DefaultRichTextBoxIBeamCursor = Cursors.IBeam;
        #endregion

        #region Dark theme settings
        // MainForm
        public static Color DarkMainFormBackColor = MainForm.GetGrayColorVariantFromInt(45);
        public static Color DarkMainFormForeColor = Color.White;

        // MenuStrip
        public static Color DarkMenuStripBackColor = MainForm.GetGrayColorVariantFromInt(45);
        public static Color DarkMenuStripForeColor = Color.White;

        // ToolStrip
        public static Color DarkToolStripBackColor = MainForm.GetGrayColorVariantFromInt(45);
        public static Color DarkToolStripForeColor = Color.White;

        // RichTextBox
        public static Color DarkRichTextBoxForeColor = Color.White;
        public static Color DarkRichTextBoxBackColor = MainForm.GetGrayColorVariantFromInt(75);
        public static Cursor DarkRichTextBoxIBeamCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.black_select));
        #endregion

        #region Override methods
        /// <summary>
        /// Override to prevent flickering when clicking on ComboBox.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;      // WS_EX_COMPOSITED
                return handleParam;
            }
        }
        #endregion 

        /// <summary>
        /// Occurs when the window is resized by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, EventArgs e)
        {
            // Update textbox size to keep the same initial ratio
            this.RichTextBox.Width = this.Width - 40;
            this.RichTextBox.Height = this.Height - 121;

            // Same with the picture box
            this.PictureBox.Width = this.Width - 40 - 87 /* Button panel size */;
            this.PictureBox.Height = this.Height - 121;

            // Panel location
            // this.PicturePanel.Location = new Point()
        }

        /// <summary>
        /// Set visible/invisible component depending on the passed format.
        /// </summary>
        /// <param name="format"></param>
        private void ActivateFormat(FileFormat format)
        {
            Logger.Log(LogLevel.Info, $"Activating format: {format}");

            if (format is FileFormat.Text /* Text or RichText are considered the same */)
            {
                this.RichTextBox.Visible = true;

                this.PictureBox.Visible = false;
                this.PicturePanel.Visible = false;
            }
            else if (format == FileFormat.Image)
            {
                this.RichTextBox.Visible = false;

                this.PictureBox.Visible = true; 
                this.PicturePanel.Visible = true;
            }
            else
            {
                Logger.Log(LogLevel.Error, $"Invalid format in \"ActivateFormat\" method: {format}");
            }
        }

        /// <summary>
        /// Get a Gray variant from ARGB value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color GetGrayColorVariantFromInt(int value)
        {
            return Color.FromArgb(value, value, value);
        }

        /// <summary>
        /// Read save settingsModel of the app.
        /// </summary>
        /// 
        /// <returns>default settingsModel object</returns>
        private static SettingsModel LoadSettings()
        {
            string path = Paths.AbsolutePath + Paths.SettingsPath;

            Logger.Log(LogLevel.Info, $"Loading app settingsModel from {path}");

            string jsonContents = File.ReadAllText(path);
            Logger.Log(LogLevel.Info, $"Loaded settingsModel from saved json file:\n{jsonContents}");
            
            SettingsModel settingsModel;
            try
            {
                settingsModel = JsonConvert.DeserializeObject<SettingsModel>(jsonContents);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Exception, $"Settings parsing failure: {ex.Message}");
                settingsModel = new SettingsModel()
                {
                    ThemeColor = Theme.Default
                };
            }

            return settingsModel;
        }

        /// <summary>
        /// Save currently applied settingsModel into a json file.
        /// </summary>
        private void SaveSettings()
        {
            string configPath = Paths.AbsolutePath + Paths.SettingsPath;

            // Should always be true
            if (File.Exists(configPath))
            {
                // Delete the old config path
                File.Delete(configPath);

                // Serialize the current settings object
                string jsonConfig = JsonConvert.SerializeObject(this.AppSettings);

                // Edit and save the config file
                using (var fileStream = new FileStream(configPath, FileMode.OpenOrCreate))
                {
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.Write(jsonConfig);
                    }
                }
            }

            Logger.Log(LogLevel.Info, $"Settings saved");
        }

        /// <summary>
        /// Called at the start of the app, applying setting from the saved json file.
        /// </summary>
        private void ApplySettingsFromJson()
        {
            // Apply the theme from the config
            this.ApplyTheme(this.AppSettings.ThemeColor);
        }

        /// <summary>
        /// Apply the given theme to the application by updating components.
        /// </summary>
        /// <param name="theme"></param>
        private void ApplyTheme(Theme theme)
        {
            Logger.Log(LogLevel.Info, $"Applying theme \"{theme.ToString()}\" to the application");

            switch (theme)
            {
                case Theme.Dark:
                    this.BackColor = MainForm.DarkMainFormBackColor;
                    this.ForeColor = MainForm.DarkMainFormForeColor;

                    // Main menu strip and all sub menus
                    this.MainMenuStrip.BackColor = MainForm.DarkMenuStripBackColor;
                    this.MainMenuStrip.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.NewMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.OpenMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.SaveMenutem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.SaveAsMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.ExitMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.DefaultThemeMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.DarkThemeMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.Utf8MenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.AsciiMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.UnicodeMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.ShowLogsMenuItem.ForeColor = MainForm.DarkMenuStripForeColor;

                    // Tool strip and all sub menus + images
                    this.MainToolStrip.BackColor = MainForm.DarkToolStripBackColor;
                    this.MainToolStrip.ForeColor = MainForm.DarkToolStripForeColor;
                    this.ToolStripMenu.Image = Properties.Resources.MenuDark;
                    this.ToolStripNew.Image = Properties.Resources.NewDark;
                    this.ToolStripOpen.Image = Properties.Resources.OpenDark;
                    this.ToolStripErase.Image = Properties.Resources.EraseDark;
                    this.ToolStripParameters.Image = Properties.Resources.OptionsDark;
                    this.ToolStripPrevious.Image = Properties.Resources.PreviousDark;
                    this.ToolStripNext.Image = Properties.Resources.NextDark;
                    this.ToolStripSave.Image = Properties.Resources.SaveDark;
                    this.ToolStripSaveAs.Image = Properties.Resources.SaveAsDark;
                    this.ToolStripBold.Image = Properties.Resources.BoldDark;
                    this.ToolStripItalic.Image = Properties.Resources.ItalicDark;
                    this.ToolStripUnderline.Image = Properties.Resources.UnderlineDark;
                    this.ToolStripLeftAlign.Image = Properties.Resources.AlignLeftDark;
                    this.ToolStripCenterAlign.Image = Properties.Resources.AlignCenterDark;
                    this.ToolStripRightAlign.Image = Properties.Resources.AlignRightDark;

                    this.ToolStripPoliceFamily.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.ToolStripPoliceFamily.BackColor = MainForm.GetGrayColorVariantFromInt(100);

                    this.ToolStripPoliceSize.ForeColor = MainForm.DarkMenuStripForeColor;
                    this.ToolStripPoliceSize.BackColor = MainForm.GetGrayColorVariantFromInt(100);

                    this.RichTextBox.ForeColor = MainForm.DarkRichTextBoxForeColor;
                    this.RichTextBox.BackColor = MainForm.DarkRichTextBoxBackColor;
                    this.RichTextBox.Cursor = MainForm.DarkRichTextBoxIBeamCursor;

                    // Apply customized dark renderers
                    this.MainToolStrip.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable());
                    this.MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable());
                    break;

                case Theme.Default:
                default:
                    this.BackColor = MainForm.DefaultMainFormBackColor;
                    this.ForeColor = MainForm.DefaultMainFormForeColor;

                    // Main menu strip and all sub menus
                    this.MainMenuStrip.BackColor = MainForm.DefaultMenuStripBackColor;
                    this.MainMenuStrip.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.NewMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.OpenMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.SaveMenutem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.SaveAsMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.ExitMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.DefaultThemeMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.DarkThemeMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.Utf8MenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.AsciiMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.UnicodeMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.ShowLogsMenuItem.ForeColor = MainForm.DefaultMenuStripForeColor;

                    // Tool strip and all sub menus + images
                    this.MainToolStrip.BackColor = MainForm.DefaultToolStripBackColor;
                    this.MainToolStrip.ForeColor = MainForm.DefaultToolStripForeColor;
                    this.ToolStripMenu.Image = Properties.Resources.Menu;
                    this.ToolStripNew.Image = Properties.Resources.New;
                    this.ToolStripOpen.Image = Properties.Resources.Open;
                    this.ToolStripErase.Image = Properties.Resources.Erase;
                    this.ToolStripParameters.Image = Properties.Resources.Options;
                    this.ToolStripPrevious.Image = Properties.Resources.Previous;
                    this.ToolStripNext.Image = Properties.Resources.Next;
                    this.ToolStripSave.Image = Properties.Resources.Save;
                    this.ToolStripSaveAs.Image = Properties.Resources.SaveAs;
                    this.ToolStripBold.Image = Properties.Resources.Bold;
                    this.ToolStripItalic.Image = Properties.Resources.Italic;
                    this.ToolStripUnderline.Image = Properties.Resources.Underline;
                    this.ToolStripLeftAlign.Image = Properties.Resources.AlignLeft;
                    this.ToolStripCenterAlign.Image = Properties.Resources.AlignCenter;
                    this.ToolStripRightAlign.Image = Properties.Resources.AlignRight;

                    this.ToolStripPoliceFamily.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.ToolStripPoliceFamily.BackColor = MainForm.GetGrayColorVariantFromInt(245);

                    this.ToolStripPoliceSize.ForeColor = MainForm.DefaultMenuStripForeColor;
                    this.ToolStripPoliceSize.BackColor = MainForm.GetGrayColorVariantFromInt(245);

                    this.RichTextBox.ForeColor = MainForm.DefaultRichTextBoxForeColor;
                    this.RichTextBox.BackColor = MainForm.DefaultRichTextBoxBackColor;
                    this.RichTextBox.Cursor = MainForm.DefaultRichTextBoxIBeamCursor;

                    // Set back default renderers
                    this.MainToolStrip.Renderer = new ToolStripProfessionalRenderer(new LightColorTable());
                    this.MainMenuStrip.Renderer = new ToolStripProfessionalRenderer(new LightColorTable());
                    break;
            }

            // Update the current settings object
            this.AppSettings.ThemeColor = theme;
        }

        /// <summary>
        /// Apply a given encoding to the RichTextBox text
        /// </summary>
        /// <param name="newEncoding"></param>
        private void ApplyEncoding(Encoding newEncoding)
        {
            Encoding oldEncoding = Tools.GetEncodingFromEnumFileEncoding(this.CurrentFile.Encoding);

            // Do nothing for the same Encoding
            if (oldEncoding.Equals(newEncoding))
            {
                Logger.Log(LogLevel.Info, $"Trying to convert into {newEncoding}, but the file already uses it !");
            }
            else  // Convert from old to new encoding
            {
                byte[] oldArray = oldEncoding.GetBytes(this.RichTextBox.Text);
                byte[] newArray = Encoding.Convert(oldEncoding, newEncoding, oldArray);

                // Update the text
                this.RichTextBox.Text = newEncoding.GetString(newArray);
                // Set the currently used encoding
                this.CurrentFile.Encoding = Tools.GetFileEncodingEnumFromEncoding(newEncoding);
                this.UpdateFootNotes();

                Logger.Log(LogLevel.Info, $"Encoding changed: {oldEncoding} => {newEncoding}");
            }
        }

        /// <summary>
        /// Apply a given font style to the rich textbox selected text.
        /// </summary>
        /// <param name="style"></param>
        private void ApplyFontStyle(FontStyle style)
        {
            Logger.Log(LogLevel.Info, $"Applying font style: {style}");

            // Add the style if not there yet for the whole selection, or remove it
            switch (style)
            {
                case FontStyle.Bold:
                    this.RichTextBox.SelectionFont = this.RichTextBox.SelectionFont.Bold ? new Font(this.AppFont.Family, this.AppFont.Size, this.RichTextBox.SelectionFont.Style & ~style) :
                        new Font(this.AppFont.Family, this.AppFont.Size, this.RichTextBox.SelectionFont.Style | style);
                    break;

                case FontStyle.Italic:
                    this.RichTextBox.SelectionFont = this.RichTextBox.SelectionFont.Italic ? new Font(this.AppFont.Family, this.AppFont.Size, this.RichTextBox.SelectionFont.Style & ~style) :
                          new Font(this.AppFont.Family, this.AppFont.Size, this.RichTextBox.SelectionFont.Style | style);
                    break;

                case FontStyle.Underline:
                    this.RichTextBox.SelectionFont = this.RichTextBox.SelectionFont.Underline ? new Font(this.AppFont.Family, this.AppFont.Size, this.RichTextBox.SelectionFont.Style & ~style) :
                        new Font(this.AppFont.Family, this.AppFont.Size, this.RichTextBox.SelectionFont.Style | style);
                    break;
            }

            Logger.Log(LogLevel.Info,
                $"FontStyle after application: {this.RichTextBox.SelectionFont.Style}");
            
            // If switched to .rtf, update headers and footnotes
            if (this.CurrentFile.SwitchToRtfCheck())
            {
                Logger.Log(LogLevel.Info, "Current file switched to .rtf, updating headers");
                this.UpdateHeader();
                this.UpdateFootNotes();
            }
            // Else, nothing to update
        }

        /// <summary>
        /// Read the value from ToolStripPoliceFamily, then apply it to the RichBox current selection.
        /// </summary>
        /// <param name="familyName"></param>
        private void ApplyFontFamily(string familyName)
        {
            Logger.Log(LogLevel.Info, $"Trying to apply font family: {familyName}");

            // Update FontEx object
            this.AppFont.Family = familyName;

            // Get the updated Font
            this.RichTextBox.SelectionFont = this.AppFont.GetGlobalFont();

            // If switched to .rtf, update headers and footnotes
            if (this.CurrentFile.SwitchToRtfCheck())
            {
                Logger.Log(LogLevel.Info, "Current file switched to .rtf, updating headers");
                this.UpdateHeader();
                this.UpdateFootNotes();
            }
            // Else, nothing to update
        }

        /// <summary>
        /// Read the value from ToolStripPoliceSize, then apply it to the RichBox current selection.
        /// </summary>
        /// <param name="fontSize"></param>
        private void ApplyFontSize(float fontSize)
        {
            Logger.Log(LogLevel.Info, $"Applying font size: {fontSize}");

            // Update FontEx object
            this.AppFont.Size = fontSize;

            // Get the updated Font
            this.RichTextBox.SelectionFont = this.AppFont.GetGlobalFont();

            // If switched to .rtf, update headers and footnotes
            if (this.CurrentFile.SwitchToRtfCheck())
            {
                Logger.Log(LogLevel.Info, "Current file switched to .rtf, updating headers");
                this.UpdateHeader();
                this.UpdateFootNotes();
            }
            // Else, nothing to update
        }

        /// <summary>
        /// Apply the passed alignment to the current rich text box selected text or insert location.
        /// </summary>
        /// <param name="alignment"></param>
        private void ApplyTextAlignment(HorizontalAlignment alignment)
        {
            // We clicked on an already check alignment button, which is not that smart...
            if (alignment == this.RichTextBox.SelectionAlignment)
            {
                Logger.Log(LogLevel.Info, $"Tyring to apply alignment: {alignment}, but this one is already applied, juste get back to default \"left aligned\" value");
                this.AppFont.Alignment = HorizontalAlignment.Left;
                this.RichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                // Force to re-check the "left align" button
                this.ToolStripLeftAlign.Checked = true;
            }
            else
            {
                Logger.Log(LogLevel.Info, $"Applying alignment: {alignment}, while current one is: {this.AppFont.Alignment}");

                // Update FontEx object by setting the new value
                this.AppFont.Alignment = alignment;

                // Apply it to the current selection
                this.RichTextBox.SelectionAlignment = alignment;

                // Now, uncheck boxes that should be (only one alignment should be checked at a time)
                switch (alignment)
                {
                    // Left is auto checked
                    case HorizontalAlignment.Left:
                        this.ToolStripRightAlign.Checked = false;
                        this.ToolStripCenterAlign.Checked = false;
                        break;

                    // Center is auto checked
                    case HorizontalAlignment.Center:
                        this.ToolStripRightAlign.Checked = false;
                        this.ToolStripLeftAlign.Checked = false;
                        break;

                    // Right is auto checked
                    case HorizontalAlignment.Right:
                        this.ToolStripLeftAlign.Checked = false;
                        this.ToolStripCenterAlign.Checked = false;
                        break;

                    default:
                        Logger.Log(LogLevel.Error, $"Unknown horizontal alignment value: {alignment}");
                        break;
                }

            }

            // If switched to .rtf, update headers and footnotes
            if (this.CurrentFile.SwitchToRtfCheck())
            {
                Logger.Log(LogLevel.Info, "Current file switched to .rtf, updating headers");
                this.UpdateHeader();
                this.UpdateFootNotes();
            }
            // Else, nothing to update
        }
    }
}
