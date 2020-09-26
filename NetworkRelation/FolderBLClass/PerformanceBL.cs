using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BaseClass;

namespace MonitorInfoViewer
{
    public class PerformanceBL : BaseBL
    {
        public PerformanceBL()
        {
            m_ArrCounters.Add(new ObjectMetaData(true, "% User Time", "Processor;% User Time;_Total"));
        }

        public override ReplyData ExecuteQuery(string i_IP, int i_Port, ClientInfo clientInfo)
        {
            QueryData PerfQueryData = new QueryData();
            PerfQueryData.Type = Consts.SectionType.Performance;

            foreach (ObjectMetaData currCounter in m_ArrCounters)
            {
                if (currCounter.Checked)
                {
                    PerfQueryData.ArrCounter.Add(currCounter);
                }
            }
            PerfQueryData.CurrClient = clientInfo;
            string QueryString = PerfQueryData.Serialize();
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
