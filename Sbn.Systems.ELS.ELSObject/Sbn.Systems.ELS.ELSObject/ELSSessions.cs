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
[Description("")]
[DisplayName ("")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.ELSSession")]
    [SystemName("ELS")]

[Serializable]
public class ELSSessions : SbnListObject<ELSSession> 
{
#region Constructors
public ELSSessions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
ELSSessions Col = new  ELSSessions ();
foreach (ELSSession objMember in this)
{
Col.Add((ELSSession)objMember.Clone(sNodeName));
}
return Col;
}
}
}
