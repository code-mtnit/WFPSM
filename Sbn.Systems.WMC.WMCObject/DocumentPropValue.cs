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
[Description("مقادير ويژگي انتخاب شده براي سند در حال گردش در سازمان")]
[DisplayName ("مقادير ويژگي انتخاب شده براي سند در حال گردش در سازمان")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.DocumentPropValues")]
    [ObjectCode("2030")]
[SystemName ("WMC")]
[Serializable]
public class DocumentPropValue : SbnObject 
{
public DocumentPropValue() 
: base() 
{ 
} 
public DocumentPropValue(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _AssignedValue;
/// <summary>
/// مقدار ویژگی سند در زیر سیستم
/// </summary>
[Description("مقدار ویژگی سند در زیر سیستم")]
[DisplayName("مقدار ویژگی سند")]
[Category("")]
[DocumentAttributeID("2012")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string AssignedValue
{
get { return _AssignedValue; }
set { _AssignedValue = value; }
}
private string _AssignedValueDate;
/// <summary>
/// زمان تخصیص مقدار
/// </summary>
[Description("زمان تخصیص مقدار")]
[DisplayName("زمان ویرایش")]
[Category("")]
[DocumentAttributeID("2047")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string AssignedValueDate
{
get { return _AssignedValueDate; }
set { _AssignedValueDate = value; }
}
private DocumentProperty _CorrelateProperty;
/// <summary>
/// ویژگی مرتبط
/// </summary>
[Description("ویژگی مرتبط")]
[DisplayName("ویژگی")]
[Category("")]
[DocumentAttributeID("2020")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentProperty")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentProperty CorrelateProperty
{
get { return _CorrelateProperty; }
set { _CorrelateProperty = value; }
}
private DocumentType _DocumentType;
/// <summary>
/// نوع سند
/// </summary>
[Description("نوع سند")]
[DisplayName("نوع سند")]
[Category("")]
[DocumentAttributeID("2021")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentType")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentType DocumentType
{
get { return _DocumentType; }
set { _DocumentType = value; }
}
private Document _CorrelateDocument;
/// <summary>
/// سند مرتبط
/// </summary>
[Description("سند مرتبط")]
[DisplayName("سند مرتبط")]
[Category("")]
[DocumentAttributeID("2108")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Document")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Document CorrelateDocument
{
get { return _CorrelateDocument; }
set { _CorrelateDocument = value; }
}
private Worker _EditorWorker;
/// <summary>
/// کارمند ویرایشگر
/// </summary>
[Description("کارمند ویرایشگر")]
[DisplayName("کارمند")]
[Category("")]
[DocumentAttributeID("2116")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Worker")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Worker EditorWorker
{
get { return _EditorWorker; }
set { _EditorWorker = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._AssignedValue =  "";
this._AssignedValueDate = "";
this._CorrelateProperty = new DocumentProperty() ;
this._DocumentType = new DocumentType() ;
this._CorrelateDocument = new Document() ;
this._EditorWorker = new Worker() ;
}
public override SbnObject Clone(string sNodeName)
{
DocumentPropValue retObject = new DocumentPropValue();
retObject.ID = this.ID;
retObject.AssignedValue = this._AssignedValue;
if(this._AssignedValueDate != null)  retObject.AssignedValueDate = (string)this._AssignedValueDate.Clone();
if (! object.ReferenceEquals( this.CorrelateProperty , null))
retObject.CorrelateProperty = (DocumentProperty)this.CorrelateProperty.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.DocumentType , null))
retObject.DocumentType = (DocumentType)this.DocumentType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CorrelateDocument , null))
retObject.CorrelateDocument = (Document)this.CorrelateDocument.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.EditorWorker , null))
retObject.EditorWorker = (Worker)this.EditorWorker.Clone(sNodeName) ;
return retObject;
}
public static string at_AssignedValue
{
get
{
return "DocumentPropValue.AssignedValue";
}
}
public static string at_AssignedValueDate
{
get
{
return "DocumentPropValue.AssignedValueDate";
}
}
public static string at_CorrelatePropertyID
{
get
{
return "DocumentPropValue.CorrelatePropertyID";
}
}
public static string at_CorrelatePropertyFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelatePropertyFirstLevelAttributes";
}
}
public static string at_CorrelateProperty_BasicInfoLinkFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateProperty.BasicInfoLinkFirstLevelAttributes";
}
}
public static string at_CorrelateProperty_MesurementTypeFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateProperty.MesurementTypeFirstLevelAttributes";
}
}
public static string at_CorrelateProperty_CoDocumentTypeFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateProperty.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CorrelateProperty_ValuesFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateProperty.ValuesFirstLevelAttributes";
}
}
public static string at_CorrelateProperty_ReferenceDocumentTypeFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateProperty.ReferenceDocumentTypeFirstLevelAttributes";
}
}
public static string at_DocumentTypeID
{
get
{
return "DocumentPropValue.DocumentTypeID";
}
}
public static string at_DocumentTypeFirstLevelAttributes
{
get
{
return "DocumentPropValue.DocumentTypeFirstLevelAttributes";
}
}
public static string at_DocumentType_PictureFirstLevelAttributes
{
get
{
return "DocumentPropValue.DocumentType.PictureFirstLevelAttributes";
}
}
public static string at_DocumentType_PropertiesFirstLevelAttributes
{
get
{
return "DocumentPropValue.DocumentType.PropertiesFirstLevelAttributes";
}
}
public static string at_DocumentType_SubSystemFirstLevelAttributes
{
get
{
return "DocumentPropValue.DocumentType.SubSystemFirstLevelAttributes";
}
}
public static string at_DocumentType_CoDefaultUIFirstLevelAttributes
{
get
{
return "DocumentPropValue.DocumentType.CoDefaultUIFirstLevelAttributes";
}
}
public static string at_CorrelateDocumentID
{
get
{
return "DocumentPropValue.CorrelateDocumentID";
}
}
public static string at_CorrelateDocumentFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateDocumentFirstLevelAttributes";
}
}
public static string at_CorrelateDocument_DocumentTypeFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateDocument.DocumentTypeFirstLevelAttributes";
}
}
public static string at_CorrelateDocument_ActivitiesFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateDocument.ActivitiesFirstLevelAttributes";
}
}
public static string at_CorrelateDocument_OwnerOrganFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateDocument.OwnerOrganFirstLevelAttributes";
}
}
public static string at_CorrelateDocument_CreatorPersonFirstLevelAttributes
{
get
{
return "DocumentPropValue.CorrelateDocument.CreatorPersonFirstLevelAttributes";
}
}
public static string at_EditorWorkerID
{
get
{
return "DocumentPropValue.EditorWorkerID";
}
}
public static string at_EditorWorkerFirstLevelAttributes
{
get
{
return "DocumentPropValue.EditorWorkerFirstLevelAttributes";
}
}
public static string at_EditorWorker_CoPositionFirstLevelAttributes
{
get
{
return "DocumentPropValue.EditorWorker.CoPositionFirstLevelAttributes";
}
}
public static string at_EditorWorker_RestrictionsFirstLevelAttributes
{
get
{
return "DocumentPropValue.EditorWorker.RestrictionsFirstLevelAttributes";
}
}
public static string at_EditorWorker_CoPersonFirstLevelAttributes
{
get
{
return "DocumentPropValue.EditorWorker.CoPersonFirstLevelAttributes";
}
}
public static string at_EditorWorker_AccessrightsFirstLevelAttributes
{
get
{
return "DocumentPropValue.EditorWorker.AccessrightsFirstLevelAttributes";
}
}
public static string at_EditorWorker_WorkerJobFirstLevelAttributes
{
get
{
return "DocumentPropValue.EditorWorker.WorkerJobFirstLevelAttributes";
}
}
}
}
