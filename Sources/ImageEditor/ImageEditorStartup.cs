using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        /// Graphics object associated to the image
        /// </summary>
        internal Graphics PictureGraphics;

        /// <summary>
        /// Default size of the image created or generated in the picture box
        /// </summary>
        private Size _originalImageSize = new Size(0, 0);

        internal Size OriginalImageSize
        {
            get => _originalImageSize;    
            set
            {
                Logger.Log(LogLevel.Info, $"New image loaded, original size: {value} (old: {_originalImageSize}");
                _originalImageSize = value;
            }
        }

        internal bool ShouldPaint = false;
        internal Point PictureX;
        internal Point PictureY;

        /// <summary>
        /// Pen used to draw.
        /// </summary>
        internal Pen DrawingPen = new Pen(Color.Black, 1);

        /// <summary>
        /// Pen used to erase.
        /// </summary>
        internal Pen EraserPen = new Pen(Color.White, 15);

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
            this.PictureBox.Size = new Size(760 - this.PicturePanel.Width, 479);  
            this.PictureBox.Location = new Point(12, 57);
            this.RichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // New bitmap object with the size of the PictureBox
            Bitmap bitmap = new Bitmap(this.PictureBox.Width, this.PictureBox.Height);

            // Get graphics from the picture
            this.PictureGraphics = Graphics.FromImage(bitmap);
            this.PictureGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Paint the image in White
            this.PictureGraphics.Clear(Color.White);

            // Set the image to the PictureBox
            this.PictureBox.Image = bitmap;
            this.OriginalImageSize = new Size(bitmap.Width, bitmap.Height);

            this.PictureBox.Refresh();

            Logger.Log(LogLevel.Info, "Image editor init done");
        }
    }
}
