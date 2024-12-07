using System;
using System.Drawing;
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
            if (this.CurrentFile is { IsSaved: true })
            {
                this.CurrentFile.IsSaved = false;
                this.UpdateHeader();
            }

            this.ShouldPaint = true;
            this.PictureY = e.Location;

            // Starting movement location
            this.moveStartX = e.X;
            this.moveStartY = e.Y;
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

                // If the mouse is moving, set the start and end points to get width and height
                this.x = e.X;
                this.y = e.Y;
                this.moveWidth = e.X - this.moveStartX;
                this.moveHeight = e.Y - this.moveStartY;
            }
        }

        /// <summary>
        /// Called when mouse leaves picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxOnMouseUp(object sender, MouseEventArgs e)
        {   
            this.ShouldPaint = false;

            // Set ending position after our movement
            this.moveWidth = this.x - this.moveStartX;
            this.moveHeight = this.y - this.moveStartY;

            // Draw ellipse
            if (this.SelectedAction == PictureAction.Ellipse)
            {
               this.PictureGraphics.DrawEllipse(DrawingPen, moveStartX, moveStartY, moveWidth, moveHeight);
               this.PictureBox.Refresh();
                Logger.Log(LogLevel.Info, $"Drawing ellipse at ({moveStartX}, {moveStartY}) with size ({moveWidth}, {moveHeight})");
            }

            // Draw rectangle
            if (this.SelectedAction == PictureAction.Rectangle)
            {
                this.PictureGraphics.DrawRectangle(this.DrawingPen, moveStartX, moveStartY, moveWidth, moveHeight);
                this.PictureBox.Refresh();
                Logger.Log(LogLevel.Info,$"Drawing rectangle at ({moveStartX}, {moveStartY}) with size ({moveWidth}, {moveHeight})");
            }

            if (this.SelectedAction == PictureAction.Line)
            {
                this.PictureGraphics.DrawLine(this.DrawingPen, moveStartX, moveStartY, x, y);
                this.PictureBox.Refresh();
                Logger.Log(LogLevel.Info, $"Drawing line from ({moveStartX}, {moveStartY}) to ({x}, {y})");
            }
        }

        /// <summary>
        /// Called on click on the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxOnMouseClick(object sender, MouseEventArgs e)
        {
            // Proceed to fill if selected
            if (this.SelectedAction == PictureAction.Fill)
            {
                Point point = e.Location;
                this.Fill(point.X, point.Y);
            }
        }

        /// <summary>
        /// Fired when the image of the picture box is drawn.
        /// Make visible the drawing while the mouse is still down on it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (ShouldPaint)
            {
                // Draw ellipse
                if (this.SelectedAction == PictureAction.Ellipse)
                {
                    g.DrawEllipse(DrawingPen, moveStartX, moveStartY, moveWidth, moveHeight);
                }

                // Draw rectangle
                if (this.SelectedAction == PictureAction.Rectangle)
                {
                    g.DrawRectangle(this.DrawingPen, moveStartX, moveStartY, moveWidth, moveHeight);
                }

                if (this.SelectedAction == PictureAction.Line)
                {
                    g.DrawLine(this.DrawingPen, moveStartX, moveStartY, x, y);
                }
            }
        }

        /// <summary>
        /// Fired whenever the drawing pen width combo box value is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawingSizeComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.Log(LogLevel.Info, $"Updating drawing pen width ({this.DrawingPen.Width} => {this.DrawingSizeComboBox.Text})");
            this.DrawingPen = new Pen(this.DrawingColor, float.Parse(this.DrawingSizeComboBox.Text));
        }

        /// <summary>
        ///  Fired whenever the eraser pen width combo box value is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErasingSizeComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.Log(LogLevel.Info, $"Updating eraser pen width ({this.EraserPen.Width} => {this.ErasingSizeComboBox.Text})");
            this.EraserPen = new Pen(Color.White, float.Parse(this.ErasingSizeComboBox.Text));
        }
    }
}
