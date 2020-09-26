using System;
using System.Collections.Generic;
using System.Text;
using BaseClass;

namespace MonitorInfoViewer
{
    public class ClientStatusBL : BaseBL
    {
        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo)
        {
            QueryData StatusQueryData = new QueryData();
            StatusQueryData.Type = Consts.SectionType.Status;
            StatusQueryData.CurrClient = clientInfo;
            string QueryString = StatusQueryData.Serialize();
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
