using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
[Description("وضعيت فعاليت")]
public enum ActivityActionType
{
None = 0,
Finished = 1,
Sended = 2,
Rejected = 3,
    Suspended = 4,
    FinishedWithNoAction = 5,
    ReadyForSend = 6,
OutOfValue=999
}
}
