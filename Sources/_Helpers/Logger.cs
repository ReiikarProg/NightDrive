using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using NightDrive.Enums;

namespace NightDrive._Helpers
{
    internal class Logger
    {
        // Directory where the log is written
        private static readonly string LogFilePath = Paths.AbsolutePath + Paths.LogsLocation;

        /// <summary>
        /// Init the logger, which consist in deleting (old) existing file
        /// </summary>
        public static void Init()
        {
            string fileFullPath = $"{LogFilePath}\\log.txt";

            // If an old file is there, set it to "old"
            if (File.Exists(fileFullPath))
            {
                string oldFileName = $"{LogFilePath}\\log.old.txt";

                // If there's already an "old" log file, delete it to place this one
                if (File.Exists(oldFileName))
                {
                    File.Delete(oldFileName);
                    File.Move(fileFullPath, oldFileName);
                }
                else
                {
                    File.Move(fileFullPath, oldFileName);
                }
            }

            // In any case, create a new file and set a creation date
            string initLogFileText = $"          --- Welcome to {Assembly.GetEntryAssembly()?.GetName().Name} logs file :) ---\n" +
                                     $"\n" +
                                     $"This file was created on : {DateTime.Now}" +
                                     $"\n";
            File.AppendAllText(fileFullPath, initLogFileText);
        }

        /// <summary>
        /// Save input data to the log file.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="data"></param>
        /// <param name="writeInConsole"></param>
        public static void Log(LogLevel level, string data, bool writeInConsole = true)
        {
            string fileFullPath = $"{LogFilePath}\\log.txt";
            string logLevel = level switch
            {
                LogLevel.Info => "INFO",
                LogLevel.Warning => "WARN",
                LogLevel.Error => "ERROR",
                LogLevel.Exception => "EXCEPTION",
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };

            // Save a new line
            string text = $"{logLevel} - {DateTime.Now} - {data}";
            File.AppendAllText(fileFullPath, $"\n{text}");

            if (writeInConsole)
            {
                Console.WriteLine(text);
            }
        }   

        /// <summary>
        /// Try to open the log file and display it to the user
        /// </summary>
        public static void OpenLogFile()
        {
            string fileFullPath = $"{LogFilePath}\\log.txt";

            try
            {
                if (File.Exists(fileFullPath))
                {
                    var process = new System.Diagnostics.Process();
                    process.StartInfo = new ProcessStartInfo() { UseShellExecute = true, FileName = fileFullPath };
                    process.Start();
                }
                else
                {
                    CustomDialogBox.ShowMessage($"Trying to open the log file, but it isn't there..., click OK to continue",
                        CustomBoxIcon.Warning, CustomBoxButton.Ok);
                }
            }
            catch (Exception ex) 
            {
                Logger.Log(LogLevel.Exception,
                    $"Exception caught while trying to open log file (path: {fileFullPath}): {ex.Message}");
            }
        }
    }
}
