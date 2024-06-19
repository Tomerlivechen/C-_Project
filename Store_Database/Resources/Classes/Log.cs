using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace Store_Database.Resources.Classes
{
    public static class Log
    {
        public static string logFilePath { get; set; } = "Resources/Store_Database_log.txt";
        public static void addToLog(string addedLogLine)
        {
            File.AppendAllText(logFilePath, $"{addedLogLine} ___ {DateTime.Now.ToString("yyyy-MM-dd")}\n");
        }
    }
}
