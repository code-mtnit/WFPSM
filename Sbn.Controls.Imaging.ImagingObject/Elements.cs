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
[ItemsType ("Sbn.Controls.Imaging.ImagingObject.Element")]
[Serializable]
public class Elements : SbnListObject<Element> 
{
#region Constructors
public Elements()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Elements Col = new  Elements ();
foreach (Element objMember in this)
{
Col.Add((Element)objMember.Clone(sNodeName));
}
return Col;
}
}
}
