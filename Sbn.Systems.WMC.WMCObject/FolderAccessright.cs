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
[Description("دسترسی کارمندان به پوشه")]
[DisplayName ("دسترسی کارمندان به پوشه")]
[ObjectCode ("2127")]
[SystemName ("WMC")]
[ItemsType ("Sbn.Systems.WMC.WMCObject.FolderAccessrights")]
[Serializable]
public class FolderAccessright : SbnObject 
{
public FolderAccessright() 
: base() 
{ 
} 
public FolderAccessright(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private Worker _CoWorker;
/// <summary>
/// کارمند مرتبط
/// </summary>
[Description("کارمند مرتبط")]
[DisplayName("کارمند مرتبط")]
[Category("")]
[DocumentAttributeID("27493")]
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
private Folder _CoFolder;
/// <summary>
/// پوشه مرتبط
/// </summary>
[Description("پوشه مرتبط")]
[DisplayName("پوشه مرتبط")]
[Category("")]
[DocumentAttributeID("27494")]
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
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._CoWorker = new Worker() ;
this._CoFolder = new Folder() ;
}
public override SbnObject Clone(string sNodeName)
{
FolderAccessright retObject = new FolderAccessright(this);
if (! object.ReferenceEquals( this.CoWorker , null))
retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoFolder , null))
retObject.CoFolder = (Folder)this.CoFolder.Clone(sNodeName) ;
return retObject;
}
public static string at_CoWorkerID
{
get
{
return "FolderAccessright.CoWorkerID";
}
}
public static string at_CoWorkerTitle
{
get
{
return "FolderAccessright.CoWorker.Title";
}
}
public static string at_CoWorkerFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorkerFirstLevelAttributes";
}
}
public static string at_CoWorker_StartWorkDate
{
get
{
return "FolderAccessright.CoWorker.StartWorkDate";
}
}
public static string at_CoWorker_EndWorkDate
{
get
{
return "FolderAccessright.CoWorker.EndWorkDate";
}
}
public static string at_CoWorker_IconStream
{
get
{
return "FolderAccessright.CoWorker.IconStream";
}
}
public static string at_CoWorker_CoPositionFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorker.CoPositionFirstLevelAttributes";
}
}
public static string at_CoWorker_RestrictionsFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorker.RestrictionsFirstLevelAttributes";
}
}
public static string at_CoWorker_CoPersonFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorker.CoPersonFirstLevelAttributes";
}
}
public static string at_CoWorker_AccessrightsFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorker.AccessrightsFirstLevelAttributes";
}
}
public static string at_CoWorker_WorkerJobFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorker.WorkerJobFirstLevelAttributes";
}
}
public static string at_CoWorker_CoRolesFirstLevelAttributes
{
get
{
return "FolderAccessright.CoWorker.CoRolesFirstLevelAttributes";
}
}
public static string at_CoFolderID
{
get
{
return "FolderAccessright.CoFolderID";
}
}
public static string at_CoFolderTitle
{
get
{
return "FolderAccessright.CoFolder.Title";
}
}
public static string at_CoFolderFirstLevelAttributes
{
get
{
return "FolderAccessright.CoFolderFirstLevelAttributes";
}
}
public static string at_CoFolder_ParentFirstLevelAttributes
{
get
{
return "FolderAccessright.CoFolder.ParentFirstLevelAttributes";
}
}
public static string at_CoFolder_ChildsFirstLevelAttributes
{
get
{
return "FolderAccessright.CoFolder.ChildsFirstLevelAttributes";
}
}
public static string at_CoFolder_ItemsFirstLevelAttributes
{
get
{
return "FolderAccessright.CoFolder.ItemsFirstLevelAttributes";
}
}
public static string at_CoFolder_CoUIsFirstLevelAttributes
{
get
{
return "FolderAccessright.CoFolder.CoUIsFirstLevelAttributes";
}
}
}
}
