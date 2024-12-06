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

        internal int x, y, moveWidth, moveHeight, moveStartX, moveStartY;

        /// <summary>
        /// Current drawing pen color (Black is the default one).
        /// </summary>
        internal Color DrawingColor = Color.Black;

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

            // Why is this needed ?
            this.RichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // New bitmap object with the size of the PictureBox
            Bitmap bitmap = new Bitmap(this.PictureBox.Width - 100, this.PictureBox.Height - 100);

            // Get default Pen(s) (with color equals "Black")
            this.DrawingPen = new Pen(this.DrawingColor, 1);

            // Get graphics from the picture
            this.PictureGraphics = Graphics.FromImage(bitmap);
            this.PictureGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Paint the image in White
            this.PictureGraphics.Clear(Color.White);

            // Set the image to the PictureBox
            this.PictureBox.Image = bitmap;
            this.OriginalImageSize = new Size(bitmap.Width, bitmap.Height);

            this.PictureBox.Refresh();

            // Define default values for combo boxes,
            
            // Drawing brush (default is 1)
            this.DrawingSizeComboBox.Items.AddRange(new object[]
            {
                "1",
                "2",
                "3"
            });

            // Erasing brush (default is 15)
            this.ErasingSizeComboBox.Items.AddRange(new object[]
            {
                "10",
                "15",
                "20",
                "25",
                "30"
            });

            // Preset default values
            this.DrawingSizeComboBox.Text = "1";
            this.ErasingSizeComboBox.Text = "15";


            Logger.Log(LogLevel.Info, "Image editor init done");
        }
    }
}
