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
        /// jpg file/
        /// </summary>
        Image = 3,
    }
}
