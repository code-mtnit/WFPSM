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
[Description("محدوديت دسترسي مالكيت كارمند")]
[DisplayName ("محدوديت دسترسي مالكيت كارمند")]
[ObjectCode ("2108")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkerDomainRestrictions")]
    [SystemName("WMC")]
[Serializable]
public class WorkerDomainRestriction : SbnObject 
{
public WorkerDomainRestriction() 
: base() 
{ 
} 
public WorkerDomainRestriction(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private SbnOwnershipDomain _DomainType = SbnOwnershipDomain.OutOfValue;
/// <summary>
/// نوع مالکیت
/// </summary>
[Description("نوع مالکیت")]
[DisplayName("نوع مالکیت")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27138")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnOwnershipDomain")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnOwnershipDomain DomainType
{
get { return _DomainType; }
set { _DomainType = value; }
}
private SbnBoolean _RegisterAcc = SbnBoolean.OutOfValue;
/// <summary>
/// ثبت
/// </summary>
[Description("ثبت")]
[DisplayName("ثبت")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27130")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean RegisterAcc
{
get { return _RegisterAcc; }
set { _RegisterAcc = value; }
}
private SbnBoolean _UpdateAcc = SbnBoolean.OutOfValue;
/// <summary>
/// ویرایش
/// </summary>
[Description("ویرایش")]
[DisplayName("ویرایش")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27131")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean UpdateAcc
{
get { return _UpdateAcc; }
set { _UpdateAcc = value; }
}
private SbnBoolean _RemoveAcc = SbnBoolean.OutOfValue;
/// <summary>
/// حذف
/// </summary>
[Description("حذف")]
[DisplayName("حذف")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27132")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean RemoveAcc
{
get { return _RemoveAcc; }
set { _RemoveAcc = value; }
}
private SbnBoolean _ViewAcc = SbnBoolean.OutOfValue;
/// <summary>
/// مشاهده
/// </summary>
[Description("مشاهده")]
[DisplayName("مشاهده")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27133")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean ViewAcc
{
get { return _ViewAcc; }
set { _ViewAcc = value; }
}
private DocumentType _CoDocumentType;
/// <summary>
/// سند مرتبط
/// </summary>
[Description("سند مرتبط")]
[DisplayName("سند مرتبط")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27134")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentType")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentType CoDocumentType
{
get { return _CoDocumentType; }
set { _CoDocumentType = value; }
}
private Worker _CoWorker;
/// <summary>
/// کارمند مرتبط
/// </summary>
[Description("کارمند مرتبط")]
[DisplayName("کارمند مرتبط")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27135")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Worker")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Worker CoWorker
{
get { return _CoWorker; }
set { _CoWorker = value; }
}
private OrgUnit _CoOrgUnit;
/// <summary>
/// ساختار مرتبط
/// </summary>
[Description("ساختار مرتبط")]
[DisplayName("ساختار مرتبط")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27139")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("OrgUnit")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public OrgUnit CoOrgUnit
{
get { return _CoOrgUnit; }
set { _CoOrgUnit = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._DomainType = SbnOwnershipDomain.OutOfValue;
this._RegisterAcc = SbnBoolean.OutOfValue;
this._UpdateAcc = SbnBoolean.OutOfValue;
this._RemoveAcc = SbnBoolean.OutOfValue;
this._ViewAcc = SbnBoolean.OutOfValue;
this._CoDocumentType = new DocumentType() ;
this._CoWorker = new Worker() ;
this._CoOrgUnit = new OrgUnit() ;
}
public override SbnObject Clone(string sNodeName)
{
WorkerDomainRestriction retObject = new WorkerDomainRestriction();
retObject.ID = this.ID;
retObject.DomainType = this.DomainType;
retObject.RegisterAcc = this.RegisterAcc;
retObject.UpdateAcc = this.UpdateAcc;
retObject.RemoveAcc = this.RemoveAcc;
retObject.ViewAcc = this.ViewAcc;
if (! object.ReferenceEquals( this.CoDocumentType , null))
retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoWorker , null))
retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoOrgUnit , null))
retObject.CoOrgUnit = (OrgUnit)this.CoOrgUnit.Clone(sNodeName) ;
return retObject;
}
public static string at_DomainType
{
get
{
return "WorkerDomainRestriction.DomainType";
}
}
public static string at_RegisterAcc
{
get
{
return "WorkerDomainRestriction.RegisterAcc";
}
}
public static string at_UpdateAcc
{
get
{
return "WorkerDomainRestriction.UpdateAcc";
}
}
public static string at_RemoveAcc
{
get
{
return "WorkerDomainRestriction.RemoveAcc";
}
}
public static string at_ViewAcc
{
get
{
return "WorkerDomainRestriction.ViewAcc";
}
}
public static string at_CoDocumentTypeID
{
get
{
return "WorkerDomainRestriction.CoDocumentTypeID";
}
}
public static string at_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoDocumentType_PictureFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoDocumentType.PictureFirstLevelAttributes";
}
}
public static string at_CoDocumentType_PropertiesFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoDocumentType.PropertiesFirstLevelAttributes";
}
}
public static string at_CoDocumentType_SubSystemFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoDocumentType.SubSystemFirstLevelAttributes";
}
}
public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoDocumentType.CoDefaultUIFirstLevelAttributes";
}
}
public static string at_CoWorkerID
{
get
{
return "WorkerDomainRestriction.CoWorkerID";
}
}
public static string at_CoWorkerFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoWorkerFirstLevelAttributes";
}
}
public static string at_CoWorker_CoPositionFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoWorker.CoPositionFirstLevelAttributes";
}
}
public static string at_CoWorker_RestrictionsFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoWorker.RestrictionsFirstLevelAttributes";
}
}
public static string at_CoWorker_CoPersonFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoWorker.CoPersonFirstLevelAttributes";
}
}
public static string at_CoWorker_AccessrightsFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoWorker.AccessrightsFirstLevelAttributes";
}
}
public static string at_CoWorker_WorkerJobFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoWorker.WorkerJobFirstLevelAttributes";
}
}
public static string at_CoOrgUnitID
{
get
{
return "WorkerDomainRestriction.CoOrgUnitID";
}
}
public static string at_CoOrgUnitFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoOrgUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_BuildingLocationFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoOrgUnit.BuildingLocationFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoOrgUnit.ChildUnitsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoOrgUnit.ParentUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_PositionsFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoOrgUnit.PositionsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_MergedUnitFirstLevelAttributes
{
get
{
return "WorkerDomainRestriction.CoOrgUnit.MergedUnitFirstLevelAttributes";
}
}
}
}
