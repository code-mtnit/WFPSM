using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
using Sbn.Core;
namespace Sbn.Controls.Imaging.ImagingObject
{
[Description("مستند تصويري")]
[DisplayName ("مستند تصويري")]
[ObjectCode ("19")]
[Serializable]
public class ImageDocument : SbnBinary 
{
public ImageDocument() 
: base() 
{
    //this.Uid = Guid.NewGuid();
} 
public ImageDocument(SbnBinary InitialObject) 
: base(InitialObject) 
{ 
} 
private int _OrderInDocument;
/// <summary>
/// ترتیب در سند
/// </summary>
[Description("ترتیب در سند")]
[DisplayName("ترتیب در سند")]
[Category("")]
[DocumentAttributeID("32")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int OrderInDocument
{
get { return _OrderInDocument; }
set { _OrderInDocument = value; }
}
private byte[] _ThumbnailStream;
/// <summary>
/// تصویر کوچک
/// </summary>
[Description("تصویر کوچک")]
[DisplayName("تصویر کوچک")]
[Category("")]
[DocumentAttributeID("20")]
[IsRelationalAttribute("false")]
[AttributeType("Binary")]
[Browsable(true)]
public byte[] ThumbnailStream
{
get { return _ThumbnailStream; }
set { _ThumbnailStream = value; }
}
private int _Height;
/// <summary>
/// طول
/// </summary>
[Description("طول")]
[DisplayName("طول")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27123")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int Height
{
get { return _Height; }
set { _Height = value; }
}
private int _Width;
/// <summary>
/// عرض
/// </summary>
[Description("عرض")]
[DisplayName("عرض")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27124")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int Width
{
get { return _Width; }
set { _Width = value; }
}
private Layers _layers;
/// <summary>
/// لایه ها
/// </summary>
[Description("لایه ها")]
[DisplayName("لایه ها")]
[Category("")]
[DocumentAttributeID("3")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Layers")]
[IsMiddleTableExist("False")]
public Layers layers
{
get { return _layers; }
set { _layers = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._OrderInDocument = 0;
this._ThumbnailStream=  new byte[1];
this._Height = 0;
this._Width = 0;
this._layers = new Layers() ;
}
public override SbnObject Clone(string sNodeName)
{
ImageDocument retObject = new ImageDocument();
retObject.ID = this.ID;
retObject.OrderInDocument = this._OrderInDocument;
if(this._ThumbnailStream != null) retObject.ThumbnailStream = (byte[]) this._ThumbnailStream.Clone();
retObject.Height = this._Height;
retObject.Width = this._Width;
if (! object.ReferenceEquals( this.layers , null))
retObject.layers = (Layers)this.layers.Clone(sNodeName) ;
return retObject;
}
public static string at_OrderInDocument
{
get
{
return "ImageDocument.OrderInDocument";
}
}
public static string at_ThumbnailStream
{
get
{
return "ImageDocument.ThumbnailStream";
}
}
public static string at_Height
{
get
{
return "ImageDocument.Height";
}
}
public static string at_Width
{
get
{
return "ImageDocument.Width";
}
}
public static string at_layersID
{
get
{
return "ImageDocument.layersID";
}
}
public static string at_layersMainCategory
{
get
{
return "ImageDocument.layersMainCategory";
}
}
}
}
