namespace NightDrive.Enums
{
    public enum FileFormat
    {
        /// <summary>
        /// Unknown format, default value.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Used as to cancel a format choice.
        /// </summary>
        Cancel = 0,

        /// <summary>
        /// Normal text file.
        /// </summary>
        Text = 1,

        /// <summary>
        /// Rich text file.
        /// </summary>
        RichText = 2,

        /// <summary>
        /// JPG file.
        /// </summary>
        Image = 3,

        /// <summary>
        /// Data grid view file (dgv).
        /// </summary>
        Grid = 4
    }
}
