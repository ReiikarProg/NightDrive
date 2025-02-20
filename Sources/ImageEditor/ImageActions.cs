﻿using System;
using System.Collections;
using System.Collections.Generic;
using NightDrive.Enums;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NightDrive._Helpers;
using System.Drawing.Drawing2D;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Fill(int x, int y)
        {
            Bitmap bitmap = (Bitmap) this.PictureBox.Image;
            Color oldColor = bitmap.GetPixel(x, y);
            Color newColor = this.PreviewColorButton.BackColor;

            Logger.Log(LogLevel.Info, $"Entering fill method: Old color: {oldColor.Name}, New color: {newColor}");

            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bitmap.SetPixel(x, y, this.PreviewColorButton.BackColor);

            // Only process upon real color changes
            if (oldColor != newColor)
            {
                while (pixel.Count > 0)
                {
                    Point pt = (Point)pixel.Pop();

                    if (pt.X > 0 && pt.Y > 0 && pt.X < bitmap.Width - 1 && pt.Y < bitmap.Height - 1)
                    {
                        Tools.Validate(bitmap, pixel, pt.X - 1, pt.Y, oldColor, newColor);
                        Tools.Validate(bitmap, pixel, pt.X, pt.Y - 1, oldColor, newColor);
                        Tools.Validate(bitmap, pixel, pt.X + 1, pt.Y, oldColor, newColor);
                        Tools.Validate(bitmap, pixel, pt.X, pt.Y + 1, oldColor, newColor);
                    }
                }

                // Apply changes on the box
                this.PictureBox.Refresh();
            }
            // Else, trying to fill with the same color, stop that...
        }

        /// <summary>
        /// Zoom the current PictureBox image
        /// </summary>
        /// <param name="zoomValue">Zoom value to apply, from 10 to 200 by 10.</param>
        private void Zoom(int zoomValue)
        {
            if (zoomValue is not 0)
            {
                // Compute the destination image size
                Size modifiedImageSize = new Size((this.OriginalImageSize.Width * zoomValue) / 100,
                    (this.OriginalImageSize.Height * zoomValue) / 100);
                
                Logger.Log(LogLevel.Info, $"Applying zoom value with ration {zoomValue}%, size update: {this.OriginalImageSize} => {modifiedImageSize}");

                Bitmap source = new Bitmap(this.PictureBox.Image);
                Bitmap dest = new Bitmap(Convert.ToInt32(modifiedImageSize.Width), Convert.ToInt32(modifiedImageSize.Height));

                // Get / set graphics for the new bitmap
                this.PictureGraphics = Graphics.FromImage(dest);
                this.PictureGraphics.DrawImage(source, 0, 0, dest.Width + 1, dest.Height + 1);

                // Display the result
                this.PictureBox.Image = dest;
            }
            else
            {
                Logger.Log(LogLevel.Error, "Cannot apply a zoom equal to 0...");
            }
        }


        /// <summary>
        /// Clear the current PictureBox and create a new one.
        /// </summary>
        private void Clear()
        {
            // Unselect any action
            this.SelectedAction = PictureAction.None;

            // New bitmap object with the size of the PictureBox - 100
            Bitmap bitmap = new Bitmap(this.PictureBox.Width - 100, this.PictureBox.Height - 100);

            // Get graphics from the picture
            this.PictureGraphics = Graphics.FromImage(bitmap);
            this.PictureGraphics.Clear(Color.White);

            // Set a new image to the box
            this.PictureBox.Image = bitmap;
            this.OriginalImageSize = new Size(bitmap.Width, bitmap.Height);
        }

    }
}
