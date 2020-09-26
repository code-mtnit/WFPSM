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
[Description("رويداد عملكرد كاربران")]
    [DisplayName("رويداد عملكرد كاربران")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.HighLevelEvents")]
    [SystemName("ELS")]

[ObjectCode ("119")]
[Serializable]
public class HighLevelEvent : SbnObject 
{
public HighLevelEvent() 
: base() 
{ 
} 
public HighLevelEvent(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _RegDate;
/// <summary>
/// تاریخ
/// </summary>
[Description("تاریخ")]
[DisplayName("تاریخ")]
[Category("")]
[DocumentAttributeID("105")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string RegDate
{
get { return _RegDate; }
set { _RegDate = value; }
}
private DocumentType _ObjectType;
/// <summary>
/// نوع سند
/// </summary>
[Description("نوع سند")]
[DisplayName("نوع سند")]
[Category("")]
[DocumentAttributeID("11006")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("DocumentType")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public DocumentType ObjectType
{
get { return _ObjectType; }
set { _ObjectType = value; }
}
private WorkContext _WorkContext;
/// <summary>
/// اقدام
/// </summary>
[Description("اقدام")]
[DisplayName("اقدام")]
[Category("")]
[DocumentAttributeID("11008")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WorkContext")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WorkContext WorkContext
{
get { return _WorkContext; }
set { _WorkContext = value; }
}
private Document _CoDocument;
/// <summary>
/// سند مرتبط
/// </summary>
[Description("سند مرتبط")]
[DisplayName("سند مرتبط")]
[Category("")]
[DocumentAttributeID("11014")]
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
private ELSSession _CoSession;
/// <summary>
/// سریال ورود مرتبط
/// </summary>
[Description("سریال ورود مرتبط")]
[DisplayName("سریال ورود")]
[Category("")]
[DocumentAttributeID("11000")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("ELSSession")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public ELSSession CoSession
{
get { return _CoSession; }
set { _CoSession = value; }
}
public override string ToString()
{
return this.WorkContext.Title;
}
public override void Initialize()
{
base.Initialize();
this._RegDate = "";
this._ObjectType = new DocumentType() ;
this._WorkContext = new WorkContext() ;
this._CoDocument = new Document() ;
this._CoSession = new ELSSession() ;
}
public override SbnObject Clone(string sNodeName)
{
HighLevelEvent retObject = new HighLevelEvent();
retObject.ID = this.ID;
if(this._RegDate != null)  retObject.RegDate = (string)this._RegDate.Clone();
if (! object.ReferenceEquals( this.ObjectType , null))
retObject.ObjectType = (DocumentType)this.ObjectType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.WorkContext , null))
retObject.WorkContext = (WorkContext)this.WorkContext.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoDocument , null))
retObject.CoDocument = (Document)this.CoDocument.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoSession , null))
retObject.CoSession = (ELSSession)this.CoSession.Clone(sNodeName) ;
return retObject;
}
public static string at_RegDate
{
get
{
return "HighLevelEvent.RegDate";
}
}
public static string at_ObjectTypeID
{
get
{
return "HighLevelEvent.ObjectTypeID";
}
}
public static string at_ObjectTypeFirstLevelAttributes
{
get
{
return "HighLevelEvent.ObjectTypeFirstLevelAttributes";
}
}
public static string at_WorkContextID
{
get
{
return "HighLevelEvent.WorkContextID";
}
}
public static string at_WorkContextFirstLevelAttributes
{
get
{
return "HighLevelEvent.WorkContextFirstLevelAttributes";
}
}
public static string at_CoDocumentID
{
get
{
return "HighLevelEvent.CoDocumentID";
}
}
public static string at_CoDocumentFirstLevelAttributes
{
get
{
return "HighLevelEvent.CoDocumentFirstLevelAttributes";
}
}
public static string at_CoDocument_DocumentTypeFirstLevelAttributes
{
get
{
return "HighLevelEvent.CoDocument.DocumentTypeFirstLevelAttributes";
}
}
public static string at_CoSessionID
{
get
{
return "HighLevelEvent.CoSessionID";
}
}
public static string at_CoSessionFirstLevelAttributes
{
get
{
return "HighLevelEvent.CoSessionFirstLevelAttributes";
}
}
public static string at_CoSession_UserFirstLevelAttributes
{
get
{
return "HighLevelEvent.CoSession.UserFirstLevelAttributes";
}
}
}
}
