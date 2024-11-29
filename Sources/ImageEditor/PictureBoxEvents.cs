using System;
using NightDrive.Enums;
using System.Windows.Forms;
using NightDrive.Helpers;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Called when mouse enters picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxOnMouseDown(object sender, MouseEventArgs e)
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

        /// <summary>
        /// Called when left clicK is still applied on the picture box and the mouse is moving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxOnMouseMove(object sender, MouseEventArgs e)
        {
            if (this.ShouldPaint)
            {
                // Pencil is selected, draw
                if (this.SelectedAction == PictureAction.Pencil)
                {
                    this.PictureX = e.Location;
                    this.PictureGraphics.DrawLine(this.DrawingPen, this.PictureX, this.PictureY);
                    this.PictureY = this.PictureX;
                }

                // Eraser is selected, erase
                if (this.SelectedAction == PictureAction.Eraser)
                {
                    this.PictureX = e.Location;
                    this.PictureGraphics.DrawLine(this.EraserPen, this.PictureX, this.PictureY);
                    this.PictureY = this.PictureX;
                }

                // Update the PictureBox
                this.PictureBox.Refresh();
            }
        }

        /// <summary>
        /// Called when mouse leaves picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxOnMouseUp(object sender, MouseEventArgs e)
        {   
            Console.WriteLine($"Leaving picture box,  shouldPaint: {this.ShouldPaint}");

            this.ShouldPaint = false;
        }
    }
}
