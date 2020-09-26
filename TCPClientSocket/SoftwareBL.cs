using System;
using System.Collections.Generic;
using System.Text;
using MonitorClient2._;
using System.Management;
using BaseClass;

namespace MonitorClient2._0
{
    public class SoftwareBL
    {
        public static ReplyData executeQuery(QueryData receivedQueryData)
        {
            ReplyData returnedReplyData = new ReplyData();
            
            EnumerationOptions enums = new EnumerationOptions();
            
            int Counter = 0;
            
            ManagementObjectSearcher SoftwareList = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_softwareFeature");
                        
            foreach (ManagementObject Software in SoftwareList.Get())
            {
                if (Counter < 1200)
                {
                    DataContainer SoftwareDataContianer = new DataContainer();
                    SoftwareDataContianer.Name = Software.GetPropertyValue("ProductName").ToString();                    

                    SoftwareDataContianer.ArrCounters.Add(new Counter("Name", Software.GetPropertyValue("Name") == null ? "" : Software.GetPropertyValue("Name").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("Accesses", Software.GetPropertyValue("Accesses") == null ? "" : Software.GetPropertyValue("Accesses").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("IdentifyingNumber", Software.GetPropertyValue("IdentifyingNumber") == null ? "" : Software.GetPropertyValue("IdentifyingNumber").ToString()));                    
                    SoftwareDataContianer.ArrCounters.Add(new Counter("Caption", Software.GetPropertyValue("Caption") == null ? "" : Software.GetPropertyValue("Caption").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("Description", Software.GetPropertyValue("Description") == null ? "" : Software.GetPropertyValue("Description").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("InstallDate", Software.GetPropertyValue("InstallDate") == null ? "" : Software.GetPropertyValue("InstallDate").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("InstallState", Software.GetPropertyValue("InstallState") == null ? "" : Software.GetPropertyValue("InstallState").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("Status", Software.GetPropertyValue("Status") == null ? "" : Software.GetPropertyValue("Status").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("Vendor", Software.GetPropertyValue("Vendor") == null ? "" : Software.GetPropertyValue("Vendor").ToString()));
                    SoftwareDataContianer.ArrCounters.Add(new Counter("Version", Software.GetPropertyValue("Version") == null ? "" : Software.GetPropertyValue("Version").ToString()));

                    if (Software.GetPropertyValue("LastUse") != null)
                    {
                        string DateStr = Software.GetPropertyValue("LastUse").ToString();
                        
                        SoftwareDataContianer.ArrCounters.Add(new Counter("LastUse", DateStr));
                    }

                    returnedReplyData.ArrDataContainers.Add(SoftwareDataContianer);
                }
                else
                { break; }

                ++Counter;
            }
            
            return returnedReplyData;
        }         
    }
}
