using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
[Description("نوع ويژگي سند")]
public enum PropertyType
{
BasicInfo = 1,
Number = 2,
Date = 3,
String = 4,
Formula = 5,
OrganPath = 6,
Enumeration = 7,
SbnObject = 8,
SbnListObject = 9 ,
Float = 10,
LongText = 11,
MultiSelect = 12,
OutOfValue=999
}
}
