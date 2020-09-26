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
[Description("يك لايه از مستند تصويري")]
[DisplayName ("يك لايه از مستند تصويري")]
[ObjectCode ("24")]
[Serializable]
public class Layer : SbnObject 
{
public Layer() 
: base() 
{ 
} 
public Layer(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _Title;
/// <summary>
/// عنوان
/// </summary>
[Description("عنوان")]
[DisplayName("عنوان")]
[Category("")]
[DocumentAttributeID("6006")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Title
{
get { return _Title; }
set { _Title = value; }
}
private int _OrderInImageDoc;
/// <summary>
/// ترتیب نمایش در تصویر
/// </summary>
[Description("ترتیب نمایش در تصویر")]
[DisplayName("ترتیب نمایش")]
[Category("")]
[DocumentAttributeID("6002")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int OrderInImageDoc
{
get { return _OrderInImageDoc; }
set { _OrderInImageDoc = value; }
}
private Elements _elements;
/// <summary>
/// عناصر
/// </summary>
[Description("عناصر")]
[DisplayName("عناصر")]
[Category("")]
[DocumentAttributeID("8")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Elements")]
public Elements elements
{
get { return _elements; }
set { _elements = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Title =  "";
this._OrderInImageDoc = 0;
this._elements = new Elements() ;
}
public override SbnObject Clone(string sNodeName)
{
Layer retObject = new Layer();
retObject.ID = this.ID;
retObject.Title = this._Title;
retObject.OrderInImageDoc = this._OrderInImageDoc;
if (! object.ReferenceEquals( this.elements , null))
retObject.elements = (Elements)this.elements.Clone(sNodeName) ;
return retObject;
}
public static string at_Title
{
get
{
return "Layer.Title";
}
}
public static string at_OrderInImageDoc
{
get
{
return "Layer.OrderInImageDoc";
}
}
public static string at_elementsID
{
get
{
return "Layer.elementsID";
}
}
public static string at_elementsMainCategory
{
get
{
return "Layer.elementsMainCategory";
}
}
}
}
