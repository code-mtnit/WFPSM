using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Management;
using System.Globalization;
using BaseClass;


namespace MonitorClient2._
{
    public class ProcessesBL
    {
        #region Data Members
        private ArrayList m_ArrCounters = new ArrayList();

        public ArrayList ArrCounters
        {
            get { return m_ArrCounters; }
        }

        public static Hashtable PCCounters = new Hashtable(new myCultureComparer());
        
        #endregion

        public ProcessesBL()
        {
        }

        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData returnedReplyData = new ReplyData();
            Process[] ProcessList = Process.GetProcesses();

            foreach (Process CurrProcess in ProcessList)
            {
                if (!PCCounters.ContainsKey(CurrProcess.Id))
                {
                    Hashtable CountersList = new Hashtable();
                    CountersList.Add("ProcessorTime", new PerformanceCounter("Process", "% Processor Time", CurrProcess.ProcessName));
                    CountersList.Add("IOReads", new PerformanceCounter("Process", "IO Read Bytes/sec", CurrProcess.ProcessName));
                    CountersList.Add("PageFaults", new PerformanceCounter("Process", "Page Faults/sec", CurrProcess.ProcessName));

                    try
                    {
                        ((PerformanceCounter)CountersList["ProcessorTime"]).NextValue();
                        ((PerformanceCounter)CountersList["IOReads"]).NextValue();
                        ((PerformanceCounter)CountersList["PageFaults"]).NextValue();
                    }
                    catch (Exception) { }

                    PCCounters.Add(CurrProcess.Id, CountersList);                                        
                }   
            }

            foreach (Process CurrProcess in ProcessList)
            {
                DataContainer currProcessDataContianer = new DataContainer();
                currProcessDataContianer.Name = CurrProcess.Id.ToString();
                

                foreach (ObjectMetaData CurrCounter in receivedQueryData.ArrCounter)
                {
                    switch (CurrCounter.Tag)
                    {                        
                        case "Name":
                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, CurrProcess.ProcessName.ToString()));
                            break;
                        case "Main File Name":
                            try 
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, CurrProcess.MainModule.FileName));
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, ""));
                            }
                            break;
                        case "Start Time":
                            try
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, CurrProcess.StartTime.ToString()));
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, ""));
                            }
                            break;
                        case "User Name":
                            try
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, GetProcessOwner(CurrProcess.Id)));
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, ""));
                            }
                            break;
                        case "Peak Memory":
                            int temp = (int)CurrProcess.PeakWorkingSet64/1024;
                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, temp.ToString()));
                            break;
                        case "Handles Count":
                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, CurrProcess.HandleCount.ToString()));
                            break;
                        case "Threads Count":
                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, CurrProcess.Threads.Count.ToString()));
                            break;
                        case "Memory Usage":
                            temp = (int)CurrProcess.WorkingSet64 / 1024;
                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, temp.ToString()));
                            break;
                        case "CPU Time":
                            try
                            {
                                String CPUTime = CurrProcess.TotalProcessorTime.Hours.ToString() + ":"
                                    + CurrProcess.TotalProcessorTime.Minutes.ToString() + ":"
                                    + CurrProcess.TotalProcessorTime.Seconds.ToString();
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, CPUTime));
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, "0"));
                            }
                            break;
                        case "CPU Usage":
                            String tempValue;
                            try
                            {
                                tempValue = ((PerformanceCounter)((Hashtable)PCCounters[CurrProcess.Id])["ProcessorTime"]).NextValue().ToString();

                                if (tempValue.Length > 2)
                                {
                                    tempValue = tempValue.Substring(0, 2);
                                    if (tempValue[1] == '.')
                                    {
                                        tempValue = tempValue.Substring(0, 1);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                tempValue = Convert.ToString(0);
                            }

                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, tempValue));
                            break;
                        case "Paged Memory":
                            try
                            {
                                temp = (int)CurrProcess.PagedMemorySize64 / 1024;
                                if (temp > 0)
                                {
                                    currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, temp.ToString()));
                                }
                                else
                                {
                                    currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, "0"));
                                }
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, "0"));
                            }
                            break;
                        case "I/O Reads":
                            try
                            {
                                temp = (int)((PerformanceCounter)((Hashtable)PCCounters[CurrProcess.Id])["IOReads"]).NextValue();

                                if (temp > 0)
                                {
                                    currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, temp.ToString()));
                                }
                                else
                                {
                                    currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, Convert.ToString(0)));
                                }
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, Convert.ToString(0)));
                            }
                            break;
                        case "Page Faults":
                            try
                            {
                                temp = (int)((PerformanceCounter)((Hashtable)PCCounters[CurrProcess.Id])["PageFaults"]).NextValue();

                                if (temp > 0)
                                {
                                    currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, temp.ToString()));
                                }
                                else
                                {
                                    currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, Convert.ToString(0.0)));
                                }
                            }
                            catch (Exception)
                            {
                                currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, Convert.ToString(0)));
                            }
                            break;
                        case "Priority":
                            String processPriority = CurrProcess.BasePriority.ToString();

                            if (CurrProcess.BasePriority == 0)
                            {
                                processPriority = "N/A";
                            }
                            else if (CurrProcess.BasePriority < 7)
                            {
                                processPriority = "Low";
                            }
                            else if (CurrProcess.BasePriority < 12)
                            {
                                processPriority = "Normal";
                            }
                            else if (CurrProcess.BasePriority < 13)
                            {
                                processPriority = "Above Normal";
                            }
                            else
                            {
                                processPriority = "High";
                            }
                            
                            currProcessDataContianer.ArrCounters.Add(new Counter(CurrCounter.Text, processPriority));
                            break;
                    }
                }

                returnedReplyData.ArrDataContainers.Add(currProcessDataContianer);
            }

            return returnedReplyData;
        }
        public static string GetProcessOwner(int processID)
        {

            string queryString = "Select * From Win32_Process Where ProcessID = " + processID;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(queryString);

            ManagementObjectCollection processList = searcher.Get();

            string owner = string.Empty;

            foreach (ManagementObject currentProcess in processList)
            {
                string[] argList = { string.Empty };
                int returnValue = Convert.ToInt32(currentProcess.InvokeMethod("GetOwner", argList));
                if (returnValue == 0)
                    owner = argList[0];
            }

            return owner;

        }

    }
}
