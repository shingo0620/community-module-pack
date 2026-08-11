using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Events_Module {

    /// <summary>
    /// Writes a small Events Module-only diagnostic log without depending on Blish HUD's logger.
    /// </summary>
    internal static class DiagnosticLog {

        private const long MaxLogBytes = 1024 * 1024;

        private static readonly object SyncRoot = new object();
        private static readonly string LogDirectory = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Blish HUD",
            "Events Module");
        private static readonly string LogFilePath = System.IO.Path.Combine(LogDirectory, "events-module.log");

        internal static string Path => LogFilePath;

        internal static void Info(string message) {
            Write("INFO", message);
        }

        internal static void Error(string message, Exception exception) {
            var details = exception == null
                ? message
                : string.Format(CultureInfo.InvariantCulture, "{0} Exception={1}", message, exception);

            Write("ERROR", details);
        }

        private static void Write(string level, string message) {
            try {
                lock (SyncRoot) {
                    Directory.CreateDirectory(LogDirectory);

                    if (File.Exists(LogFilePath) && new FileInfo(LogFilePath).Length > MaxLogBytes) {
                        var backupPath = LogFilePath + ".old";
                        if (File.Exists(backupPath)) File.Delete(backupPath);
                        File.Move(LogFilePath, backupPath);
                    }

                    var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    File.AppendAllText(
                        LogFilePath,
                        string.Format(CultureInfo.InvariantCulture, "[{0}] [{1}] {2}{3}", timestamp, level, message, Environment.NewLine),
                        Encoding.UTF8);
                }
            } catch {
                // Diagnostics must never prevent the module from loading or displaying notifications.
            }
        }
    }
}
