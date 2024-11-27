using System;
using NightDrive.Enums;
using System.Windows.Forms;
using NightDrive.Helpers;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Entering picture box
            Console.WriteLine($"Entering picture box, shouldPaint: {this.ShouldPaint}");

            if (this.CurrentFile is { IsSaved: true })
            {
                this.CurrentFile.IsSaved = false;
                this.UpdateHeader();
            }

            this.ShouldPaint = true;
            this.PictureY = e.Location;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ShouldPaint)
            {
                // Pencil is selected
                if (this.SelectedAction == PictureAction.Pencil)
                {
                    this.PictureX = e.Location;
                    this.PictureGraphics.DrawLine(this.PicturePen, this.PictureX, this.PictureY);
                    this.PictureY = this.PictureX;
                }

                // Update the PictureBox
                this.PictureBox.Refresh();
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {   
            Console.WriteLine($"Leaving picture box,  shouldPaint: {this.ShouldPaint}");

            this.ShouldPaint = false;
        }
    }
}
