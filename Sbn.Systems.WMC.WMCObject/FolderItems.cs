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
[DisplayName ("")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.FolderItem")]
    [SystemName("WMC")]

[Serializable]
public class FolderItems : SbnListObject<FolderItem> 
{
#region Constructors
public FolderItems()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
FolderItems Col = new  FolderItems ();
foreach (FolderItem objMember in this)
{
Col.Add((FolderItem)objMember.Clone(sNodeName));
}
return Col;
}
}
}
