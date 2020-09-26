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
[Description("")]
[DisplayName ("")]
[ObjectCode ("2094")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.FolderItems")]
    [SystemName("WMC")]
[Serializable]
public class FolderItem : SbnObject 
{
public FolderItem() 
: base() 
{ 
} 
public FolderItem(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private DocumentType _CoDocType;
/// <summary>
/// نوع سند
/// </summary>
[Description("نوع سند")]
[DisplayName("نوع سند")]
[Category("")]
[DocumentAttributeID("27059")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentType")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentType CoDocType
{
get { return _CoDocType; }
set { _CoDocType = value; }
}
private Folder _CoFolder;
/// <summary>
/// پوشه مرتبط
/// </summary>
[Description("پوشه مرتبط")]
[DisplayName("پوشه مرتبط")]
[Category("")]
[DocumentAttributeID("27042")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Folder")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Folder CoFolder
{
get { return _CoFolder; }
set { _CoFolder = value; }
}
private Document _CoDocument;
/// <summary>
/// سند مرتبط
/// </summary>
[Description("سند مرتبط")]
[DisplayName("سند مرتبط")]
[Category("")]
[DocumentAttributeID("27043")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Document")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Document CoDocument
{
get { return _CoDocument; }
set { _CoDocument = value; }
}
private WFPerson _CoPerson;
/// <summary>
/// شخص مرتبط
/// </summary>
[Description("شخص مرتبط")]
[DisplayName("مالک آیتم")]
[Category("")]
[DocumentAttributeID("27045")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFPerson")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WFPerson CoPerson
{
get { return _CoPerson; }
set { _CoPerson = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._CoDocType = new DocumentType() ;
this._CoFolder = new Folder() ;
this._CoDocument = new Document() ;
this._CoPerson = new WFPerson() ;
}
public override SbnObject Clone(string sNodeName)
{
FolderItem retObject = new FolderItem();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.CoDocType , null))
retObject.CoDocType = (DocumentType)this.CoDocType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoFolder , null))
retObject.CoFolder = (Folder)this.CoFolder.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoDocument , null))
retObject.CoDocument = (Document)this.CoDocument.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoPerson , null))
retObject.CoPerson = (WFPerson)this.CoPerson.Clone(sNodeName) ;
return retObject;
}
public static string at_CoDocTypeID
{
get
{
return "FolderItem.CoDocTypeID";
}
}
public static string at_CoDocTypeFirstLevelAttributes
{
get
{
return "FolderItem.CoDocTypeFirstLevelAttributes";
}
}
public static string at_CoDocType_PictureFirstLevelAttributes
{
get
{
return "FolderItem.CoDocType.PictureFirstLevelAttributes";
}
}
public static string at_CoDocType_PropertiesFirstLevelAttributes
{
get
{
return "FolderItem.CoDocType.PropertiesFirstLevelAttributes";
}
}
public static string at_CoDocType_SubSystemFirstLevelAttributes
{
get
{
return "FolderItem.CoDocType.SubSystemFirstLevelAttributes";
}
}
public static string at_CoDocType_CoDefaultUIFirstLevelAttributes
{
get
{
return "FolderItem.CoDocType.CoDefaultUIFirstLevelAttributes";
}
}
public static string at_CoFolderID
{
get
{
return "FolderItem.CoFolderID";
}
}
public static string at_CoFolderFirstLevelAttributes
{
get
{
return "FolderItem.CoFolderFirstLevelAttributes";
}
}
public static string at_CoFolder_ParentFirstLevelAttributes
{
get
{
return "FolderItem.CoFolder.ParentFirstLevelAttributes";
}
}
public static string at_CoFolder_ChildsFirstLevelAttributes
{
get
{
return "FolderItem.CoFolder.ChildsFirstLevelAttributes";
}
}
public static string at_CoFolder_ItemsFirstLevelAttributes
{
get
{
return "FolderItem.CoFolder.ItemsFirstLevelAttributes";
}
}
public static string at_CoDocumentID
{
get
{
return "FolderItem.CoDocumentID";
}
}
public static string at_CoDocumentFirstLevelAttributes
{
get
{
return "FolderItem.CoDocumentFirstLevelAttributes";
}
}
public static string at_CoDocument_DocumentTypeFirstLevelAttributes
{
get
{
return "FolderItem.CoDocument.DocumentTypeFirstLevelAttributes";
}
}
public static string at_CoDocument_ActivitiesFirstLevelAttributes
{
get
{
return "FolderItem.CoDocument.ActivitiesFirstLevelAttributes";
}
}
public static string at_CoDocument_OwnerOrganFirstLevelAttributes
{
get
{
return "FolderItem.CoDocument.OwnerOrganFirstLevelAttributes";
}
}
public static string at_CoDocument_CreatorPersonFirstLevelAttributes
{
get
{
return "FolderItem.CoDocument.CreatorPersonFirstLevelAttributes";
}
}
public static string at_CoPersonID
{
get
{
return "FolderItem.CoPersonID";
}
}
public static string at_CoPersonFirstLevelAttributes
{
get
{
return "FolderItem.CoPersonFirstLevelAttributes";
}
}
public static string at_CoPerson_WorkersFirstLevelAttributes
{
get
{
return "FolderItem.CoPerson.WorkersFirstLevelAttributes";
}
}
public static string at_CoPerson_SexFirstLevelAttributes
{
get
{
return "FolderItem.CoPerson.SexFirstLevelAttributes";
}
}
}
}
