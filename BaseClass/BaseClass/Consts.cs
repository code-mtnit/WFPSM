using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClass
{
    public class Consts
    {
        #region Enums
        public enum SectionType
        {
            Processes,
            Performance,
            SysInfo,
            Properties,
            Status,
            Message,
            CaptureScreen,
            NetWorkInfo,
            DoAction, 
            ExplorerLogicalDrive,

        }

        public enum NetStatus
        {
            Online,
            Offline
        }



        public enum ClientStatus
        {
            Unknown,
            Failure,
            Connected
        }

        public enum ViewerStatus
        {
            Unknown,
            Failure,
            Connected
        }

        public enum CenterStatus 
        {
            Unknown,
            Failure,
            Connected
        }

        #endregion

        public String PERFORMANCE_BL = "PERFORMANCE_BL";
        public String PROCESSES_BL = "PROCESSES_BL";
        public String SOFTWARE_BL = "SOFTWARE_BL";
        public String MESSAGE_BL = "MESSAGE_BL";
        public String CAPTURESCREEN_BL = "CAPTURESCREEN_BL";
        public const int COUNTERS_NUM = 5;
    }
}
