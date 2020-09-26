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
[Description("نوع مرحله يا مقطع در فرايند")]
public enum WFPlaceType
{
Starter = 1,
Terminator = 2,
OutOfValue=999
}
}
