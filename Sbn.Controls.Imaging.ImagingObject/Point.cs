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
[Description("اطلاعات موقعيت نقطه")]
[DisplayName ("اطلاعات موقعيت نقطه")]
[ObjectCode ("17")]
[Serializable]
public class Point : SbnObject 
{
public Point() 
: base() 
{ 
} 
public Point(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private long _XPos;
/// <summary>
/// موقعیت در محور افقی
/// </summary>
[Description("موقعیت در محور افقی")]
[DisplayName("موقعیت در محور افقی")]
[Category("")]
[DocumentAttributeID("6004")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long XPos
{
get { return _XPos; }
set { _XPos = value; }
}
private long _YPos;
/// <summary>
/// موقعیت در محور عمودی
/// </summary>
[Description("موقعیت در محور عمودی")]
[DisplayName("موقعیت در محور عمودی")]
[Category("")]
[DocumentAttributeID("6005")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long YPos
{
get { return _YPos; }
set { _YPos = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._XPos = 0;
this._YPos = 0;
}
public override SbnObject Clone(string sNodeName)
{
Point retObject = new Point();
retObject.ID = this.ID;
retObject.XPos = this._XPos;
retObject.YPos = this._YPos;
return retObject;
}
public static string at_XPos
{
get
{
return "Point.XPos";
}
}
public static string at_YPos
{
get
{
return "Point.YPos";
}
}
}
}
