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
        /// Bitmap object
        /// </summary>
        internal Bitmap PictureBitmap;


        internal Graphics PictureGraphics;
        internal bool ShouldPaint = false;

        internal Point PictureX;
        internal Point PictureY;

        internal Pen PicturePen = new Pen(Color.Black, 1);

        /// <summary>
        /// Selected action to perform.
        /// </summary>
        private PictureAction _selectedAction = PictureAction.None;

        private PictureAction SelectedAction
        {
            get => this._selectedAction;
            set
            {
                Logger.Log(LogLevel.Info, $"Image editor action changed: {_selectedAction} => {value}");
                this._selectedAction = value;
            }
        }

        /// <summary>
        /// Init image editor components.
        /// </summary>
        private void InitializeImageEditor()
        {
            // PictureBox default location & size
            this.PictureBox.Size = new Size(760 - 87, 479);  // 87 is the button panel size
            this.PictureBox.Location = new Point(12, 57);
            this.RichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // New bitmap object with the size of the PictureBox
            this.PictureBitmap = new Bitmap(this.PictureBox.Width, this.PictureBox.Height);

            // Get graphics from the picture
            this.PictureGraphics = Graphics.FromImage(this.PictureBitmap);
            this.PictureGraphics.Clear(Color.White);

            // Set the image to the PictureBox
            this.PictureBox.Image = this.PictureBitmap;
            this.PictureBox.Refresh();

            Logger.Log(LogLevel.Info, "Image editor init done");
        }
    }
}
