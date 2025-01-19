using System.Drawing;
using System.Windows.Forms;

namespace NightDrive._Helpers.Interface
{
    static class GridInterfacePresets
    {
        /// <summary>
        /// Column header cell style used for default theme
        /// </summary>
        public static DataGridViewCellStyle DefaultCellStyle = new ()
        {
            BackColor = Color.White,                // background cell color
            ForeColor = Color.Black,                // text color
            SelectionBackColor = Color.Blue,        // selection background color
            SelectionForeColor = Color.White,       // selected text color
        };

        /// <summary>
        /// Column header cell style used for default theme
        /// </summary>
        public static DataGridViewCellStyle DarkCellStyle = new()
        {
            BackColor = MainForm.GetGrayColorVariantFromInt(100),                              // background cell color
            ForeColor = Color.White,                                                       // text color
            SelectionBackColor = MainForm.GetGrayColorVariantFromInt(200),                   // selection background color
            SelectionForeColor = Color.Black,                   // selected text color
        };
    }
}
