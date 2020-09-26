using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using MonitorClient2._;

namespace TCPClientSocket
{
    public class Starter
    {
        public Thread m_ClinetStartListenThread = null;
        public int UsedPort = 11000;
        //static string ClientIPAddress = "127.0.0.1";



        public void Start(bool StartMonitoring)
        {
            InitClientDefinitions();

            if (StartMonitoring)
                Comm.StartMonitoring();

            m_ClinetStartListenThread = new Thread(new ParameterizedThreadStart(ClinetStartListen));
            m_ClinetStartListenThread.Start();
        }

        private bool InitClientDefinitions()
        {
            bool IsDefinitionLoaded = true;

            try
            {

                if (!File.Exists("Definitions.ini"))
                    return false;

                string InDef = string.Empty;
                FileStream fs = File.Open("Definitions.ini", FileMode.Open, FileAccess.Read);

                byte[] Info = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(Info, 0, Info.Length) > 0)
                {
                    InDef += temp.GetString(Info);
                }

                char[] Delimiters = new char[] { '=', '\n' };
                string[] Definitions = InDef.Split(Delimiters);

                for (int i = 0; i < Definitions.Length; i += 2)
                {
                    switch (Definitions[i].ToLower())
                    {
                        //case "clientip":
                        //    ClientIPAddress = Definitions[i + 1].Trim();
                        //    //m_ClientDef.ServerIP = Definitions[i + 1].Trim();
                        //    break;
                        case "port":
                            UsedPort = int.Parse(Definitions[i + 1].Trim());
                            //m_ClientDef.Port = Definitions[i + 1].Trim();
                            break;
                        default:
                            break;
                    }
                }

                //if (m_ClientDef.ServerIP == string.Empty)
                //if (ClientIPAddress == string.Empty)
                //{
                //    IsDefinitionLoaded = false;
                //}
            }
            catch (Exception)
            {
                IsDefinitionLoaded = false;
            }

            return IsDefinitionLoaded;
        }

        public void Stop()
        {
            Comm.StopMonitoring();
            if (m_ClinetStartListenThread != null)
            {
                m_ClinetStartListenThread.Abort();
               // Comm.StopListening();
            }

           
        }

        private void ClinetStartListen(Object i_MethodInvoker)
        {
            // Comm.StartListening(m_ClientDef);
            Comm.StartListening(UsedPort);
            
        }
    }
}
