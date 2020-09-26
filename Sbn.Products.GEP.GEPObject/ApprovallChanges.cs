using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
using Sbn.Core;
using Sbn.Systems.OPS;
using Sbn.Controls.Imaging;
using Sbn.Systems.WMC;
namespace Sbn.Products.GEP.GEPObject
{
[Description("")]
[DisplayName ("")]
[ItemsType ("Sbn.Products.GEP.GEPObject.ApprovallChange")]
[SystemName ("GEP")]
[Serializable]
public class ApprovallChanges : SbnListObject<ApprovallChange> 
{
#region Constructors
public ApprovallChanges()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
ApprovallChanges Col = new  ApprovallChanges ();
foreach (ApprovallChange objMember in this)
{
Col.Add((ApprovallChange)objMember.Clone(sNodeName));
}
return Col;
}
}
}
