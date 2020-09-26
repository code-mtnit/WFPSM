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
[Description("وضعيت وظيفه كه آخرين نفر در گردش كار آن را اتمام ميكند")]
public enum TaskStatus
{
None = 0,
Finished = 1,
ActiveInOrgan = 2,
OutOfValue=999
}
}
