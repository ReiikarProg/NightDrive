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

        private void EraserButtonOnClick(object sender, EventArgs e)
        {
            // Activate the eraser
            this.SelectedAction = PictureAction.Eraser;
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
