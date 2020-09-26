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
[Description("محدوديت نقش ها كه روي محدوديت كاربران تاثير مي گذارد")]
[DisplayName ("محدوديت نقش ها كه روي محدوديت كاربران تاثير مي گذارد")]
[ObjectCode ("2060")]
[SystemName ("WMC")]
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFRoleRestrictions")]
[Serializable]
public class WFRoleRestriction : SbnObject 
{
public WFRoleRestriction() 
: base() 
{ 
} 
public WFRoleRestriction(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _AssignedValue;
/// <summary>
/// مقدار تعیین شده برای این محدودیت
/// </summary>
[Description("مقدار تعیین شده برای این محدودیت")]
[DisplayName("مقدار تعیین شده")]
[Category("")]
[DocumentAttributeID("27051")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string AssignedValue
{
get { return _AssignedValue; }
set { _AssignedValue = value; }
}
private SbnBoolean _PrintAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2082")]
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
[DocumentAttributeID("2083")]
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
private SbnBoolean _RemoveAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2084")]
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
private SbnBoolean _UpdateAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2085")]
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
private SbnBoolean _RegisterAcc = SbnBoolean.OutOfValue;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2086")]
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
private DocumentType _CoDocumentType;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2088")]
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
private WFRole _CoRole;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2089")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFRole")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WFRole CoRole
{
get { return _CoRole; }
set { _CoRole = value; }
}
private DocumentProperty _CoProperty;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2090")]
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
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._AssignedValue =  "";
this._PrintAcc = SbnBoolean.OutOfValue;
this._ViewAcc = SbnBoolean.OutOfValue;
this._RemoveAcc = SbnBoolean.OutOfValue;
this._UpdateAcc = SbnBoolean.OutOfValue;
this._RegisterAcc = SbnBoolean.OutOfValue;
this._CoDocumentType = new DocumentType() ;
this._CoRole = new WFRole() ;
this._CoProperty = new DocumentProperty() ;
}
public override SbnObject Clone(string sNodeName)
{
WFRoleRestriction retObject = new WFRoleRestriction(this);
retObject.AssignedValue = this._AssignedValue;
retObject.PrintAcc = this.PrintAcc;
retObject.ViewAcc = this.ViewAcc;
retObject.RemoveAcc = this.RemoveAcc;
retObject.UpdateAcc = this.UpdateAcc;
retObject.RegisterAcc = this.RegisterAcc;
if (! object.ReferenceEquals( this.CoDocumentType , null))
retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoRole , null))
retObject.CoRole = (WFRole)this.CoRole.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoProperty , null))
retObject.CoProperty = (DocumentProperty)this.CoProperty.Clone(sNodeName) ;
return retObject;
}
public static string at_AssignedValue
{
get
{
return "WFRoleRestriction.AssignedValue";
}
}
public static string at_PrintAcc
{
get
{
return "WFRoleRestriction.PrintAcc";
}
}
public static string at_ViewAcc
{
get
{
return "WFRoleRestriction.ViewAcc";
}
}
public static string at_RemoveAcc
{
get
{
return "WFRoleRestriction.RemoveAcc";
}
}
public static string at_UpdateAcc
{
get
{
return "WFRoleRestriction.UpdateAcc";
}
}
public static string at_RegisterAcc
{
get
{
return "WFRoleRestriction.RegisterAcc";
}
}
public static string at_CoDocumentTypeID
{
get
{
return "WFRoleRestriction.CoDocumentTypeID";
}
}
public static string at_CoDocumentTypeTitle
{
get
{
return "WFRoleRestriction.CoDocumentTypeTitle";
}
}
public static string at_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoDocumentType_ObjectNameSpace
{
get
{
return "WFRoleRestriction.CoDocumentType.ObjectNameSpace";
}
}
public static string at_CoDocumentType_IconStream
{
get
{
return "WFRoleRestriction.CoDocumentType.IconStream";
}
}
public static string at_CoDocumentType_ObjectName
{
get
{
return "WFRoleRestriction.CoDocumentType.ObjectName";
}
}
public static string at_CoDocumentType_PictureFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoDocumentType.PictureFirstLevelAttributes";
}
}
public static string at_CoDocumentType_PropertiesFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoDocumentType.PropertiesFirstLevelAttributes";
}
}
public static string at_CoDocumentType_SubSystemFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoDocumentType.SubSystemFirstLevelAttributes";
}
}
public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoDocumentType.CoDefaultUIFirstLevelAttributes";
}
}
public static string at_CoRoleID
{
get
{
return "WFRoleRestriction.CoRoleID";
}
}
public static string at_CoRoleTitle
{
get
{
return "WFRoleRestriction.CoRoleTitle";
}
}
public static string at_CoRoleFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoRoleFirstLevelAttributes";
}
}
public static string at_CoRole_Title
{
get
{
return "WFRoleRestriction.CoRole.Title";
}
}
public static string at_CoRole_RestrictionsFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoRole.RestrictionsFirstLevelAttributes";
}
}
public static string at_CoRole_AccessrightsFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoRole.AccessrightsFirstLevelAttributes";
}
}
public static string at_CoRole_CoWorkflowFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoRole.CoWorkflowFirstLevelAttributes";
}
}
public static string at_CoRole_CoWorkersFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoRole.CoWorkersFirstLevelAttributes";
}
}
public static string at_CoRole_CoPlacesFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoRole.CoPlacesFirstLevelAttributes";
}
}
public static string at_CoPropertyID
{
get
{
return "WFRoleRestriction.CoPropertyID";
}
}
public static string at_CoPropertyTitle
{
get
{
return "WFRoleRestriction.CoPropertyTitle";
}
}
public static string at_CoPropertyFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoPropertyFirstLevelAttributes";
}
}
public static string at_CoProperty_ValidationPattern
{
get
{
return "WFRoleRestriction.CoProperty.ValidationPattern";
}
}
public static string at_CoProperty_OrderInDocument
{
get
{
return "WFRoleRestriction.CoProperty.OrderInDocument";
}
}
public static string at_CoProperty_ObjectAttribute
{
get
{
return "WFRoleRestriction.CoProperty.ObjectAttribute";
}
}
public static string at_CoProperty_ViewCategory
{
get
{
return "WFRoleRestriction.CoProperty.ViewCategory";
}
}
public static string at_CoProperty_DataEntryMask
{
get
{
return "WFRoleRestriction.CoProperty.DataEntryMask";
}
}
public static string at_CoProperty_CultureDescription
{
get
{
return "WFRoleRestriction.CoProperty.CultureDescription";
}
}
public static string at_CoProperty_BasicInfoLinkFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoProperty.BasicInfoLinkFirstLevelAttributes";
}
}
public static string at_CoProperty_MesurementTypeFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoProperty.MesurementTypeFirstLevelAttributes";
}
}
public static string at_CoProperty_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoProperty.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoProperty_ValuesFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoProperty.ValuesFirstLevelAttributes";
}
}
public static string at_CoProperty_ReferenceDocumentTypeFirstLevelAttributes
{
get
{
return "WFRoleRestriction.CoProperty.ReferenceDocumentTypeFirstLevelAttributes";
}
}
}
}
