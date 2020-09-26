using System;
using System.Collections.Generic;
using System.Text;
using BaseClass;

namespace MonitorInfoViewer
{
    public class PropertiesBL : BaseBL
    {
        private string m_ProcessName;

        public PropertiesBL(string i_ProcessName)
        {
            m_ProcessName = i_ProcessName;
        }

        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo)
        {
            QueryData PropertiesQueryData = new QueryData();
            PropertiesQueryData.Type = Consts.SectionType.Properties;

            PropertiesQueryData.ArrCounter.Add(new ObjectMetaData("ProcessName", m_ProcessName));

            string QueryString = PropertiesQueryData.Serialize();
            String ReplyString = Comm.SendQuery(i_IP, i_Port, QueryString);
            ReplyData ReplyDataObj = ReplyData.Deserialize(ReplyString);

            return ReplyDataObj;
        }

        public override ReplyData ExecuteQuery(string i_IP, int i_Port)
        {
            throw new NotImplementedException();
        }

        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo, object CurObj)
        {
            throw new NotImplementedException();
        }
    }
}
