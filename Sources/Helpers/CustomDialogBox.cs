using System;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using NightDrive.Enums;

namespace NightDrive.Helpers
{
    public class CustomDialogBox : Form
    {
        private Label _label = new ();
        private ComboBox _comboBox = new ();
        private Button _validationButton;
        private Panel _panel;
        private Button _cancelButton;
        private static FileFormat _formatChoice = FileFormat.Unknown;

        private static FileFormat FormatChoice
        {
            get => _formatChoice;
            set
            {
                Logger.Log(LogLevel.Info, $"CustomDialogBox file format changed");
                _formatChoice = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="comboBoxItem"></param>
        public CustomDialogBox(string message, object[] comboBoxItem)
        {
            this.InitializeComponent();
            this._label.Text = message;
            this._comboBox.Items.AddRange(comboBoxItem);
        }
        
        /// <summary>
        /// Show a custom box to the user to select the format of the new created file.
        /// </summary>
        /// <returns></returns>
        public static FileFormat ShowTextFormatSelector()
        {
            string message = $"Merci de séléctionner le format de fichier que vous souhaitez créer ci-dessous, puis cliquez sur \"Ok\"";
            object[] comboBoxItem = new [] { "Text", "Image" };

            using (var form = new CustomDialogBox(message, comboBoxItem))
            {
                form.ShowDialog();
            }

            return FormatChoice;
        }
        /// <summary>
        /// Show a custom message to the user.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DialogResult ShowMessage(string message, CustomBoxIcon level, CustomBoxButton buttons)
        {
            string caption = Assembly.GetEntryAssembly()?.GetName().Name;

            var boxButtons = buttons switch
            {
                CustomBoxButton.YesOrNo => MessageBoxButtons.YesNo,
                CustomBoxButton.YesOrNoOrCancel => MessageBoxButtons.YesNoCancel,
                CustomBoxButton.Ok => MessageBoxButtons.OK,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };

            var icon = level switch
            {
                CustomBoxIcon.Info => MessageBoxIcon.Information,
                CustomBoxIcon.Warning => MessageBoxIcon.Warning,
                CustomBoxIcon.Error => MessageBoxIcon.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };

            return MessageBox.Show(message, caption, boxButtons, icon);
        }

        #region Events
        /// <summary>
        /// Click the "Ok" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidationButtonOnClick(object sender, EventArgs e)
        {
            // Tells the user to make a choice
            if (this._comboBox.Text is not ("Text" or "Image"))
            {
                Logger.Log(LogLevel.Info, $"Combo box text: {this._comboBox.Text}");
                this._label.Text = "Merci de selection un format de fichier avant de valider !";
            }
            else  // Set the chosen format w.r.t the user selection, then exit
            {
                if (Enum.TryParse(this._comboBox.Text, out FileFormat format))
                {
                    FormatChoice = format;
                    this.Close();
                }
                else
                {
                    Logger.Log(LogLevel.Info, $"Failed to parse {this._comboBox.Text} into FileFormat");
                }
            }
        }

        /// <summary>
        /// Click on the "Annuler" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonOnClick(object sender, EventArgs e)
        {
            // Mark the operation as canceled, then close.
            FormatChoice = FileFormat.Cancel;
            this.Close();
        }

        /// <summary>
        /// // Forces the focus on the Validation button when the user select something on the ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            this._validationButton.Focus();
        }

        /// <summary>
        /// Return a FileFormat.Cancel in case the user ask for a Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDialogBoxOnFormClosing(object sender, FormClosingEventArgs e)
        {
            // FormatChoice = FileFormat.Cancel;
        }
        #endregion

        private void InitializeComponent()
        {
            this._label = new System.Windows.Forms.Label();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this._validationButton = new System.Windows.Forms.Button();
            this._panel = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._label.Location = new System.Drawing.Point(13, 9);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(206, 55);
            this._label.TabIndex = 0;
            // 
            // _comboBox
            // 
            this._comboBox.AllowDrop = true;
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._comboBox.FormattingEnabled = true;
            this._comboBox.Location = new System.Drawing.Point(23, 9);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(86, 21);
            this._comboBox.TabIndex = 1;
            this._comboBox.TabStop = false;
            this._comboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOnSelectedIndexChanged);
            // 
            // _validationButton
            // 
            this._validationButton.BackColor = System.Drawing.Color.White;
            this._validationButton.Location = new System.Drawing.Point(115, 9);
            this._validationButton.Name = "_validationButton";
            this._validationButton.Size = new System.Drawing.Size(57, 21);
            this._validationButton.TabIndex = 2;
            this._validationButton.TabStop = false;
            this._validationButton.Text = "Ok";
            this._validationButton.UseVisualStyleBackColor = false;
            this._validationButton.Click += new System.EventHandler(this.ValidationButtonOnClick);
            // 
            // _panel
            // 
            this._panel.BackColor = System.Drawing.Color.LightGray;
            this._panel.Controls.Add(this._cancelButton);
            this._panel.Controls.Add(this._comboBox);
            this._panel.Controls.Add(this._validationButton);
            this._panel.Location = new System.Drawing.Point(-11, 67);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(250, 51);
            this._panel.TabIndex = 3;
            // 
            // _cancelButton
            // 
            this._cancelButton.BackColor = System.Drawing.Color.White;
            this._cancelButton.Location = new System.Drawing.Point(178, 9);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(57, 21);
            this._cancelButton.TabIndex = 3;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "Annuler";
            this._cancelButton.UseVisualStyleBackColor = false;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonOnClick);
            // 
            // CustomDialogBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(230, 107);
            this.Controls.Add(this._label);
            this.Controls.Add(this._panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomDialogBox";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NightDrive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomDialogBoxOnFormClosing);
            this._panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
