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
[Description("يك عنصر در لايه")]
[DisplayName ("يك عنصر در لايه")]
[ObjectCode ("20")]
[Serializable]
public class Element : SbnBinary 
{
public Element() 
: base() 
{ 
} 
public Element(SbnBinary InitialObject) 
: base(InitialObject) 
{ 
} 
private long _LocationX;
/// <summary>
/// موقعیت در محور افقی
/// </summary>
[Description("موقعیت در محور افقی")]
[DisplayName("موقعیت در محور افقی")]
[Category("")]
[DocumentAttributeID("34")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long LocationX
{
get { return _LocationX; }
set { _LocationX = value; }
}
private long _LocationY;
/// <summary>
/// موقعیت در محور عمودی
/// </summary>
[Description("موقعیت در محور عمودی")]
[DisplayName("موقعیت در محور عمودی")]
[Category("")]
[DocumentAttributeID("35")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long LocationY
{
get { return _LocationY; }
set { _LocationY = value; }
}
private int _Width;
/// <summary>
/// عرض
/// </summary>
[Description("عرض")]
[DisplayName("عرض")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("6000")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int Width
{
get { return _Width; }
set { _Width = value; }
}
private int _Height;
/// <summary>
/// طول
/// </summary>
[Description("طول")]
[DisplayName("طول")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("6001")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int Height
{
get { return _Height; }
set { _Height = value; }
}
private int _OrderInLayer;
/// <summary>
/// ترتیب نمایش در لایه
/// </summary>
[Description("ترتیب نمایش در لایه")]
[DisplayName("ترتیب نمایش")]
[Category("")]
[DocumentAttributeID("6003")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int OrderInLayer
{
get { return _OrderInLayer; }
set { _OrderInLayer = value; }
}
private ElementType _elementType = ElementType.OutOfValue;
/// <summary>
/// نوع عنصر
/// </summary>
[Description("نوع عنصر")]
[DisplayName("نوع عنصر")]
[Category("")]
[DocumentAttributeID("6")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("ElementType")]
[IsMiddleTableExist("False")]
public ElementType elementType
{
get { return _elementType; }
set { _elementType = value; }
}
private Layer _parentLayer;
/// <summary>
/// لایه مرتبط
/// </summary>
[Description("لایه مرتبط")]
[DisplayName("لایه مرتبط")]
[Category("")]
[DocumentAttributeID("7")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Layer")]
[IsMiddleTableExist("False")]
public Layer parentLayer
{
get { return _parentLayer; }
set { _parentLayer = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._LocationX = 0;
this._LocationY = 0;
this._Width = 0;
this._Height = 0;
this._OrderInLayer = 0;
this._elementType = ElementType.OutOfValue;
this._parentLayer = new Layer() ;
}
public override SbnObject Clone(string sNodeName)
{
Element retObject = new Element();
retObject.ID = this.ID;
retObject.LocationX = this._LocationX;
retObject.LocationY = this._LocationY;
retObject.Width = this._Width;
retObject.Height = this._Height;
retObject.OrderInLayer = this._OrderInLayer;
retObject.elementType = this.elementType;
if (! object.ReferenceEquals( this.parentLayer , null))
retObject.parentLayer = (Layer)this.parentLayer.Clone(sNodeName) ;
return retObject;
}
public static string at_LocationX
{
get
{
return "Element.LocationX";
}
}
public static string at_LocationY
{
get
{
return "Element.LocationY";
}
}
public static string at_Width
{
get
{
return "Element.Width";
}
}
public static string at_Height
{
get
{
return "Element.Height";
}
}
public static string at_OrderInLayer
{
get
{
return "Element.OrderInLayer";
}
}
public static string at_elementType
{
get
{
return "Element.elementType";
}
}
public static string at_parentLayerID
{
get
{
return "Element.parentLayerID";
}
}
public static string at_parentLayerMainCategory
{
get
{
return "Element.parentLayerMainCategory";
}
}
public static string at_parentLayer_elementsFirstLevelAttributes
{
get
{
return "Element.parentLayer.elementsFirstLevelAttributes";
}
}
}
}
