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
[Description("بصورت نمايشي است و از بانك اطلاعات مديريت گردش كار استفاده مي كند")]
[DisplayName ("بصورت نمايشي است و از بانك اطلاعات مديريت گردش كار استفاده مي كند")]
[ObjectCode ("11015")]
[SystemName("ELS")]

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
/// کد رایانه ای
/// </summary>
[Description("کد رایانه ای")]
[DisplayName("کد رایانه ای")]
[Category("")]
[DocumentAttributeID("11029")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long BusinessDocumentCode
{
get { return _BusinessDocumentCode; }
set { _BusinessDocumentCode = value; }
}
private string _DisplayID;
/// <summary>
/// کد سند
/// </summary>
[Description("کد سند")]
[DisplayName("کد سند")]
[Category("")]
[DocumentAttributeID("11027")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string DisplayID
{
get { return _DisplayID; }
set { _DisplayID = value; }
}
private string _Description;
/// <summary>
/// شرح
/// </summary>
[Description("شرح")]
[DisplayName("شرح")]
[Category("")]
[DocumentAttributeID("11028")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
private DocumentType _DocumentType;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("11015")]
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
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._BusinessDocumentCode = 0;
this._DisplayID =  "";
this._Description =  "";
this._DocumentType = new DocumentType() ;
}
public override SbnObject Clone(string sNodeName)
{
Document retObject = new Document();
retObject.ID = this.ID;
retObject.BusinessDocumentCode = this._BusinessDocumentCode;
retObject.DisplayID = this._DisplayID;
retObject.Description = this._Description;
if (! object.ReferenceEquals( this.DocumentType , null))
retObject.DocumentType = (DocumentType)this.DocumentType.Clone(sNodeName) ;
return retObject;
}
public static string at_BusinessDocumentCode
{
get
{
return "Document.BusinessDocumentCode";
}
}
public static string at_DisplayID
{
get
{
return "Document.DisplayID";
}
}
public static string at_Description
{
get
{
return "Document.Description";
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
}
}
