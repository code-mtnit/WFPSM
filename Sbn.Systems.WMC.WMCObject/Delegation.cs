using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
[Description("تفويض اختيار")]
[DisplayName ("تفويض اختيار")]
[ObjectCode ("2092")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Delegations")]
    [SystemName("WMC")]
[Serializable]
public class Delegation : SbnObject 
{
public Delegation() 
: base() 
{ 
} 
public Delegation(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _FromDate;
/// <summary>
/// تاریخ شروع
/// </summary>
[Description("تاریخ شروع")]
[DisplayName("تاریخ شروع")]
[Category("")]
[DocumentAttributeID("27021")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string FromDate
{
get { return _FromDate; }
set { _FromDate = value; }
}
private string _FinishDate;
/// <summary>
/// تاریخ اتمام
/// </summary>
[Description("تاریخ اتمام")]
[DisplayName("تاریخ اتمام")]
[Category("")]
[DocumentAttributeID("27022")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string FinishDate
{
get { return _FinishDate; }
set { _FinishDate = value; }
}
private WorkContext _CoWorkContext;
/// <summary>
/// زمینه کاری تفویض شده
/// </summary>
[Description("زمینه کاری تفویض شده")]
[DisplayName("زمینه کاری تفویض شده")]
[Category("")]
[DocumentAttributeID("27051")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WorkContext")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WorkContext CoWorkContext
{
get { return _CoWorkContext; }
set { _CoWorkContext = value; }
}
private Worker _FromWorker;
/// <summary>
/// کارمند تفویض کننده
/// </summary>
[Description("کارمند تفویض کننده")]
[DisplayName("کارمند تفویض کننده")]
[Category("")]
[DocumentAttributeID("27052")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Worker")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Worker FromWorker
{
get { return _FromWorker; }
set { _FromWorker = value; }
}
private Worker _DestWorker;
/// <summary>
/// کارمند مورد نظر
/// </summary>
[Description("کارمند مورد نظر")]
[DisplayName("کارمند مورد نظر")]
[Category("")]
[DocumentAttributeID("27053")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Worker")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Worker DestWorker
{
get { return _DestWorker; }
set { _DestWorker = value; }
}
private SbnBoolean _IsAccepted = SbnBoolean.OutOfValue;
/// <summary>
/// موافقت شده
/// </summary>
[Description("موافقت شده")]
[DisplayName("موافقت شده")]
[Category("")]
[DocumentAttributeID("27054")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean IsAccepted
{
get { return _IsAccepted; }
set { _IsAccepted = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._FromDate = "";
this._FinishDate = "";
this._CoWorkContext = new WorkContext() ;
this._FromWorker = new Worker() ;
this._DestWorker = new Worker() ;
this._IsAccepted = SbnBoolean.OutOfValue;
}
public override SbnObject Clone(string sNodeName)
{
Delegation retObject = new Delegation();
retObject.ID = this.ID;
if(this._FromDate != null)  retObject.FromDate = (string)this._FromDate.Clone();
if(this._FinishDate != null)  retObject.FinishDate = (string)this._FinishDate.Clone();
if (! object.ReferenceEquals( this.CoWorkContext , null))
retObject.CoWorkContext = (WorkContext)this.CoWorkContext.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.FromWorker , null))
retObject.FromWorker = (Worker)this.FromWorker.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.DestWorker , null))
retObject.DestWorker = (Worker)this.DestWorker.Clone(sNodeName) ;
retObject.IsAccepted = this.IsAccepted;
return retObject;
}
public static string at_FromDate
{
get
{
return "Delegation.FromDate";
}
}
public static string at_FinishDate
{
get
{
return "Delegation.FinishDate";
}
}
public static string at_CoWorkContextID
{
get
{
return "Delegation.CoWorkContextID";
}
}
public static string at_CoWorkContextFirstLevelAttributes
{
get
{
return "Delegation.CoWorkContextFirstLevelAttributes";
}
}
public static string at_CoWorkContext_CoUIFirstLevelAttributes
{
get
{
return "Delegation.CoWorkContext.CoUIFirstLevelAttributes";
}
}
public static string at_CoWorkContext_CoDocumentTypeFirstLevelAttributes
{
get
{
return "Delegation.CoWorkContext.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoWorkContext_CoOrganFirstLevelAttributes
{
get
{
return "Delegation.CoWorkContext.CoOrganFirstLevelAttributes";
}
}
public static string at_CoWorkContext_PictureFirstLevelAttributes
{
get
{
return "Delegation.CoWorkContext.PictureFirstLevelAttributes";
}
}
public static string at_FromWorkerID
{
get
{
return "Delegation.FromWorkerID";
}
}
public static string at_FromWorkerFirstLevelAttributes
{
get
{
return "Delegation.FromWorkerFirstLevelAttributes";
}
}
public static string at_FromWorker_CoPositionFirstLevelAttributes
{
get
{
return "Delegation.FromWorker.CoPositionFirstLevelAttributes";
}
}
public static string at_FromWorker_RestrictionsFirstLevelAttributes
{
get
{
return "Delegation.FromWorker.RestrictionsFirstLevelAttributes";
}
}
public static string at_FromWorker_CoPersonFirstLevelAttributes
{
get
{
return "Delegation.FromWorker.CoPersonFirstLevelAttributes";
}
}
public static string at_FromWorker_AccessrightsFirstLevelAttributes
{
get
{
return "Delegation.FromWorker.AccessrightsFirstLevelAttributes";
}
}
public static string at_FromWorker_WorkerJobFirstLevelAttributes
{
get
{
return "Delegation.FromWorker.WorkerJobFirstLevelAttributes";
}
}
public static string at_DestWorkerID
{
get
{
return "Delegation.DestWorkerID";
}
}
public static string at_DestWorkerFirstLevelAttributes
{
get
{
return "Delegation.DestWorkerFirstLevelAttributes";
}
}
public static string at_DestWorker_CoPositionFirstLevelAttributes
{
get
{
return "Delegation.DestWorker.CoPositionFirstLevelAttributes";
}
}
public static string at_DestWorker_RestrictionsFirstLevelAttributes
{
get
{
return "Delegation.DestWorker.RestrictionsFirstLevelAttributes";
}
}
public static string at_DestWorker_CoPersonFirstLevelAttributes
{
get
{
return "Delegation.DestWorker.CoPersonFirstLevelAttributes";
}
}
public static string at_DestWorker_AccessrightsFirstLevelAttributes
{
get
{
return "Delegation.DestWorker.AccessrightsFirstLevelAttributes";
}
}
public static string at_DestWorker_WorkerJobFirstLevelAttributes
{
get
{
return "Delegation.DestWorker.WorkerJobFirstLevelAttributes";
}
}
public static string at_IsAccepted
{
get
{
return "Delegation.IsAccepted";
}
}
}
}
