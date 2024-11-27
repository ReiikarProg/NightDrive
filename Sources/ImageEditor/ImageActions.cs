using NightDrive.Enums;
using System.Drawing;
using System.Windows.Forms;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Clear the current PictureBox and create a new one.
        /// </summary>
        private void Clear()
        {
            // Unselect any action
            this.SelectedAction = PictureAction.None;

            // New bitmap object with the size of the PictureBox
            this.PictureBitmap = new Bitmap(this.PictureBox.Width, this.PictureBox.Height);

            // Get graphics from the picture
            this.PictureGraphics = Graphics.FromImage(this.PictureBitmap);
            this.PictureGraphics.Clear(Color.White);

            // Set a new image to the box
            this.PictureBox.Image = this.PictureBitmap;
        }

    }
}
