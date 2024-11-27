using System.Drawing;
using System.Windows.Forms;

namespace NightDrive.Helpers.Interface
{
    internal class FontEx
    {
        /// <summary>
        /// Current or default font family name.
        /// </summary>
        public string Family = "Microsoft Sans Serif";

        /// <summary>
        /// Current or default font size.
        /// </summary>
        public float Size = 10;

        /// <summary>
        /// Current or default font style.
        /// </summary>
        public FontStyle Style = FontStyle.Regular;

        /// <summary>
        /// Current or default text alignment.
        /// </summary>
        public HorizontalAlignment Alignment { get; set; } = HorizontalAlignment.Left;

        /// <summary>
        /// Get the Font object associate to these parameters
        /// </summary>
        /// <returns></returns>
        public Font GetGlobalFont()
        {
            return new Font(Family, Size, Style);
        }
    }
}
