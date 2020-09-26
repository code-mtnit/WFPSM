using System;
using System.Collections.Generic;
using System.Text;
using MonitorClient2._;
using System.Diagnostics;
using System.Collections;
using MonitorClient2._0;
using BaseClass;

namespace MonitorClient2._
{
    public class PerformanceBL
    {        
        // Thread signal.
        public static Hashtable perfCountres;

        public static String CPUUsage = "";

        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData ReturnedReplyData = new ReplyData();
            ReturnedReplyData.Type = Consts.SectionType.Performance;

            DataContainer CurrProcessDataContianer = new DataContainer();

            foreach (ObjectMetaData CurrCounter in receivedQueryData.ArrCounter)
            {
                try
                {
                    string tempVal = ((PerformanceCounter)perfCountres[CurrCounter.Tag]).NextValue().ToString();
                    CurrProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Tag, tempVal));

                    if ("Processor;% Processor Time;_Total".CompareTo(CurrCounter.Tag) == 0)
                    {
                        CPUUsage = tempVal;
                    }
                }
                catch (Exception)
                {
                    Log.WriteToLog(string.Format("Failed to add the counter: {0}", CurrCounter.Text));
                }
            }
            
            ReturnedReplyData.ArrDataContainers.Add(CurrProcessDataContianer);

            return ReturnedReplyData;
        }        
    }


}
