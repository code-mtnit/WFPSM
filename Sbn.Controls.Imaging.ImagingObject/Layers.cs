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
[ItemsType ("Sbn.Controls.Imaging.ImagingObject.Layer")]
[Serializable]
public class Layers : SbnListObject<Layer> 
{
#region Constructors
public Layers()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Layers Col = new  Layers ();
foreach (Layer objMember in this)
{
Col.Add((Layer)objMember.Clone(sNodeName));
}
return Col;
}
}
}
