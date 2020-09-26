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
[ItemsType ("Sbn.Controls.Imaging.ImagingObject.ImageDocument")]
[Serializable]
public class ImageDocuments : SbnListObject<ImageDocument> 
{
#region Constructors
public ImageDocuments()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
ImageDocuments Col = new  ImageDocuments ();
foreach (ImageDocument objMember in this)
{
Col.Add((ImageDocument)objMember.Clone(sNodeName));
}
return Col;
}
}
}
