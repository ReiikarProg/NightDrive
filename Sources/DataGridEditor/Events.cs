using NightDrive.Enums;
using NightDrive._Helpers;
using System.Windows.Forms;

namespace NightDrive
{
    public partial class MainForm
    {
        /// <summary>
        /// Handle column renaming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewOnColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Logger.Log(LogLevel.Info, $"Trying to rename the column at index {e.ColumnIndex}");

            this.DataGridView.Columns[e.ColumnIndex].HeaderText = CustomDialogBox.ShowTextBoxToUser(
                "Merci de saisir le nouveau nom de la colonne");
        }
    }
}
