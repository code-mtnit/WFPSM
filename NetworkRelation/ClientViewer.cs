using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BaseClass;
using MonitorInfoViewer;

namespace NetworkRelation
{
    public class ClientViewer 
    {

        public TcpClient theClient;//Instant of TCP client
        Stream theStream;//To be attached to the client
        public static String myLine;//To fetch one IP record and siaply it in list view
        public static String theFormat;//To check if the IP range is correct
        public static int flag;


        delegate void UpdateStatusDelegate(ReplyData ReplyDataObj);

        private ClientStatusBL m_StatusBL = new ClientStatusBL();
        private ReplyData m_ReplyDataObj = null;
        private string m_TmpClientIP = string.Empty;
        private string m_TmpClientName = string.Empty;

        public ApplicationDefinitions m_AppDef;

        public ClientViewer(int port)
        {
            m_AppDef = new ApplicationDefinitions();
            m_AppDef.m_Port = port;
        }

        public  ReplyData SendMessage(string text,string caption , MessageBoxButtons boxButtons , MessageBoxIcon icon)
        {
            
            QueryData StatusQueryData = new QueryData();
            StatusQueryData.Type = Consts.SectionType.Message;
            StatusQueryData.CurrClient = m_AppDef.CurrClient;
            StatusQueryData.ArrCounter.Add(new ObjectMetaData(text, "Text"));
            StatusQueryData.ArrCounter.Add(new ObjectMetaData(caption, "Caption"));
            StatusQueryData.ArrCounter.Add(new ObjectMetaData(boxButtons.ToString(), "MessageBoxButtons"));
            StatusQueryData.ArrCounter.Add(new ObjectMetaData(icon.ToString(), "MessageBoxIcon"));
            string QueryString = StatusQueryData.Serialize();
            //String ReplyString = Comm.SendQuery(i_IP, i_Port, QueryString);
            String ReplyString = Comm.SendQuery(m_AppDef.CurrClient.IP, m_AppDef.m_Port, QueryString);
            ReplyData ReplyDataObj = ReplyData.Deserialize(ReplyString);
            return ReplyDataObj;
        }

        public void AddNewClient(String newIP, String newName)
        {
            if (newName == "")
            {
                newName = "Unknown";
            }

            m_TmpClientIP = newIP;
            m_TmpClientName = newName;
            bool isClientExists = false;


            foreach (ClientInfo CurrClient in m_AppDef.ArrClients)
            {
                if (CurrClient.IP.CompareTo(newIP) == 0)
                {
                    isClientExists = true;
                }
            }

            if (isClientExists)
            {
                //MessageBox.Show("This IP is already monitored.\n Please choose another new IP.");
            }
            else
            {
                
                m_AppDef.ArrClients.Add(new ClientInfo(m_TmpClientIP, m_TmpClientName, Consts.ClientStatus.Unknown));

                Thread AddingNewClient = new Thread(new ParameterizedThreadStart(ExecutingQueries));
                AddingNewClient.Start();
            }
        }
        
        private void ExecutingQueries(Object i_MethodInvoker)
        {
            ReplyData ReplyDataObj;

            try
            {
                if (m_AppDef.CurrCenter != null)
                {
                    ClientInfo cInfo = new ClientInfo(m_TmpClientIP, m_TmpClientName, Consts.ClientStatus.Unknown);
                    ReplyDataObj = m_StatusBL.ExecuteQuery(m_AppDef.CurrCenter.IP, m_AppDef.m_Port, cInfo);
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                ReplyDataObj = null;
            }

            UpdateStatusDelegate UpdateStatus = new UpdateStatusDelegate(UpdateClientStatus);
            UpdateStatus(ReplyDataObj);
        }

        private void UpdateClientStatus(ReplyData ReplyDataObj)
        {
            m_ReplyDataObj = ReplyDataObj;
            Consts.ClientStatus NewClientStatus = Consts.ClientStatus.Failure;

            if (m_ReplyDataObj != null)
            {
                NewClientStatus = Consts.ClientStatus.Connected;
            }

            for (int CurrClientIndex = 0; CurrClientIndex < m_AppDef.ArrClients.Count; ++CurrClientIndex)
            {
                if (((ClientInfo)m_AppDef.ArrClients[CurrClientIndex]).IP.CompareTo(m_TmpClientIP) == 0)
                {
                    ((ClientInfo)m_AppDef.ArrClients[CurrClientIndex]).Status = NewClientStatus;
                }
            }

          
        }

        private void RemoveClient(String RemovedIP)
        {
            int RemovedIndex = -1;

            for (int CurrClientIndex = 0; CurrClientIndex < m_AppDef.ArrClients.Count; ++CurrClientIndex)
            {
                if (((ClientInfo)m_AppDef.ArrClients[CurrClientIndex]).IP.CompareTo(RemovedIP) == 0)
                {
                    RemovedIndex = CurrClientIndex;
                }
            }

            m_AppDef.ArrClients.RemoveAt(RemovedIndex);

            if (m_AppDef.CurrClient != null)
            {
                if (m_AppDef.CurrClient.IP.CompareTo(RemovedIP) == 0)
                {
                    m_AppDef.CurrClient = null;
                }
            }
        }



        private void CheckStatus(string ip, string ClientName)
        {
            m_TmpClientIP = ip;
            m_TmpClientName = ClientName;

            Thread ClientStatusQuery = new Thread(new ParameterizedThreadStart(ExecutingQueries));
            ClientStatusQuery.Start();
        }
    }
}
