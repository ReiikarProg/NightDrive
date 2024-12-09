using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using NightDrive.Enums;
using NightDrive._Helpers;

namespace NightDrive
{
    public class FileEx
    {
        /// <summary>
        /// Short name of the file, without the format
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// The name of the document, including the file format.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Full path of the file: {Path\Name}
        /// </summary>
        public string AbsolutePath { get; set; }

        /// <summary>
        /// The format of the file
        /// </summary>
        public FileFormat Format { get; set; }

        /// <summary>
        /// File encoding.
        /// </summary>
        public FileEncoding Encoding { get; set; }

        /// <summary>
        /// Is the document saved ?
        /// </summary>
        public bool IsSaved { get; set; }

        /// <summary>
        /// Parent rich text box from witch text should be written.
        /// </summary>
        private readonly MainForm ParentMainForm = null;

        /// <summary>
        /// List of accepted file format.
        /// </summary>
        private static string[] AcceptedFormat = new[] { "txt", "rtf", "jpg" };

        #region Private/Internal methods
        /// <summary>
        /// Get the full name of the file, which is Name.Format.
        /// Only used once in the constructor.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string GetFullName(string nameWithoutExtension)
        {
            string name = this.Format switch
            {
                FileFormat.Text => nameWithoutExtension + ".txt",
                FileFormat.RichText => nameWithoutExtension + ".rtf",
                FileFormat.Image => nameWithoutExtension + ".jpg",
                _ => throw new Exception($"Unsupported file format")
            };

            return name;
        }

