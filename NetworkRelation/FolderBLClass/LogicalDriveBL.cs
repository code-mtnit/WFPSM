using System;
using System.Collections.Generic;
using System.Text;
using BaseClass;

namespace MonitorInfoViewer
{
    public class LogicalDriveBL : BaseBL
    {
        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo)
        {
            return null;
            throw new NotImplementedException();
        }

        public override ReplyData ExecuteQuery(string i_IP, int i_Port)
        {
            throw new NotImplementedException();
        }

        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo, object CurObj)
        {
            QueryData SysInfoQueryData = new QueryData();
            SysInfoQueryData.Type = Consts.SectionType.ExplorerLogicalDrive;


            if (CurObj == null || CurObj.ToString() == "")
            {
                SysInfoQueryData.ArrCounter.Add(new ObjectMetaData(CurObj.ToString(), "OSLogicalDrives"));
                
            }
            else
            {

                SysInfoQueryData.ArrCounter.Add(new ObjectMetaData(CurObj.ToString(), "ViewPath"));
            }
            SysInfoQueryData.CurrClient = clientInfo;
            string QueryString = SysInfoQueryData.Serialize();
            String ReplyString = Comm.SendQuery(i_IP, i_Port, QueryString);
            ReplyData ReplyDataObj = ReplyData.Deserialize(ReplyString);

            return ReplyDataObj;
        }
    }
}

