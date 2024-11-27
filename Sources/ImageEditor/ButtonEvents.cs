using System;
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

        private void ClearButtonOnClick(object sender, EventArgs e)
        {
            this.SelectedAction = PictureAction.None;

            // Clear the content
            // this.PictureBox.Image.Reset
        }
    }
}
