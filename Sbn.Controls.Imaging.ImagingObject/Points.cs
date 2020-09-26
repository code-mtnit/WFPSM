using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using MSXML2;
using Sbn.Core;
namespace Sbn.Controls.Imaging.ImagingObject
{
[Description("")]
[DisplayName ("")]
[ItemsType ("Sbn.Controls.Imaging.ImagingObject.Point")]
[Serializable]
public class Points : SbnListObject<Point> 
{
#region Constructors
public Points()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Points Col = new  Points ();
foreach (Point objMember in this)
{
Col.Add((Point)objMember.Clone(sNodeName));
}
return Col;
}
}
}
