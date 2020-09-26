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
[Description("محدوديت كارمند بر اساس ويژگي سند كه در گردش كار مورد توجه قرار مي گيرد")]
[DisplayName ("محدوديت كارمند بر اساس ويژگي سند كه در گردش كار مورد توجه قرار مي گيرد")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkerRestrictions")]
    [ObjectCode("2019")]
[SystemName ("WMC")]
[Serializable]
public class WorkerRestriction : SbnObject 
{
public WorkerRestriction() 
: base() 
{ 
} 
public WorkerRestriction(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _AssignedValue;
/// <summary>
/// مقدارویژگی که براساس آن محدودیتهای کاربر بررسی می شود.
/// </summary>
[Description("مقدارویژگی که براساس آن محدودیتهای کاربر بررسی می شود.")]
[DisplayName("مقدار ویژگی")]
[Category("")]
[DocumentAttributeID("27020")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string AssignedValue
{
get { return _AssignedValue; }
set { _AssignedValue = value; }
}
private Worker _CoWorker;
/// <summary>
/// کارمند مرتبط
/// </summary>
[Description("کارمند مرتبط")]
[DisplayName("کارمند مرتبط")]
[Category("")]
[DocumentAttributeID("2036")]
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
private SbnBoolean _PrintAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2044")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean PrintAcc
{
get { return _PrintAcc; }
set { _PrintAcc = value; }
}
private SbnBoolean _ViewAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2045")]
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
private SbnBoolean _RegisterAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2046")]
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
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2047")]
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
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2048")]
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
private DocumentProperty _CoProperty;
/// <summary>
/// ویژگی مرتبط
/// </summary>
[Description("ویژگی مرتبط")]
[DisplayName("ویژگی مرتبط")]
[Category("")]
[DocumentAttributeID("2049")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentProperty")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentProperty CoProperty
{
get { return _CoProperty; }
set { _CoProperty = value; }
}
private DocumentType _CoDocument;
/// <summary>
/// نوع سند مرتبط
/// </summary>
[Description("نوع سند مرتبط")]
[DisplayName("نوع سند مرتبط")]
[Category("")]
[DocumentAttributeID("2050")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentType")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentType CoDocument
{
get { return _CoDocument; }
set { _CoDocument = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._AssignedValue =  "";
this._CoWorker = new Worker() ;
this._PrintAcc = SbnBoolean.OutOfValue;
this._ViewAcc = SbnBoolean.OutOfValue;
this._RegisterAcc = SbnBoolean.OutOfValue;
this._UpdateAcc = SbnBoolean.OutOfValue;
this._RemoveAcc = SbnBoolean.OutOfValue;
this._CoProperty = new DocumentProperty() ;
this._CoDocument = new DocumentType() ;
}
public override SbnObject Clone(string sNodeName)
{
WorkerRestriction retObject = new WorkerRestriction();
retObject.ID = this.ID;
retObject.AssignedValue = this._AssignedValue;
if (! object.ReferenceEquals( this.CoWorker , null))
retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName) ;
retObject.PrintAcc = this.PrintAcc;
retObject.ViewAcc = this.ViewAcc;
retObject.RegisterAcc = this.RegisterAcc;
retObject.UpdateAcc = this.UpdateAcc;
retObject.RemoveAcc = this.RemoveAcc;
if (! object.ReferenceEquals( this.CoProperty , null))
retObject.CoProperty = (DocumentProperty)this.CoProperty.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoDocument , null))
retObject.CoDocument = (DocumentType)this.CoDocument.Clone(sNodeName) ;
return retObject;
}
public static string at_AssignedValue
{
get
{
return "WorkerRestriction.AssignedValue";
}
}
public static string at_CoWorkerID
{
get
{
return "WorkerRestriction.CoWorkerID";
}
}
public static string at_CoWorkerFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoWorkerFirstLevelAttributes";
}
}
public static string at_CoWorker_CoPositionFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoWorker.CoPositionFirstLevelAttributes";
}
}
public static string at_CoWorker_RestrictionsFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoWorker.RestrictionsFirstLevelAttributes";
}
}
public static string at_CoWorker_CoPersonFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoWorker.CoPersonFirstLevelAttributes";
}
}
public static string at_CoWorker_AccessrightsFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoWorker.AccessrightsFirstLevelAttributes";
}
}
public static string at_CoWorker_WorkerJobFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoWorker.WorkerJobFirstLevelAttributes";
}
}
public static string at_PrintAcc
{
get
{
return "WorkerRestriction.PrintAcc";
}
}
public static string at_ViewAcc
{
get
{
return "WorkerRestriction.ViewAcc";
}
}
public static string at_RegisterAcc
{
get
{
return "WorkerRestriction.RegisterAcc";
}
}
public static string at_UpdateAcc
{
get
{
return "WorkerRestriction.UpdateAcc";
}
}
public static string at_RemoveAcc
{
get
{
return "WorkerRestriction.RemoveAcc";
}
}
public static string at_CoPropertyID
{
get
{
return "WorkerRestriction.CoPropertyID";
}
}
public static string at_CoPropertyFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoPropertyFirstLevelAttributes";
}
}
public static string at_CoProperty_BasicInfoLinkFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoProperty.BasicInfoLinkFirstLevelAttributes";
}
}
public static string at_CoProperty_MesurementTypeFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoProperty.MesurementTypeFirstLevelAttributes";
}
}
public static string at_CoProperty_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoProperty.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoProperty_ValuesFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoProperty.ValuesFirstLevelAttributes";
}
}
public static string at_CoProperty_ReferenceDocumentTypeFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoProperty.ReferenceDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoDocumentID
{
get
{
return "WorkerRestriction.CoDocumentID";
}
}
public static string at_CoDocumentFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoDocumentFirstLevelAttributes";
}
}
public static string at_CoDocument_PictureFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoDocument.PictureFirstLevelAttributes";
}
}
public static string at_CoDocument_PropertiesFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoDocument.PropertiesFirstLevelAttributes";
}
}
public static string at_CoDocument_SubSystemFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoDocument.SubSystemFirstLevelAttributes";
}
}
public static string at_CoDocument_CoDefaultUIFirstLevelAttributes
{
get
{
return "WorkerRestriction.CoDocument.CoDefaultUIFirstLevelAttributes";
}
}
}
}
