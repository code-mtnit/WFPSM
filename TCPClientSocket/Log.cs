using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace MonitorClient2._0
{
    public static class Log
    {
        const string LogPath = "Log.ini";
        
        private static Mutex mut = new Mutex();

        public static void WriteToLog(string Message)
        {
            try
            {
                mut.WaitOne();

                StreamWriter sw = File.AppendText(LogPath);
                sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                sw.Close();

                mut.ReleaseMutex();
            }
            catch { }

        }
    }
}
