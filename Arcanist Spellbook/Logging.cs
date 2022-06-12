using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arcanist_Spellbook
{
    public class Logging
    {
        public string LogFileLocation;

        public Logging(string logfile)
        {
            LogFileLocation = logfile;
        }

        private void WriteToLogFile(string message)
        {
            string Content;
            // Read the current log file
            try
            {
                using (StreamReader streamReader = new StreamReader(this.LogFileLocation))
                {
                    Content = streamReader.ReadToEnd();
                }
            }
            catch
            {
                Content = "";
            }

            // Write to the log file

            using (StreamWriter streamWriter = new StreamWriter(this.LogFileLocation))
            {
                streamWriter.Write(message + Content);
                streamWriter.Close();
            }
        }
        public void Log(string log)
        {
            DateTime now = DateTime.Now;

            string message = $"[{now.ToString()}]\n" +
                $"{log}\n\n";
            // Print the log to console
            Console.Error.Write(message);

            // Write to the log file
            this.WriteToLogFile(message);

        }
        public void Log(Exception e)
        {
            string message = $"{e.Message}\n" +
                $"{e.StackTrace}";
            // Print Log
            this.Log(message);
        }
    }
}
