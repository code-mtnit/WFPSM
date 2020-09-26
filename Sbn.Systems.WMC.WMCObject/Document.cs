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
[Description("سندياپرونده در حال گردش در سازمان كه شامل فعاليتهاي انجام شده روي آن مي باشد كليه زير سيستمها موظف هستند از سيستم گردش كار كد يكتا دريافت نمايند")]
[DisplayName ("سندياپرونده در حال گردش در سازمان كه شامل فعاليتهاي انجام شده روي آن مي باشد كليه زير سيستمها موظف هستند از سيستم گردش كار كد يكتا دريافت نمايند")]
[ObjectCode ("2067")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Documents")]
    [SystemName("WMC")]
[Serializable]
public class Document : SbnObject 
{
public Document() 
: base() 
{ 
} 
public Document(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private long _BusinessDocumentCode;
/// <summary>
/// کد رایانه ای یکتای سند در سازمان
/// </summary>
[Description("کد رایانه ای یکتای سند در سازمان")]
[DisplayName("کد رایانه ای")]
[Category("")]
[DocumentAttributeID("2043")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long BusinessDocumentCode
{
get { return _BusinessDocumentCode; }
set { _BusinessDocumentCode = value; }
}
private DocumentPropValues _AttributeValues;
/// <summary>
/// مقادیر ویژگیهای سند
/// </summary>
[Description("مقادیر ویژگیهای سند")]
[DisplayName("مقادیر ویژگیهای سند")]
[Category("")]
[DocumentAttributeID("27222")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentPropValues")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public DocumentPropValues AttributeValues
{
get { return _AttributeValues; }
set { _AttributeValues = value; }
}
private DocumentType _DocumentType;
/// <summary>
/// نوع سند
/// </summary>
[Description("نوع سند")]
[DisplayName("نوع سند")]
[Category("")]
[DocumentAttributeID("2110")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentType")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public DocumentType DocumentType
{
get { return _DocumentType; }
set { _DocumentType = value; }
}
private Activities _Activities;
/// <summary>
/// فعالیتها صرفا جنبه نمایشی و فراخوانی اطلاعات دارد
/// </summary>
[Description("فعالیتها صرفا جنبه نمایشی و فراخوانی اطلاعات دارد")]
[DisplayName("فعالیتها")]
[Category("")]
[DocumentAttributeID("2113")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("Activities")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public Activities Activities
{
get { return _Activities; }
set { _Activities = value; }
}
private OrgUnit _OwnerOrgan;
/// <summary>
/// ارگان مالک سند
/// </summary>
[Description("ارگان مالک سند")]
[DisplayName("ارگان مالک سند")]
[Category("مالکیت")]
[DocumentAttributeID("27026")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("OrgUnit")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public OrgUnit OwnerOrgan
{
get { return _OwnerOrgan; }
set { _OwnerOrgan = value; }
}
private WFPerson _CreatorPerson;
/// <summary>
/// شخص ثبات
/// </summary>
[Description("شخص ثبات")]
[DisplayName("شخص ثبات")]
[Category("مالکیت")]
[DocumentAttributeID("27137")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFPerson")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WFPerson CreatorPerson
{
get { return _CreatorPerson; }
set { _CreatorPerson = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._BusinessDocumentCode = 0;
this._AttributeValues = new DocumentPropValues() ;
this._DocumentType = new DocumentType() ;
this._Activities = new Activities() ;
this._OwnerOrgan = new OrgUnit() ;
this._CreatorPerson = new WFPerson() ;
}
public override SbnObject Clone(string sNodeName)
{
Document retObject = new Document();
retObject.ID = this.ID;
retObject.BusinessDocumentCode = this._BusinessDocumentCode;
if (! object.ReferenceEquals( this.AttributeValues , null))
retObject.AttributeValues = (DocumentPropValues)this.AttributeValues.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.DocumentType , null))
retObject.DocumentType = (DocumentType)this.DocumentType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Activities , null))
retObject.Activities = (Activities)this.Activities.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.OwnerOrgan , null))
retObject.OwnerOrgan = (OrgUnit)this.OwnerOrgan.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CreatorPerson , null))
retObject.CreatorPerson = (WFPerson)this.CreatorPerson.Clone(sNodeName) ;
return retObject;
}
public static string at_BusinessDocumentCode
{
get
{
return "Document.BusinessDocumentCode";
}
}
public static string at_AttributeValuesID
{
get
{
return "Document.AttributeValuesID";
}
}
public static string at_AttributeValuesFirstLevelAttributes
{
get
{
return "Document.AttributeValuesFirstLevelAttributes";
}
}
public static string at_DocumentTypeID
{
get
{
return "Document.DocumentTypeID";
}
}
public static string at_DocumentTypeFirstLevelAttributes
{
get
{
return "Document.DocumentTypeFirstLevelAttributes";
}
}
public static string at_DocumentType_PictureFirstLevelAttributes
{
get
{
return "Document.DocumentType.PictureFirstLevelAttributes";
}
}
public static string at_DocumentType_PropertiesFirstLevelAttributes
{
get
{
return "Document.DocumentType.PropertiesFirstLevelAttributes";
}
}
public static string at_DocumentType_SubSystemFirstLevelAttributes
{
get
{
return "Document.DocumentType.SubSystemFirstLevelAttributes";
}
}
public static string at_DocumentType_CoDefaultUIFirstLevelAttributes
{
get
{
return "Document.DocumentType.CoDefaultUIFirstLevelAttributes";
}
}
public static string at_ActivitiesID
{
get
{
return "Document.ActivitiesID";
}
}
public static string at_ActivitiesFirstLevelAttributes
{
get
{
return "Document.ActivitiesFirstLevelAttributes";
}
}
public static string at_OwnerOrganID
{
get
{
return "Document.OwnerOrganID";
}
}
public static string at_OwnerOrganFirstLevelAttributes
{
get
{
return "Document.OwnerOrganFirstLevelAttributes";
}
}
public static string at_OwnerOrgan_BuildingLocationFirstLevelAttributes
{
get
{
return "Document.OwnerOrgan.BuildingLocationFirstLevelAttributes";
}
}
public static string at_OwnerOrgan_ChildUnitsFirstLevelAttributes
{
get
{
return "Document.OwnerOrgan.ChildUnitsFirstLevelAttributes";
}
}
public static string at_OwnerOrgan_ParentUnitFirstLevelAttributes
{
get
{
return "Document.OwnerOrgan.ParentUnitFirstLevelAttributes";
}
}
public static string at_OwnerOrgan_PositionsFirstLevelAttributes
{
get
{
return "Document.OwnerOrgan.PositionsFirstLevelAttributes";
}
}
public static string at_OwnerOrgan_MergedUnitFirstLevelAttributes
{
get
{
return "Document.OwnerOrgan.MergedUnitFirstLevelAttributes";
}
}
public static string at_CreatorPersonID
{
get
{
return "Document.CreatorPersonID";
}
}
public static string at_CreatorPersonFirstLevelAttributes
{
get
{
return "Document.CreatorPersonFirstLevelAttributes";
}
}
public static string at_CreatorPerson_WorkersFirstLevelAttributes
{
get
{
return "Document.CreatorPerson.WorkersFirstLevelAttributes";
}
}
public static string at_CreatorPerson_SexFirstLevelAttributes
{
get
{
return "Document.CreatorPerson.SexFirstLevelAttributes";
}
}
}
}
