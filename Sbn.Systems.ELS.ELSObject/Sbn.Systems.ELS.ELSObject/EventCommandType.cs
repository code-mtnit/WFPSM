using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
namespace Sbn.Systems.ELS.ELSObject
{
[Description("نوع رويداد سطح پايين")]
public enum EventCommandType
{
Register = 1,
Update = 2,
Remove = 3,
Get = 4,
CustomCommand = 5,
AddSubDocToDocument = 6,
RemoveSubDocFromDocument = 7,
    Report = 8 , 
    Print = 9 , 
    Filter = 10,
OutOfValue=999
}
}
