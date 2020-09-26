using System;
using System.Collections.Generic;
using System.Text;
using BaseClass;

namespace MonitorInfoViewer
{
    public class SysInfoBL : BaseBL
    {
        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo)
        {
            QueryData SysInfoQueryData = new QueryData();
            SysInfoQueryData.Type = Consts.SectionType.SysInfo;

            //SysInfoQueryData.ArrCounter.Add(new ObjectMetaData("ProcessName", m_ProcessName));
            SysInfoQueryData.CurrClient = clientInfo;
            string QueryString = SysInfoQueryData.Serialize();
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

