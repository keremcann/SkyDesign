using System;
using System.IO;
using System.Text;
using SkyDesign.Domain.Shared.Constants;
using SkyDesign.Core.Configuration;
using SkyDesign.Domain.Shared.Enums;

namespace SkyDesign.Core.LogHelper
{
    public class FileLog
    {
        private readonly object fileLock = new object();
        private readonly string logFilename;

        /// <summary>
        ///
        /// </summary>
        public FileLog()
        {
            string path = Directory.GetCurrentDirectory() + AppSettings.GetLogFilePath();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            logFilename = path + DateTime.Now.ToString("yyyyMMddTHHmmss") + Logs.FileLogExtension;
        }

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(LogLevel.FATAL, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteFormattedLog(LogLevel.TRACE, text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteFormattedLog(LogLevel.WARNING, text);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="append"></param>
        private void WriteLine(string text, bool append = false)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                lock (fileLock)
                {
                    using (StreamWriter writer = new StreamWriter(logFilename, append, Encoding.UTF8))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="level"></param>
        /// <param name="text"></param>
        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.TRACE:
                    pretext = DateTime.Now.ToString(Logs.FileLogDateFormat) + Logs.FileLogTrace;
                    break;
                case LogLevel.INFO:
                    pretext = DateTime.Now.ToString(Logs.FileLogDateFormat) + Logs.FileLogInfo;
                    break;
                case LogLevel.DEBUG:
                    pretext = DateTime.Now.ToString(Logs.FileLogDateFormat) + Logs.FileLogDebug;
                    break;
                case LogLevel.WARNING:
                    pretext = DateTime.Now.ToString(Logs.FileLogDateFormat) + Logs.FileLogWarning;
                    break;
                case LogLevel.ERROR:
                    pretext = DateTime.Now.ToString(Logs.FileLogDateFormat) + Logs.FileLogError;
                    break;
                case LogLevel.FATAL:
                    pretext = DateTime.Now.ToString(Logs.FileLogDateFormat) + Logs.FileLogFatal;
                    break;
                default:
                    pretext = "";
                    break;
            }
            WriteLine(pretext + text, true);
        }
    }
}
