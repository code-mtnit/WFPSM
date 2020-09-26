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
[Description("")]
public enum FolderCategoryType
{
    Task = 1,
    Activity = 2,
    Program = 3,
    Document = 4,
    File = 5,
    Message = 6,
    Report = 7,
    WorkContext = 8,
    G2GService = 9,
    OutOfValue = 999
}
}
