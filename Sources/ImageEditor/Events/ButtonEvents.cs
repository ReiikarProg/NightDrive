using System;
using System.Drawing;
using System.Windows.Forms;
using NightDrive.Enums;
using NightDrive.Helpers;

namespace NightDrive
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Selecting the Pencil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PencilButtonOnClick(object sender, EventArgs e)
        {
            // Activate the pencil
            this.SelectedAction = PictureAction.Pencil;
        }

        /// <summary>
        /// Selecting the Eraser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraserButtonOnClick(object sender, EventArgs e)
        {
            // Activate the eraser
            this.SelectedAction = PictureAction.Eraser;
        }

        /// <summary>
        /// Selecting line drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineButtonOnClick(object sender, EventArgs e)
        {
            // Activate line drawing
            this.SelectedAction = PictureAction.Line;
        }

        /// <summary>
        /// Selecting ellipse drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EllipseButtonOnClick(object sender, EventArgs e)
        {
            // Activate the ellipse drawing
            this.SelectedAction = PictureAction.Ellipse;
        }

        /// <summary>
        /// Selecting rectangle drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleButtonOnClick(object sender, EventArgs e)
        {
            // Activate rectangle drawing
            this.SelectedAction = PictureAction.Rectangle;
        }

        /// <summary>
        /// Open a color dialog and let the user choose a color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorChoiceButtonOnClick(object sender, EventArgs e)
        {
            Logger.Log(LogLevel.Info, "Letting the user choose a color...");

            // Open the dialog box
            this.ColorDialog.ShowDialog();
            // Update current color
            this.DrawingColor = this.ColorDialog.Color;
            // Preview the color for the user
            this.PreviewColorButton.BackColor = this.ColorDialog.Color;
            // Update drawing pen color
            this.DrawingPen.Color = this.ColorDialog.Color;
        }

        /// <summary>
        /// Selecting fill action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillButtonOnClick(object sender, EventArgs e)
        {
            this.SelectedAction = PictureAction.Fill;
        }

        /// <summary>
        /// Clear the picture box and select then unselect any action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButtonOnClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == CustomDialogBox.ShowMessage(
                    "Voulez-vous suppimer l'image actuelle ?\n(toutes les données non enregistrées seront perdues) ",
                    CustomBoxIcon.Info,
                    CustomBoxButton.YesOrNo))
            {
                Logger.Log(LogLevel.Info, "Successfully clear Picture box");
                this.Clear();
            }
        }

        /// <summary>
        /// Validate the zoom value selected at the dropdown menu and apply it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomButtonOnClick(object sender, EventArgs e)
        {
            this.Zoom(Convert.ToInt32(this.ZoomUpDown.Text));
        }
    }
}
