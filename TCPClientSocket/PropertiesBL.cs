using System;
using System.Collections.Generic;
using System.Text;
using MonitorClient2._;
using System.Diagnostics;
using System.Collections.Specialized;
using BaseClass;

namespace MonitorClient2._0
{
    public class PropertiesBL
    {
        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData returnedReplyData = new ReplyData();

            ObjectMetaData ProcessNameCounter = (ObjectMetaData)receivedQueryData.ArrCounter[0];

            Process CurrProcess = Process.GetProcessById(Convert.ToInt32(ProcessNameCounter.Tag));

            if (CurrProcess != null)
            {             
                StringDictionary Vars = CurrProcess.StartInfo.EnvironmentVariables;
                DataContainer EnvsDataContianer = new DataContainer();
                EnvsDataContianer.Name = "EnvironmentVariables";

                foreach (string s in Vars.Keys)
                {
                    EnvsDataContianer.ArrCounters.Add(new Counter(s, Vars[s]));
                }

                returnedReplyData.ArrDataContainers.Add(EnvsDataContianer);

                foreach (ProcessThread CurrThread in CurrProcess.Threads)
                {
                    DataContainer ThreadDataContianer = new DataContainer();
                    ThreadDataContianer.Name = CurrThread.Id.ToString();

                    try
                    {
                        ThreadDataContianer.ArrCounters.Add(new Counter("CPU", CurrThread.TotalProcessorTime.ToString()));
                        ThreadDataContianer.ArrCounters.Add(new Counter("StartTime", CurrThread.StartTime.ToString()));
                        ThreadDataContianer.ArrCounters.Add(new Counter("UserProcessorTime", CurrThread.UserProcessorTime.ToString()));
                    }
                    catch (Exception)
                    {
                        ThreadDataContianer.ArrCounters.Add(new Counter("CPU", Convert.ToString(0)));
                        ThreadDataContianer.ArrCounters.Add(new Counter("StartTime", DateTime.MinValue.ToString()));
                        ThreadDataContianer.ArrCounters.Add(new Counter("UserProcessorTime", ""));
                    }

                    ThreadDataContianer.ArrCounters.Add(new Counter("StartAddress", CurrThread.StartAddress.ToString()));                    
                    ThreadDataContianer.ArrCounters.Add(new Counter("ThreadState", CurrThread.ThreadState.ToString()));
                    ThreadDataContianer.ArrCounters.Add(new Counter("BasePriority", CurrThread.BasePriority.ToString()));                    
                    ThreadDataContianer.ArrCounters.Add(new Counter("CurrentPriority", CurrThread.CurrentPriority.ToString()));

                    if (CurrThread.ThreadState == ThreadState.Wait)
                    {
                        ThreadDataContianer.ArrCounters.Add(new Counter("WaitReason", CurrThread.WaitReason.ToString()));
                    }
                    else
                    {
                        ThreadDataContianer.ArrCounters.Add(new Counter("WaitReason", ""));
                    }

                    returnedReplyData.ArrDataContainers.Add(ThreadDataContianer);
                }
            }
            else
            {
                Log.WriteToLog(string.Format("Process {0} does not exists.", ProcessNameCounter.Tag));
            }

            return returnedReplyData;
        }
    }
}
