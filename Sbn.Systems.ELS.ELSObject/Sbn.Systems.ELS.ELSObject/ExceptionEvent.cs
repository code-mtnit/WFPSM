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
[Description("رويداد خطا")]
[DisplayName ("رويداد خطا")]
    [ObjectCode("118")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.ExceptionEvents")]
    [SystemName("ELS")]

[Serializable]
public class ExceptionEvent : SbnObject 
{
public ExceptionEvent() 
: base() 
{ 
} 
public ExceptionEvent(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _message;
/// <summary>
/// پیغام خطا
/// </summary>
[Description("پیغام خطا")]
[DisplayName("پیغام خطا")]
[Category("")]
[DocumentAttributeID("52")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string message
{
get { return _message; }
set { _message = value; }
}
private string _StackTrace;
/// <summary>
/// مسیر وقوع خطا
/// </summary>
[Description("مسیر وقوع خطا")]
[DisplayName("مسیر وقوع خطا")]
[Category("")]
[DocumentAttributeID("53")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string StackTrace
{
get { return _StackTrace; }
set { _StackTrace = value; }
}
private long _RequestKey;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("سریال درخواست")]
[Category("")]
[DocumentAttributeID("11023")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long RequestKey
{
get { return _RequestKey; }
set { _RequestKey = value; }
}
private string _RegDate;
/// <summary>
/// زمان وقوع
/// </summary>
[Description("زمان وقوع")]
[DisplayName("زمان وقوع")]
[Category("")]
[DocumentAttributeID("104")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string RegDate
{
get { return _RegDate; }
set { _RegDate = value; }
}
private string _SystemName;
/// <summary>
/// نام سیستم محل بروز خطا
/// </summary>
[Description("نام سیستم محل بروز خطا")]
[DisplayName("زیر سیستم")]
[Category("")]
[DocumentAttributeID("11026")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string SystemName
{
get { return _SystemName; }
set { _SystemName = value; }
}
private ELSSession _CorrelateSession;
/// <summary>
/// سریال ورود
/// </summary>
[Description("سریال ورود")]
[DisplayName("سریال ورود")]
[Category("")]
[DocumentAttributeID("11005")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("ELSSession")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public ELSSession CorrelateSession
{
get { return _CorrelateSession; }
set { _CorrelateSession = value; }
}
private SubSystem _CoSubSystem;
/// <summary>
/// زیر سیستم مرتبط
/// </summary>
[Description("زیر سیستم مرتبط")]
[DisplayName("زیر سیستم مرتبط")]
[Category("")]
[DocumentAttributeID("11017")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SubSystem")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SubSystem CoSubSystem
{
get { return _CoSubSystem; }
set { _CoSubSystem = value; }
}
public override string ToString()
{
return this.message;
}
public override void Initialize()
{
base.Initialize();
this._message =  "";
this._StackTrace =  "";
this._RequestKey = 0;
this._RegDate = "";
this._SystemName =  "";
this._CorrelateSession = new ELSSession() ;
this._CoSubSystem = new SubSystem() ;
}
public override SbnObject Clone(string sNodeName)
{
ExceptionEvent retObject = new ExceptionEvent();
retObject.ID = this.ID;
retObject.message = this._message;
retObject.StackTrace = this._StackTrace;
retObject.RequestKey = this._RequestKey;
if(this._RegDate != null)  retObject.RegDate = (string)this._RegDate.Clone();
retObject.SystemName = this._SystemName;
if (! object.ReferenceEquals( this.CorrelateSession , null))
retObject.CorrelateSession = (ELSSession)this.CorrelateSession.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoSubSystem , null))
retObject.CoSubSystem = (SubSystem)this.CoSubSystem.Clone(sNodeName) ;
return retObject;
}
public static string at_message
{
get
{
return "ExceptionEvent.message";
}
}
public static string at_StackTrace
{
get
{
return "ExceptionEvent.StackTrace";
}
}
public static string at_RequestKey
{
get
{
return "ExceptionEvent.RequestKey";
}
}
public static string at_RegDate
{
get
{
return "ExceptionEvent.RegDate";
}
}
public static string at_SystemName
{
get
{
return "ExceptionEvent.SystemName";
}
}
public static string at_CorrelateSessionID
{
get
{
return "ExceptionEvent.CorrelateSessionID";
}
}
public static string at_CorrelateSessionFirstLevelAttributes
{
get
{
return "ExceptionEvent.CorrelateSessionFirstLevelAttributes";
}
}
public static string at_CorrelateSession_UserFirstLevelAttributes
{
get
{
return "ExceptionEvent.CorrelateSession.UserFirstLevelAttributes";
}
}
public static string at_CoSubSystemID
{
get
{
return "ExceptionEvent.CoSubSystemID";
}
}
public static string at_CoSubSystemFirstLevelAttributes
{
get
{
return "ExceptionEvent.CoSubSystemFirstLevelAttributes";
}
}
}
}
