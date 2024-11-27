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
    }
}
