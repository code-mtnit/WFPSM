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
[Description("رويداد ورود به سيستم")]
[DisplayName ("رويداد ورود به سيستم")]
[ObjectCode ("121")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.ELSSessions")]
    [SystemName("ELS")]
[Serializable]
public class ELSSession : SbnObject 
{
public ELSSession() 
: base() 
{ 
} 
public ELSSession(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _IPAddress;
/// <summary>
/// آدرس دستگاه
/// </summary>
[Description("آدرس دستگاه")]
[DisplayName("آدرس دستگاه")]
[Category("")]
[DocumentAttributeID("11032")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string IPAddress
{
get { return _IPAddress; }
set { _IPAddress = value; }
}
private string _RegDate;
/// <summary>
/// زمان ورود
/// </summary>
[Description("زمان ورود")]
[DisplayName("زمان ورود")]
[Category("")]
[DocumentAttributeID("103")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string RegDate
{
get { return _RegDate; }
set { _RegDate = value; }
}
private string _EndDate;
/// <summary>
/// زمان خروج
/// </summary>
[Description("زمان خروج")]
[DisplayName("زمان خروج")]
[Category("")]
[DocumentAttributeID("11031")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string EndDate
{
get { return _EndDate; }
set { _EndDate = value; }
}
private string _MACAddress;
/// <summary>
/// آدرس کارت شبکه
/// </summary>
[Description("آدرس کارت شبکه")]
[DisplayName("آدرس کارت شبکه")]
[Category("")]
[DocumentAttributeID("27163")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string MACAddress
{
get { return _MACAddress; }
set { _MACAddress = value; }
}
private SysUser _User;
/// <summary>
/// کاربر سیستم
/// </summary>
[Description("کاربر سیستم")]
[DisplayName("کاربر")]
[Category("")]
[DocumentAttributeID("11004")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SysUser")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SysUser User
{
get { return _User; }
set { _User = value; }
}
public override string ToString()
{
return this.RegDate + "-" + this.ID.ToString();
}
public override void Initialize()
{
base.Initialize();
this._IPAddress =  "";
this._RegDate = "";
this._EndDate = "";
this._MACAddress =  "";
this._User = new SysUser() ;
}
public override SbnObject Clone(string sNodeName)
{
ELSSession retObject = new ELSSession();
retObject.ID = this.ID;
retObject.IPAddress = this._IPAddress;
if(this._RegDate != null)  retObject.RegDate = (string)this._RegDate.Clone();
if(this._EndDate != null)  retObject.EndDate = (string)this._EndDate.Clone();
retObject.MACAddress = this._MACAddress;
if (! object.ReferenceEquals( this.User , null))
retObject.User = (SysUser)this.User.Clone(sNodeName) ;
return retObject;
}
public static string at_IPAddress
{
get
{
return "ELSSession.IPAddress";
}
}
public static string at_RegDate
{
get
{
return "ELSSession.RegDate";
}
}
public static string at_EndDate
{
get
{
return "ELSSession.EndDate";
}
}
public static string at_MACAddress
{
get
{
return "ELSSession.MACAddress";
}
}
public static string at_UserID
{
get
{
return "ELSSession.UserID";
}
}
public static string at_UserFirstLevelAttributes
{
get
{
return "ELSSession.UserFirstLevelAttributes";
}
}
}
}
