using System.Windows.Forms;

namespace NightDrive
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenutem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncodingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Utf8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AsciiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnicodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLogsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolStripMenu = new System.Windows.Forms.ToolStripButton();
            this.ToolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.ToolStripNew = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSave = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSaveAs = new System.Windows.Forms.ToolStripButton();
            this.ToolStripPrevious = new System.Windows.Forms.ToolStripButton();
            this.ToolStripNext = new System.Windows.Forms.ToolStripButton();
            this.ToolStripErase = new System.Windows.Forms.ToolStripButton();
            this.ToolStripParameters = new System.Windows.Forms.ToolStripButton();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripBold = new System.Windows.Forms.ToolStripButton();
            this.ToolStripItalic = new System.Windows.Forms.ToolStripButton();
            this.ToolStripUnderline = new System.Windows.Forms.ToolStripButton();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLeftAlign = new System.Windows.Forms.ToolStripButton();
            this.ToolStripCenterAlign = new System.Windows.Forms.ToolStripButton();
            this.ToolStripRightAlign = new System.Windows.Forms.ToolStripButton();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripPoliceFamily = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripPoliceSize = new System.Windows.Forms.ToolStripComboBox();
            this.OpenFileDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialogBox = new System.Windows.Forms.SaveFileDialog();
            this.FontDialogBox = new System.Windows.Forms.FontDialog();
            this.FileFormatLabel = new System.Windows.Forms.Label();
            this.FileLenghtLabel = new System.Windows.Forms.Label();
            this.FileEncodingLabel = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.PicturePanel = new System.Windows.Forms.Panel();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.ZoomButton = new System.Windows.Forms.Button();
            this.ZoomLabel = new System.Windows.Forms.Label();
            this.ZoomUpDown = new System.Windows.Forms.NumericUpDown();
            this.EraserButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.PencilButton = new System.Windows.Forms.Button();
            this.MainMenuStrip.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.PicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.Color.White;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.editionToolStripMenuItem,
            this.quitterToolStripMenuItem,
            this.affichageToolStripMenuItem,
            this.ThemeMenuItem,
            this.EncodingMenuItem,
            this.aideToolStripMenuItem,
            this.aideToolStripMenuItem1});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.SaveMenutem,
            this.SaveAsMenuItem,
            this.Separator1,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(54, 20);
            this.FileMenuItem.Text = "Fichier";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenuItem.Size = new System.Drawing.Size(216, 22);
            this.NewMenuItem.Text = "Nouveau";
            this.NewMenuItem.Click += new System.EventHandler(this.NewFileOnClick);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(216, 22);
            this.OpenMenuItem.Text = "Ouvrir";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenFileOnClick);
            // 
            // SaveMenutem
            // 
            this.SaveMenutem.Name = "SaveMenutem";
            this.SaveMenutem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenutem.Size = new System.Drawing.Size(216, 22);
            this.SaveMenutem.Text = "Enregistrer";
            this.SaveMenutem.Click += new System.EventHandler(this.SaveFileOnClick);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsMenuItem.Size = new System.Drawing.Size(216, 22);
            this.SaveAsMenuItem.Text = "Enregistre sous";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItemOnClick);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(213, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.ExitMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ExitMenuItem.Text = "Quitter";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItemOnClick);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.quitterToolStripMenuItem.Text = "Recherche";
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "Affichage";
            // 
            // ThemeMenuItem
            // 
            this.ThemeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefaultThemeMenuItem,
            this.DarkThemeMenuItem});
            this.ThemeMenuItem.Name = "ThemeMenuItem";
            this.ThemeMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ThemeMenuItem.Text = "Thème";
            // 
            // DefaultThemeMenuItem
            // 
            this.DefaultThemeMenuItem.Name = "DefaultThemeMenuItem";
            this.DefaultThemeMenuItem.Size = new System.Drawing.Size(128, 22);
            this.DefaultThemeMenuItem.Text = "Par défaut";
            this.DefaultThemeMenuItem.Click += new System.EventHandler(this.DefaultThemeMenuItemOnClick);
            // 
            // DarkThemeMenuItem
            // 
            this.DarkThemeMenuItem.Name = "DarkThemeMenuItem";
            this.DarkThemeMenuItem.Size = new System.Drawing.Size(128, 22);
            this.DarkThemeMenuItem.Text = "Sombre";
            this.DarkThemeMenuItem.Click += new System.EventHandler(this.DarkThemeMenuItemOnClick);
            // 
            // EncodingMenuItem
            // 
            this.EncodingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Utf8MenuItem,
            this.AsciiMenuItem,
            this.UnicodeMenuItem});
            this.EncodingMenuItem.Name = "EncodingMenuItem";
            this.EncodingMenuItem.Size = new System.Drawing.Size(71, 20);
            this.EncodingMenuItem.Text = "Encodage";
            // 
            // Utf8MenuItem
            // 
            this.Utf8MenuItem.Name = "Utf8MenuItem";
            this.Utf8MenuItem.Size = new System.Drawing.Size(118, 22);
            this.Utf8MenuItem.Text = "UTF-8";
            this.Utf8MenuItem.Click += new System.EventHandler(this.Utf8MenuItemOnClick);
            // 
            // AsciiMenuItem
            // 
            this.AsciiMenuItem.Name = "AsciiMenuItem";
            this.AsciiMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AsciiMenuItem.Text = "ASCII";
            this.AsciiMenuItem.Click += new System.EventHandler(this.AsciiMenuItemOnClick);
            // 
            // UnicodeMenuItem
            // 
            this.UnicodeMenuItem.Name = "UnicodeMenuItem";
            this.UnicodeMenuItem.Size = new System.Drawing.Size(118, 22);
            this.UnicodeMenuItem.Text = "Unicode";
            this.UnicodeMenuItem.Click += new System.EventHandler(this.UnicodeMenuItemOnClick);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowLogsMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.aideToolStripMenuItem.Text = "Outils";
            // 
            // ShowLogsMenuItem
            // 
            this.ShowLogsMenuItem.Name = "ShowLogsMenuItem";
            this.ShowLogsMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ShowLogsMenuItem.Text = "Logs";
            this.ShowLogsMenuItem.Click += new System.EventHandler(this.ShowLogsOnClick);
            // 
            // aideToolStripMenuItem1
            // 
            this.aideToolStripMenuItem1.Name = "aideToolStripMenuItem1";
            this.aideToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem1.Text = "Aide";
            // 
            // RichTextBox
            // 
            this.RichTextBox.AcceptsTab = true;
            this.RichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.RichTextBox.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox.Location = new System.Drawing.Point(12, 57);
            this.RichTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(760, 479);
            this.RichTextBox.TabIndex = 1;
            this.RichTextBox.Text = "";
            this.RichTextBox.SelectionChanged += new System.EventHandler(this.RichTextBoxOnSelectionChanged);
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBoxOnTextChanged);
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.BackColor = System.Drawing.Color.White;
            this.MainToolStrip.GripMargin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu,
            this.ToolStripOpen,
            this.ToolStripNew,
            this.ToolStripSave,
            this.ToolStripSaveAs,
            this.ToolStripPrevious,
            this.ToolStripNext,
            this.ToolStripErase,
            this.ToolStripParameters,
            this.Separator2,
            this.ToolStripBold,
            this.ToolStripItalic,
            this.ToolStripUnderline,
            this.Separator3,
            this.ToolStripLeftAlign,
            this.ToolStripCenterAlign,
            this.ToolStripRightAlign,
            this.Separator4,
            this.ToolStripPoliceFamily,
            this.ToolStripPoliceSize});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.MainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainToolStrip.Size = new System.Drawing.Size(784, 25);
            this.MainToolStrip.Stretch = true;
            this.MainToolStrip.TabIndex = 2;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // ToolStripMenu
            // 
            this.ToolStripMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripMenu.Image = global::NightDrive.Properties.Resources.Menu;
            this.ToolStripMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Size = new System.Drawing.Size(23, 22);
            this.ToolStripMenu.Text = "Menu";
            this.ToolStripMenu.Click += new System.EventHandler(this.ToolStripMenuOnClick);
            // 
            // ToolStripOpen
            // 
            this.ToolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripOpen.Image")));
            this.ToolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripOpen.Name = "ToolStripOpen";
            this.ToolStripOpen.Size = new System.Drawing.Size(23, 22);
            this.ToolStripOpen.Text = "Ouvrir";
            this.ToolStripOpen.Click += new System.EventHandler(this.ToolStripOpenOnClick);
            // 
            // ToolStripNew
            // 
            this.ToolStripNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripNew.Image = global::NightDrive.Properties.Resources.New;
            this.ToolStripNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripNew.Name = "ToolStripNew";
            this.ToolStripNew.Size = new System.Drawing.Size(23, 22);
            this.ToolStripNew.Text = "Nouveau";
            this.ToolStripNew.Click += new System.EventHandler(this.ToolStripNewOnClick);
            // 
            // ToolStripSave
            // 
            this.ToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSave.Image")));
            this.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSave.Name = "ToolStripSave";
            this.ToolStripSave.Size = new System.Drawing.Size(23, 22);
            this.ToolStripSave.Text = "Sauvegarder";
            this.ToolStripSave.Click += new System.EventHandler(this.ToolStripSaveOnClick);
            // 
            // ToolStripSaveAs
            // 
            this.ToolStripSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripSaveAs.Image = global::NightDrive.Properties.Resources.SaveAs;
            this.ToolStripSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripSaveAs.Name = "ToolStripSaveAs";
            this.ToolStripSaveAs.Size = new System.Drawing.Size(23, 22);
            this.ToolStripSaveAs.Text = "Enregistrer sous";
            this.ToolStripSaveAs.Click += new System.EventHandler(this.ToolStripSaveAs_Click);
            // 
            // ToolStripPrevious
            // 
            this.ToolStripPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripPrevious.Image = global::NightDrive.Properties.Resources.Previous;
            this.ToolStripPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripPrevious.Name = "ToolStripPrevious";
            this.ToolStripPrevious.Size = new System.Drawing.Size(23, 22);
            this.ToolStripPrevious.Text = "toolStripButton2";
            this.ToolStripPrevious.Click += new System.EventHandler(this.ToolStripPreviousOnClick);
            // 
            // ToolStripNext
            // 
            this.ToolStripNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripNext.Image = global::NightDrive.Properties.Resources.Next;
            this.ToolStripNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripNext.Name = "ToolStripNext";
            this.ToolStripNext.Size = new System.Drawing.Size(23, 22);
            this.ToolStripNext.Text = "ToolStripNext";
            this.ToolStripNext.Click += new System.EventHandler(this.ToolStripNextOnClick);
            // 
            // ToolStripErase
            // 
            this.ToolStripErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripErase.Image = global::NightDrive.Properties.Resources.Erase;
            this.ToolStripErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripErase.Name = "ToolStripErase";
            this.ToolStripErase.Size = new System.Drawing.Size(23, 22);
            this.ToolStripErase.Text = "Effacer";
            this.ToolStripErase.Click += new System.EventHandler(this.ToolStripEraseOClick);
            // 
            // ToolStripParameters
            // 
            this.ToolStripParameters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripParameters.Image = global::NightDrive.Properties.Resources.Options;
            this.ToolStripParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripParameters.Name = "ToolStripParameters";
            this.ToolStripParameters.Size = new System.Drawing.Size(23, 22);
            this.ToolStripParameters.Text = "Paramètres";
            this.ToolStripParameters.Click += new System.EventHandler(this.ToolStripParametersOnClick);
            // 
            // Separator2
            // 
            this.Separator2.ForeColor = System.Drawing.Color.Black;
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripBold
            // 
            this.ToolStripBold.CheckOnClick = true;
            this.ToolStripBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripBold.Image = global::NightDrive.Properties.Resources.Bold;
            this.ToolStripBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripBold.Name = "ToolStripBold";
            this.ToolStripBold.Size = new System.Drawing.Size(23, 22);
            this.ToolStripBold.Text = "Gras";
            this.ToolStripBold.Click += new System.EventHandler(this.ToolStripBoldOnClick);
            // 
            // ToolStripItalic
            // 
            this.ToolStripItalic.CheckOnClick = true;
            this.ToolStripItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripItalic.Image = global::NightDrive.Properties.Resources.Italic;
            this.ToolStripItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripItalic.Name = "ToolStripItalic";
            this.ToolStripItalic.Size = new System.Drawing.Size(23, 22);
            this.ToolStripItalic.Text = "Italique";
            this.ToolStripItalic.Click += new System.EventHandler(this.ToolStripItalicOnClick);
            // 
            // ToolStripUnderline
            // 
            this.ToolStripUnderline.CheckOnClick = true;
            this.ToolStripUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripUnderline.Image = global::NightDrive.Properties.Resources.Underline;
            this.ToolStripUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripUnderline.Name = "ToolStripUnderline";
            this.ToolStripUnderline.Size = new System.Drawing.Size(23, 22);
            this.ToolStripUnderline.Text = "Souligner";
            this.ToolStripUnderline.Click += new System.EventHandler(this.ToolStripUnderlineOnClick);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLeftAlign
            // 
            this.ToolStripLeftAlign.CheckOnClick = true;
            this.ToolStripLeftAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripLeftAlign.Image = global::NightDrive.Properties.Resources.AlignLeft;
            this.ToolStripLeftAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripLeftAlign.Name = "ToolStripLeftAlign";
            this.ToolStripLeftAlign.Size = new System.Drawing.Size(23, 22);
            this.ToolStripLeftAlign.Text = "Aligner à gauche";
            this.ToolStripLeftAlign.Click += new System.EventHandler(this.ToolStripLeftAlign_Click);
            // 
            // ToolStripCenterAlign
            // 
            this.ToolStripCenterAlign.CheckOnClick = true;
            this.ToolStripCenterAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripCenterAlign.Image = global::NightDrive.Properties.Resources.AlignCenter;
            this.ToolStripCenterAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripCenterAlign.Name = "ToolStripCenterAlign";
            this.ToolStripCenterAlign.Size = new System.Drawing.Size(23, 22);
            this.ToolStripCenterAlign.Text = "Centrer";
            this.ToolStripCenterAlign.Click += new System.EventHandler(this.ToolStripCenter_Click);
            // 
            // ToolStripRightAlign
            // 
            this.ToolStripRightAlign.CheckOnClick = true;
            this.ToolStripRightAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripRightAlign.Image = global::NightDrive.Properties.Resources.AlignRight;
            this.ToolStripRightAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripRightAlign.Name = "ToolStripRightAlign";
            this.ToolStripRightAlign.Size = new System.Drawing.Size(23, 22);
            this.ToolStripRightAlign.Text = "Aligner à droite";
            this.ToolStripRightAlign.Click += new System.EventHandler(this.ToolStripRightAlign_Click);
            // 
            // Separator4
            // 
            this.Separator4.ForeColor = System.Drawing.Color.Black;
            this.Separator4.Name = "Separator4";
            this.Separator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripPoliceFamily
            // 
            this.ToolStripPoliceFamily.AutoSize = false;
            this.ToolStripPoliceFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolStripPoliceFamily.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ToolStripPoliceFamily.Name = "ToolStripPoliceFamily";
            this.ToolStripPoliceFamily.Size = new System.Drawing.Size(135, 23);
            this.ToolStripPoliceFamily.Sorted = true;
            this.ToolStripPoliceFamily.Text = "Microsoft Sans Serif";
            this.ToolStripPoliceFamily.ToolTipText = "Nom de police";
            this.ToolStripPoliceFamily.SelectedIndexChanged += new System.EventHandler(this.ToolStripPoliceFamilyOnSelectedIndexChanged);
            // 
            // ToolStripPoliceSize
            // 
            this.ToolStripPoliceSize.AutoSize = false;
            this.ToolStripPoliceSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolStripPoliceSize.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ToolStripPoliceSize.Name = "ToolStripPoliceSize";
            this.ToolStripPoliceSize.Size = new System.Drawing.Size(45, 23);
            this.ToolStripPoliceSize.Text = "8";
            this.ToolStripPoliceSize.ToolTipText = "Taille de police";
            this.ToolStripPoliceSize.SelectedIndexChanged += new System.EventHandler(this.ToolStripPoliceSizeOnSelectedIndexChanged);
            // 
            // FileFormatLabel
            // 
            this.FileFormatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileFormatLabel.AutoSize = true;
            this.FileFormatLabel.Location = new System.Drawing.Point(12, 539);
            this.FileFormatLabel.Name = "FileFormatLabel";
            this.FileFormatLabel.Size = new System.Drawing.Size(76, 13);
            this.FileFormatLabel.TabIndex = 3;
            this.FileFormatLabel.Text = "Normal text file";
            // 
            // FileLenghtLabel
            // 
            this.FileLenghtLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FileLenghtLabel.AutoSize = true;
            this.FileLenghtLabel.Location = new System.Drawing.Point(333, 539);
            this.FileLenghtLabel.Name = "FileLenghtLabel";
            this.FileLenghtLabel.Size = new System.Drawing.Size(90, 13);
            this.FileLenghtLabel.TabIndex = 4;
            this.FileLenghtLabel.Text = "length: 0   lines: 0";
            // 
            // FileEncodingLabel
            // 
            this.FileEncodingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileEncodingLabel.AutoSize = true;
            this.FileEncodingLabel.Location = new System.Drawing.Point(735, 539);
            this.FileEncodingLabel.Name = "FileEncodingLabel";
            this.FileEncodingLabel.Size = new System.Drawing.Size(37, 13);
            this.FileEncodingLabel.TabIndex = 5;
            this.FileEncodingLabel.Text = "UTF-8";
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBox.Location = new System.Drawing.Point(44, 82);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(573, 428);
            this.PictureBox.TabIndex = 6;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxOnMouseDown);
            this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxOnMouseMove);
            this.PictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxOnMouseUp);
            // 
            // PicturePanel
            // 
            this.PicturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicturePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PicturePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicturePanel.Controls.Add(this.EllipseButton);
            this.PicturePanel.Controls.Add(this.RectangleButton);
            this.PicturePanel.Controls.Add(this.LineButton);
            this.PicturePanel.Controls.Add(this.ZoomButton);
            this.PicturePanel.Controls.Add(this.ZoomLabel);
            this.PicturePanel.Controls.Add(this.ZoomUpDown);
            this.PicturePanel.Controls.Add(this.EraserButton);
            this.PicturePanel.Controls.Add(this.ClearButton);
            this.PicturePanel.Controls.Add(this.PencilButton);
            this.PicturePanel.Location = new System.Drawing.Point(645, 57);
            this.PicturePanel.Name = "PicturePanel";
            this.PicturePanel.Size = new System.Drawing.Size(127, 479);
            this.PicturePanel.TabIndex = 7;
            // 
            // EllipseButton
            // 
            this.EllipseButton.BackColor = System.Drawing.Color.White;
            this.EllipseButton.BackgroundImage = global::NightDrive.Properties.Resources.Circle;
            this.EllipseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EllipseButton.Location = new System.Drawing.Point(12, 125);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(45, 45);
            this.EllipseButton.TabIndex = 8;
            this.EllipseButton.UseVisualStyleBackColor = false;
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButtonOnClick);
            // 
            // RectangleButton
            // 
            this.RectangleButton.BackColor = System.Drawing.Color.White;
            this.RectangleButton.BackgroundImage = global::NightDrive.Properties.Resources.Rectangle;
            this.RectangleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RectangleButton.Location = new System.Drawing.Point(69, 74);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(45, 45);
            this.RectangleButton.TabIndex = 7;
            this.RectangleButton.UseVisualStyleBackColor = false;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButtonOnClick);
            // 
            // LineButton
            // 
            this.LineButton.BackColor = System.Drawing.Color.White;
            this.LineButton.BackgroundImage = global::NightDrive.Properties.Resources.Line;
            this.LineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LineButton.Location = new System.Drawing.Point(12, 74);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(45, 45);
            this.LineButton.TabIndex = 6;
            this.LineButton.UseVisualStyleBackColor = false;
            this.LineButton.Click += new System.EventHandler(this.LineButtonOnClick);
            // 
            // ZoomButton
            // 
            this.ZoomButton.BackColor = System.Drawing.Color.White;
            this.ZoomButton.Location = new System.Drawing.Point(69, 437);
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Size = new System.Drawing.Size(41, 20);
            this.ZoomButton.TabIndex = 5;
            this.ZoomButton.Text = "Ok";
            this.ZoomButton.UseVisualStyleBackColor = false;
            this.ZoomButton.Click += new System.EventHandler(this.ZoomButtonOnClick);
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.AutoSize = true;
            this.ZoomLabel.Location = new System.Drawing.Point(33, 421);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(51, 13);
            this.ZoomLabel.TabIndex = 4;
            this.ZoomLabel.Text = "Zoom (%)";
            // 
            // ZoomUpDown
            // 
            this.ZoomUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ZoomUpDown.Location = new System.Drawing.Point(12, 437);
            this.ZoomUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ZoomUpDown.Name = "ZoomUpDown";
            this.ZoomUpDown.Size = new System.Drawing.Size(51, 20);
            this.ZoomUpDown.TabIndex = 3;
            this.ZoomUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // EraserButton
            // 
            this.EraserButton.BackColor = System.Drawing.Color.White;
            this.EraserButton.BackgroundImage = global::NightDrive.Properties.Resources.Eraser;
            this.EraserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EraserButton.Location = new System.Drawing.Point(69, 23);
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(45, 45);
            this.EraserButton.TabIndex = 2;
            this.EraserButton.UseVisualStyleBackColor = false;
            this.EraserButton.Click += new System.EventHandler(this.EraserButtonOnClick);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.White;
            this.ClearButton.BackgroundImage = global::NightDrive.Properties.Resources.Clear;
            this.ClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClearButton.Location = new System.Drawing.Point(69, 125);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(45, 45);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButtonOnClick);
            // 
            // PencilButton
            // 
            this.PencilButton.BackColor = System.Drawing.Color.White;
            this.PencilButton.BackgroundImage = global::NightDrive.Properties.Resources.Pencil;
            this.PencilButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PencilButton.Location = new System.Drawing.Point(12, 23);
            this.PencilButton.Margin = new System.Windows.Forms.Padding(0);
            this.PencilButton.Name = "PencilButton";
            this.PencilButton.Size = new System.Drawing.Size(45, 45);
            this.PencilButton.TabIndex = 0;
            this.PencilButton.UseVisualStyleBackColor = false;
            this.PencilButton.Click += new System.EventHandler(this.PencilButtonOnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.PicturePanel);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.FileEncodingLabel);
            this.Controls.Add(this.FileLenghtLabel);
            this.Controls.Add(this.FileFormatLabel);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.RichTextBox);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormOnClosing);
            this.Resize += new System.EventHandler(this.OnResize);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.PicturePanel.ResumeLayout(false);
            this.PicturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLogsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveMenutem;
        private ToolStrip MainToolStrip;
        private ToolStripButton ToolStripNew;
        private ToolStripButton ToolStripSave;
        private ToolStripButton ToolStripParameters;
        private ToolStripButton ToolStripMenu;
        private ToolStripButton ToolStripErase;
        private OpenFileDialog OpenFileDialogBox;
        private SaveFileDialog SaveFileDialogBox;
        private ToolStripButton ToolStripOpen;
        private ToolStripMenuItem SaveAsMenuItem;
        private ToolStripButton ToolStripSaveAs;
        private ToolStripButton ToolStripPrevious;
        private ToolStripButton ToolStripNext;
        private ToolStripSeparator Separator1;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem ThemeMenuItem;
        private ToolStripMenuItem DefaultThemeMenuItem;
        private ToolStripMenuItem DarkThemeMenuItem;
        private ToolStripSeparator Separator2;
        private FontDialog FontDialogBox;
        private ToolStripMenuItem EncodingMenuItem;
        internal Label FileFormatLabel;
        internal Label FileLenghtLabel;
        internal Label FileEncodingLabel;
        internal RichTextBox RichTextBox;
        private ToolStripMenuItem Utf8MenuItem;
        private ToolStripMenuItem UnicodeMenuItem;
        private ToolStripMenuItem AsciiMenuItem;
        private ToolStripButton ToolStripBold;
        private ToolStripButton ToolStripItalic;
        private ToolStripButton ToolStripUnderline;
        private ToolStripSeparator Separator3;
        private ToolStripButton ToolStripLeftAlign;
        private ToolStripButton ToolStripCenterAlign;
        private ToolStripButton ToolStripRightAlign;
        private ToolStripSeparator Separator4;
        private ToolStripComboBox ToolStripPoliceSize;
        private ToolStripComboBox ToolStripPoliceFamily;
        private Panel PicturePanel;
        private Button PencilButton;
        internal PictureBox PictureBox;
        private Button ClearButton;
        private Button EraserButton;
        private NumericUpDown ZoomUpDown;
        private Button ZoomButton;
        private Label ZoomLabel;
        private Button EllipseButton;
        private Button RectangleButton;
        private Button LineButton;
    }
}

