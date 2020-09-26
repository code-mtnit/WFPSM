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
[ItemsType ("Sbn.Systems.WMC.WMCObject.Folder")]
[SystemName("WMC")]
[Serializable]
public class Folders : SbnListObject<Folder> 
{
#region Constructors
public Folders()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Folders Col = new  Folders ();
foreach (Folder objMember in this)
{
Col.Add((Folder)objMember.Clone(sNodeName));
}
return Col;
}
}
}