        /// <summary>
        /// Called whenever a rich text action is performed to update the format if needed.
        /// </summary>
        internal bool SwitchToRtfCheck()
        {
            bool switched = false;

            if (this.Format != FileFormat.RichText)
            {
                Logger.Log(LogLevel.Info, $"Switching \"{this.ShortName}\" into a rtf file");

                this.Format = FileFormat.RichText;
                // Set file extension property
                this.Name = GetFullName(this.ShortName);
                // Update full path
                this.AbsolutePath = Path + "\\" + Name;
                switched = true;
            }
            // Else, nothing to update.

            return switched;
        }
        #endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="path"></param>
        /// <param name="nameWithoutExtension"></param>
        /// <param name="format"></param>
        /// <param name="encoding"></param>
        /// <param name="isSaved"></param>
        private FileEx(MainForm parentForm, string path, string nameWithoutExtension, FileFormat format, FileEncoding encoding, bool isSaved = true)
        {
            // Parent form
            ParentMainForm = parentForm;

            // file properties
            Path = string.IsNullOrWhiteSpace(path) ? (Paths.AbsolutePath + Paths.SaveLocation) : path;
            Format = format;
            Encoding = encoding;
            ShortName = nameWithoutExtension;
            Name = GetFullName(nameWithoutExtension);
            AbsolutePath = Path + "\\" + Name;

            IsSaved = isSaved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="parentPictureBox"></param>
        /// <param name="parenBitmap"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static FileEx CreateEmptyFile(MainForm parentForm, FileFormat format)
        {
            return new FileEx(parentForm,"","nouveau", FileFormat.Text, format == FileFormat.Image ? FileEncoding.None : FileEncoding.Utf8);
        }

        /// <summary>
        /// Create a new file and return a fileEx object given all the required parameters.
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="path"></param>
        /// <param name="nameWithoutExtension"></param>
        /// <param name="format"></param>
        /// <param name="encoding"></param>
        /// <param name="isSaved"></param>
        /// <returns></returns>
        public static FileEx Create(MainForm parentForm, string path, string nameWithoutExtension, FileFormat format, FileEncoding encoding, bool isSaved = true)
        {
            return new FileEx(parentForm, path, nameWithoutExtension, format, encoding, isSaved);
        }

        /// <summary>
        /// CreateEmptyFile and return a fileEx object given only the absolute file path.
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        public static FileEx Create(MainForm parentForm, string absolutePath, FileEncoding encoding = FileEncoding.Utf8)
        {
            FileEx fileObj = null;
            FileFormat format = FileFormat.Unknown;

            // CreateEmptyFile a file object from the full path
            int fileNameIndex = absolutePath.LastIndexOf('\\');

            string location = absolutePath.Substring(0, fileNameIndex);
            string nameWithFormat = absolutePath.Substring(fileNameIndex + 1);

            string[] split = nameWithFormat.Split('.');
            string errorMsg;

            if (split.Length == 2)
            {
                if (FileEx.AcceptedFormat.Contains(split[1]))
                {
                    format = split[1] switch
                    {
                        "txt" => FileFormat.Text,
                        "rtf" => FileFormat.RichText,
                        "jpg" => FileFormat.Image,
                            _ => FileFormat.Unknown
                    };

                    Logger.Log(LogLevel.Info, $"[FileEx - Create] File with format \"{format}\"");

                    if (format != FileFormat.Unknown)
                    {
                        fileObj = new FileEx(parentForm, location, split[0], format, encoding);
                    }
                    else
                    {
                        errorMsg = $"Failed to create File object given the absolute path \'{absolutePath}\': file format parsing failure";
                        CustomDialogBox.ShowMessage(errorMsg, CustomBoxIcon.Error, CustomBoxButton.Ok);
                        Logger.Log(LogLevel.Error, errorMsg);
                    }
                }
                else
                {
                    errorMsg = $"Failed to create File object given the absolute path \'{absolutePath}\': unsupported file format";
                    CustomDialogBox.ShowMessage(errorMsg, CustomBoxIcon.Error, CustomBoxButton.Ok);
                    Logger.Log(LogLevel.Error, errorMsg);
                }
            }
            else
            {
                errorMsg = $"Failed to create File object given the absolute path \'{absolutePath}\': split failure";
                Logger.Log(LogLevel.Error, errorMsg);
            }

            return fileObj ?? FileEx.CreateEmptyFile(parentForm, format);
        }

        /// <summary>
        /// Open the file by printing all its content to the RichTextBox.
        /// </summary>
        internal void Open()
        {
            Logger.Log(LogLevel.Info, $"[FileEx] - Loading {this.Format} file located at \"{this.AbsolutePath}\" with encoding {this.Encoding}");

            Encoding enc = Tools.GetEncodingFromEnumFileEncoding(this.Encoding);

            try
            {
                if (File.Exists(this.AbsolutePath))
                {
                    if (this.Format == FileFormat.Text)
                    {
                        string[] fileLines = File.ReadAllLines(this.AbsolutePath, enc);

                        for (int i = 0; i < fileLines.Length; i++)
                        {
                            string line = i == 0 ? fileLines[i] : ("\n" + fileLines[i]);
                            this.ParentMainForm.Text += line;
                        }

                        Logger.Log(LogLevel.Info, "[FileEx] - Successfully loaded .txt file");
                    }
                    else if (this.Format == FileFormat.RichText)
                    {
                        this.ParentMainForm.RichTextBox.Text = string.Empty;
                        this.ParentMainForm.RichTextBox.LoadFile(this.AbsolutePath, RichTextBoxStreamType.RichText);
                        Logger.Log(LogLevel.Info, "[FileEx] - Successfully loaded .rtf file");
                    }
                    else if (this.Format == FileFormat.Image)
                    {
                        // Get the image from the file, then set it as well as its graphics
                        using (FileStream stream = new FileStream(this.AbsolutePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            // Get the image object
                            Image image = Image.FromStream(stream);
                            Logger.Log(LogLevel.Info, $"[FileEx] - Image size: {image.Size}");

                            // Set the image in out box
                            this.ParentMainForm.PictureBox.Image = image;
                            this.ParentMainForm.OriginalImageSize = new Size(image.Width, image.Height);

                            this.ParentMainForm.PictureGraphics = Graphics.FromImage(this.ParentMainForm.PictureBox.Image);
                        }
                            
                        Logger.Log(LogLevel.Info, "[FileEx] - Successfully loaded .jpg file");
                    }
                }
                else
                {
                    Logger.Log(LogLevel.Warning, $"[FileEx] - Failed to load {this.AbsolutePath} as it doesn't exist");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Exception, ex.Message);
            }
        }

        /// <summary>
        /// (Over) Write the file data.
        /// </summary>
        internal void Write()
        {
            try
            {
                // .txt file, simple write
                if (this.Format == FileFormat.Text)
                {
                    // Delete the file if there's already one
                    if (File.Exists(this.AbsolutePath))
                    {
                        File.Delete(this.AbsolutePath);
                    }
                    // Else, the file will be created

                    // Write data to the file
                    using (var fileStream = new FileStream(this.AbsolutePath, FileMode.OpenOrCreate))
                    {
                        using (var writer = new StreamWriter(fileStream))
                        {
                            writer.Write(this.ParentMainForm.Text);
                        }
                    }

                    this.IsSaved = true;
                }
                // .rtf are managed their own way
                else if (this.Format == FileFormat.RichText)
                {
                    this.ParentMainForm.RichTextBox.SaveFile(this.AbsolutePath, RichTextBoxStreamType.RichText);
                    this.IsSaved = true;
                }
                // .jpg files
                else if (this.Format == FileFormat.Image)
                {
                    // Crete a new bitmap from the picture box image
                    Bitmap toSaveBitmap = new Bitmap(this.ParentMainForm.PictureBox.Image);

                    // The file already exists
                    if (File.Exists(this.AbsolutePath))
                    {
                        Console.WriteLine($"Image file {this.AbsolutePath} already exists, delete it after released any linked objects");
                        File.Delete(this.AbsolutePath);
                    }
                    
                    // Save it at the given path
                    toSaveBitmap.Save(this.AbsolutePath, ImageFormat.Jpeg);
                    this.IsSaved = true;

                    Logger.Log(LogLevel.Info, $"{this.AbsolutePath} successfully saved");
                }
                else
                {
                    Logger.Log(LogLevel.Warning,
                        $"Failed to (over) write file as its format is not supported (yet) (format: {this.Format}");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Exception, $"WriteFileException: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
