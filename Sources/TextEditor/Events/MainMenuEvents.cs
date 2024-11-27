using System;
using System.Text;
using NightDrive.Enums;
using NightDrive.Helpers;

namespace NightDrive
{
    public partial class MainForm
    {
        /// <summary>
        /// On click action on MenuItem (Fichier -> nouveau)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFileOnClick(object sender, EventArgs e)
        {
            this.New();
        }

        /// <summary>
        /// On click action on MenuItem (Fichier -> Ouvrir)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileOnClick(object sender, EventArgs e)
        {
            this.Open();
        }

        /// <summary>
        /// On click action on MenuItem (Fichier -> Enregistrer)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileOnClick(object sender, EventArgs e)
        {
           this.Save(false);
        }

        /// <summary>
        /// /// On click action on MenuItem (Fichier -> Enregistrer sous)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsMenuItemOnClick(object sender, EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// Open the current logs file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowLogsOnClick(object sender, EventArgs e)
        {
            Logger.OpenLogFile();
        }

        /// <summary>
        /// On click action on MenuItem (Fichier -> Quitter)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItemOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// On click action on MenuItem (Thème -> Normal)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultThemeMenuItemOnClick(object sender, EventArgs e)
        {
            this.ApplyTheme(Theme.Default);
        }

        /// <summary>
        /// On click action on MenuItem (Thème -> Sombre)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DarkThemeMenuItemOnClick(object sender, EventArgs e)
        {
            this.ApplyTheme(Theme.Dark);
        }

        /// <summary>
        /// On click action on MenuItem (Encodage -> UTF-8)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Utf8MenuItemOnClick(object sender, EventArgs e)
        {
            this.ApplyEncoding(Encoding.UTF8);
        }

        /// <summary>
        /// On click action on MenuItem (Encodage -> ASCII)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsciiMenuItemOnClick(object sender, EventArgs e)
        {
            this.ApplyEncoding(Encoding.ASCII);
        }

        /// <summary>
        /// On click action on MenuItem (Encodage -> Unicode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnicodeMenuItemOnClick(object sender, EventArgs e)
        {
            this.ApplyEncoding(Encoding.GetEncoding("utf-16"));
        }
    }
}
