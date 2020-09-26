using System;
using System.Collections.Generic;
using System.Text;
using MonitorClient2._;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Globalization;
using BaseClass;


namespace MonitorClient3._0
{
    public class SysInfoBL
    {
        public struct _PERFORMANCE_INFORMATION
        {
            public uint cb;
            public uint CommitTotal;
            public uint CommitLimit;
            public uint CommitPeak;
            public uint PhysicalTotal;
            public uint PhysicalAvailable;
            public uint SystemCache;
            public uint KernelTotal;
            public uint KernelPaged;
            public uint KernelNonpaged;
            public uint PageSize;
            public uint HandleCount;
            public uint ProcessCount;
            public uint ThreadCount;
        }

        public struct MemoryStatus
        {
            public uint Length;
            public uint MemoryLoad;
            public uint TotalPhysical;
            public uint AvailablePhysical;
            public uint TotalPageFile;
            public uint AvailablePageFile;
            public uint TotalVirtual;
            public uint AvailableVirtual;
        }

        [DllImport("Psapi.dll")]
        public static extern void GetPerformanceInfo(out _PERFORMANCE_INFORMATION stat);
        [DllImport("kernel32.dll")]
        public static extern void GlobalMemoryStatus(out MemoryStatus stat);

        public struct StaticSysInfo
        {
            public string Version;
            public string ProductType;
            public string ServicePackVersion;
            public string RegToUser;
            public string RegToOrg;
            public string ComputerName;
            public string PMTotal;
            public string LoggedOnUser;
            public string CommitLimit;
        }

        public static StaticSysInfo m_StaticSysInfo = new StaticSysInfo();

        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData returnedReplyData = new ReplyData();
            returnedReplyData.Type = Consts.SectionType.SysInfo;
            DataContainer SysDynmicInfoDataContainer = new DataContainer("OSDynmicInfo");
            
            String AAA;
            if (PerformanceBL.CPUUsage.Length != 0)
            {
                AAA = PerformanceBL.CPUUsage;
                PerformanceBL.CPUUsage = "";
            }
            else
            {
                Thread.Sleep(150);
                AAA = ((PerformanceCounter)PerformanceBL.perfCountres["Processor;% Processor Time;_Total"]).NextValue().ToString();
            }
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("CPUUsagePercentage", AAA));
            DataContainer SysStaticInfoDataContainer = new DataContainer("OSStaticInfo");
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("Version", m_StaticSysInfo.Version));
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("ProductType", m_StaticSysInfo.ProductType));
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("ServicePackVersion", m_StaticSysInfo.ServicePackVersion));
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("RegToUser", m_StaticSysInfo.RegToUser));            
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("ComputerName", m_StaticSysInfo.ComputerName));
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("PMTotal", m_StaticSysInfo.PMTotal));
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("LoggedOnUser", m_StaticSysInfo.LoggedOnUser));
            SysStaticInfoDataContainer.ArrCounters.Add(new Counter("CommitLimit", m_StaticSysInfo.CommitLimit));
            returnedReplyData.ArrDataContainers.Add(SysStaticInfoDataContainer);


            MemoryStatus stat = new MemoryStatus();
            GlobalMemoryStatus(out stat);
            int AvaliablePM = (int)stat.AvailablePhysical / 1024;
            int AvaliableVirtual = (int)stat.AvailableVirtual / 1024;
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("AvailableVirtual", AvaliableVirtual.ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("AvailablePM", AvaliablePM.ToString("#,#", CultureInfo.InvariantCulture)));
            Double UsedPMMB = (Convert.ToInt32(m_StaticSysInfo.PMTotal) - AvaliablePM) / 1024;
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("UsedPMMB", UsedPMMB.ToString()));
            _PERFORMANCE_INFORMATION perfSysStat = new _PERFORMANCE_INFORMATION();
            GetPerformanceInfo(out perfSysStat);
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("SystemCache", ((int)(perfSysStat.SystemCache * 4)).ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("CommitPeak", ((int)(perfSysStat.CommitPeak * 4)).ToString()));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("KernelTotal", ((int)(perfSysStat.KernelTotal * 4)).ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("KernelPaged", ((int)(perfSysStat.KernelPaged * 4)).ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("KernelNonpaged", ((int)(perfSysStat.KernelNonpaged * 4)).ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("ProcessesCount",
                ((PerformanceCounter)PerformanceBL.perfCountres["System;Processes;"]).NextValue().ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("ThreadsCount",
                ((PerformanceCounter)PerformanceBL.perfCountres["System;Threads;"]).NextValue().ToString("#,#", CultureInfo.InvariantCulture)));
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("HandlesCount", perfSysStat.HandleCount.ToString("#,#", CultureInfo.InvariantCulture)));
            int tempCommitCurrent = (int)Convert.ToDouble(((PerformanceCounter)PerformanceBL.perfCountres["Memory;Committed Bytes;"]).NextValue().ToString()) / 1024;
            SysDynmicInfoDataContainer.ArrCounters.Add(new Counter("CommitCurrent", tempCommitCurrent.ToString())); 
            returnedReplyData.ArrDataContainers.Add(SysDynmicInfoDataContainer);

            
            DataContainer SysLogicalDrivesDataContainer = new DataContainer("OSLogicalDrives");

            DriveInfo[] AllDriveInfo = DriveInfo.GetDrives();


            foreach (DriveInfo CurrLogicalDrive in DriveInfo.GetDrives())
            {
                try
                {
                    if (CurrLogicalDrive.Name == "A:\\")  //Added by rm
                    {
                        // if (!CurrLogicalDrive.IsReady)
                        SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + "Not accessable" + '-' + "Not accessable"));
                        continue;
                    }


                    if (CurrLogicalDrive.IsReady)
                    {

                        decimal FreeSpacePercent = decimal.Divide(CurrLogicalDrive.TotalFreeSpace, CurrLogicalDrive.TotalSize) * 10000;
                        int tempNum = Convert.ToInt32(FreeSpacePercent);
                        long TotalSizeMB = CurrLogicalDrive.TotalSize / 1000000;
                        FreeSpacePercent = decimal.Divide(tempNum, 100);
                        SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + FreeSpacePercent.ToString() + "%" + '-' + TotalSizeMB.ToString("#,#", CultureInfo.InvariantCulture)));
                    }
                    else
                    {
                        SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + "Not accessable" + '-' + "Not accessable"));
                    }
                }
                catch (Exception)
                {
                    SysLogicalDrivesDataContainer.ArrCounters.Add(new Counter("DiskName", CurrLogicalDrive.Name + '-' + "Not accessable" + '-' + "Not accessable"));
                }
            }
            returnedReplyData.ArrDataContainers.Add(SysLogicalDrivesDataContainer);
            return returnedReplyData;
        }
    }
}
