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
[ItemsType ("Sbn.Systems.WMC.WMCObject.FolderAccessright")]
[SystemName ("WMC")]
[Serializable]
public class FolderAccessrights : SbnListObject<FolderAccessright> 
{
#region Constructors
public FolderAccessrights()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
FolderAccessrights Col = new  FolderAccessrights ();
foreach (FolderAccessright objMember in this)
{
Col.Add((FolderAccessright)objMember.Clone(sNodeName));
}
return Col;
}
}
}
