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
    [Description("دسترسيهاي اعطا شده به كارمند")]
    [DisplayName("دسترسيهاي اعطا شده به كارمند")]
    [ObjectCode("2052")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkerAccessrights")]
    [Serializable]
    public class WorkerAccessright : SbnObject
    {
        public WorkerAccessright()
            : base()
        {
        }
        public WorkerAccessright(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private Worker _CoWorker;
        /// <summary>
        /// کارمند مرتبط
        /// </summary>
        [Description("کارمند مرتبط")]
        [DisplayName("کارمند")]
        [Category("")]
        [DocumentAttributeID("2060")]
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
        private Accessright _CoAccessright;
        /// <summary>
        /// دسترسی
        /// </summary>
        [Description("دسترسی")]
        [DisplayName("دسترسی")]
        [Category("")]
        [DocumentAttributeID("2061")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Accessright")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Accessright CoAccessright
        {
            get { return _CoAccessright; }
            set { _CoAccessright = value; }
        }
        private UserInterface _CoUI;
        /// <summary>
        /// محیط کاربری مرتبط
        /// </summary>
        [Description("محیط کاربری مرتبط")]
        [DisplayName("محیط کاربری مرتبط")]
        [Category("")]
        [DocumentAttributeID("27015")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("UserInterface")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public UserInterface CoUI
        {
            get { return _CoUI; }
            set { _CoUI = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._CoWorker = new Worker();
            this._CoAccessright = new Accessright();
            this._CoUI = new UserInterface();
        }
        public override SbnObject Clone(string sNodeName)
        {
            WorkerAccessright retObject = new WorkerAccessright(this);
            if (!object.ReferenceEquals(this.CoWorker, null))
                retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoAccessright, null))
                retObject.CoAccessright = (Accessright)this.CoAccessright.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoUI, null))
                retObject.CoUI = (UserInterface)this.CoUI.Clone(sNodeName);
            return retObject;
        }
        public static string at_CoWorkerID
        {
            get
            {
                return "WorkerAccessright.CoWorkerID";
            }
        }
        public static string at_CoWorkerTitle
        {
            get
            {
                return "WorkerAccessright.CoWorker.Title";
            }
        }
        public static string at_CoWorkerFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorkerFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_StartWorkDate
        {
            get
            {
                return "WorkerAccessright.CoWorker.StartWorkDate";
            }
        }
        public static string at_CoWorker_EndWorkDate
        {
            get
            {
                return "WorkerAccessright.CoWorker.EndWorkDate";
            }
        }
        public static string at_CoWorker_IconStream
        {
            get
            {
                return "WorkerAccessright.CoWorker.IconStream";
            }
        }
        public static string at_CoWorker_CoPositionFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorker.CoPositionFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorker.RestrictionsFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_CoPersonFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorker.CoPersonFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorker.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorker.WorkerJobFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_CoRolesFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoWorker.CoRolesFirstLevelAttributes";
            }
        }
        public static string at_CoAccessrightID
        {
            get
            {
                return "WorkerAccessright.CoAccessrightID";
            }
        }
        public static string at_CoAccessrightTitle
        {
            get
            {
                return "WorkerAccessright.CoAccessright.Title";
            }
        }
        public static string at_CoAccessrightFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoAccessrightFirstLevelAttributes";
            }
        }
        public static string at_CoAccessright_DefaultUIFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoAccessright.DefaultUIFirstLevelAttributes";
            }
        }
        public static string at_CoUIID
        {
            get
            {
                return "WorkerAccessright.CoUIID";
            }
        }
        public static string at_CoUITitle
        {
            get
            {
                return "WorkerAccessright.CoUI.Title";
            }
        }
        public static string at_CoUIFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUIFirstLevelAttributes";
            }
        }
        public static string at_CoUI_WebPageURL
        {
            get
            {
                return "WorkerAccessright.CoUI.WebPageURL";
            }
        }
        public static string at_CoUI_IconStream
        {
            get
            {
                return "WorkerAccessright.CoUI.IconStream";
            }
        }
        public static string at_CoUI_ObjectNameSpace
        {
            get
            {
                return "WorkerAccessright.CoUI.ObjectNameSpace";
            }
        }
        public static string at_CoUI_CoAccessRightsFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.CoAccessRightsFirstLevelAttributes";
            }
        }
        public static string at_CoUI_ChildInterfacesFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.ChildInterfacesFirstLevelAttributes";
            }
        }
        public static string at_CoUI_ParentFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.ParentFirstLevelAttributes";
            }
        }
        public static string at_CoUI_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoUI_PictureFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoUI_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoUI_DefaultFolderFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.DefaultFolderFirstLevelAttributes";
            }
        }
        public static string at_CoUI_WorkerAccessrightsFirstLevelAttributes
        {
            get
            {
                return "WorkerAccessright.CoUI.WorkerAccessrightsFirstLevelAttributes";
            }
        }
    }
}
