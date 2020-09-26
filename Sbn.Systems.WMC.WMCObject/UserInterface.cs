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
    [Description("محيط كاربري")]
    [DisplayName("محيط كاربري")]
    [ObjectCode("2013")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.UserInterfaces")]
    [Serializable]
    public class UserInterface : SbnObject
    {
        public UserInterface()
            : base()
        {
        }
        public UserInterface(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _WebPageURL;
        /// <summary>
        /// آدرس اجرای صفحه وب محیط کاربری
        /// </summary>
        [Description("آدرس اجرای صفحه وب محیط کاربری")]
        [DisplayName("آدرس صفحه وب")]
        [Category("")]
        [DocumentAttributeID("27080")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string WebPageURL
        {
            get { return _WebPageURL; }
            set { _WebPageURL = value; }
        }
        private byte[] _IconStream;
        /// <summary>
        /// رشته حاوی اطلاعات تصویر آیکون
        /// </summary>
        [Description("رشته حاوی اطلاعات تصویر آیکون")]
        [DisplayName("اطلاعات آیکون")]
        [Category("")]
        [DocumentAttributeID("27052")]
        [IsRelationalAttribute("false")]
        [AttributeType("Binary")]
        [Browsable(true)]
        public byte[] IconStream
        {
            get { return _IconStream; }
            set { _IconStream = value; }
        }
        private string _ObjectNameSpace;
        /// <summary>
        /// مسیر اسمبلی فایل
        /// </summary>
        [Description("مسیر اسمبلی فایل")]
        [DisplayName("مسیر اسمبلی")]
        [Category("")]
        [DocumentAttributeID("27037")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ObjectNameSpace
        {
            get { return _ObjectNameSpace; }
            set { _ObjectNameSpace = value; }
        }
        private Accessrights _CoAccessRights;
        /// <summary>
        /// دسترسی های مرتبط با این محیط کاربری که برای هر کارمند قابل انتخاب است
        /// </summary>
        [Description("دسترسی های مرتبط با این محیط کاربری که برای هر کارمند قابل انتخاب است")]
        [DisplayName("دسترسی ها")]
        [Category("")]
        [DocumentAttributeID("27012")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("Accessrights")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public Accessrights CoAccessRights
        {
            get { return _CoAccessRights; }
            set { _CoAccessRights = value; }
        }
        private UserInterfaces _ChildInterfaces;
        /// <summary>
        /// زیر مجموعه
        /// </summary>
        [Description("زیر مجموعه")]
        [DisplayName("زیرمجموعه")]
        [Category("")]
        [DocumentAttributeID("2131")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("UserInterfaces")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public UserInterfaces ChildInterfaces
        {
            get { return _ChildInterfaces; }
            set { _ChildInterfaces = value; }
        }
        private UserInterface _Parent;
        /// <summary>
        /// عنوان دسته بالایی
        /// </summary>
        [Description("عنوان دسته بالایی")]
        [DisplayName("عنوان سطح بالاتر")]
        [Category("")]
        [DocumentAttributeID("2133")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("UserInterface")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public UserInterface Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        private DocumentType _CoDocumentType;
        /// <summary>
        /// نوع سند
        /// </summary>
        [Description("نوع سند")]
        [DisplayName("نوع سند")]
        [Category("")]
        [DocumentAttributeID("2138")]
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
        private Icon _Picture;
        /// <summary>
        /// تصویر
        /// </summary>
        [Description("تصویر")]
        [DisplayName("تصویر")]
        [Category("")]
        [DocumentAttributeID("27009")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Icon")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Icon Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }
        private SubSystem _CoSubSystem;
        /// <summary>
        /// زیر سیستم مرتبط در صورت نیاز
        /// </summary>
        [Description("زیر سیستم مرتبط در صورت نیاز")]
        [DisplayName("زیر سیستم")]
        [Category("")]
        [DocumentAttributeID("27017")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SubSystem")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SubSystem CoSubSystem
        {
            get { return _CoSubSystem; }
            set { _CoSubSystem = value; }
        }
        private Folder _DefaultFolder;
        /// <summary>
        /// پوشه پیش فرض
        /// </summary>
        [Description("پوشه پیش فرض")]
        [DisplayName("پوشه پیش فرض")]
        [Category("")]
        [DocumentAttributeID("27068")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Folder")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Folder DefaultFolder
        {
            get { return _DefaultFolder; }
            set { _DefaultFolder = value; }
        }
        private WorkerAccessrights _WorkerAccessrights;
        /// <summary>
        /// دسترسی کارمندان به این محیط کاربری
        /// </summary>
        [Description("دسترسی کارمندان به این محیط کاربری")]
        [DisplayName("دسترسی کارمندان")]
        [Category("")]
        [DocumentAttributeID("27445")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WorkerAccessrights")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public WorkerAccessrights WorkerAccessrights
        {
            get { return _WorkerAccessrights; }
            set { _WorkerAccessrights = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._WebPageURL = "";
            this._IconStream = new byte[1];
            this._ObjectNameSpace = "";
            this._CoAccessRights = new Accessrights();
            this._ChildInterfaces = new UserInterfaces();
            this._Parent = new UserInterface();
            this._CoDocumentType = new DocumentType();
            this._Picture = new Icon();
            this._CoSubSystem = new SubSystem();
            this._DefaultFolder = new Folder();
            this._WorkerAccessrights = new WorkerAccessrights();
        }
        public override SbnObject Clone(string sNodeName)
        {
            UserInterface retObject = new UserInterface(this);
            retObject.WebPageURL = this._WebPageURL;
            if (this._IconStream != null) retObject.IconStream = (byte[])this._IconStream.Clone();
            retObject.ObjectNameSpace = this._ObjectNameSpace;
            if (!object.ReferenceEquals(this.CoAccessRights, null))
                retObject.CoAccessRights = (Accessrights)this.CoAccessRights.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ChildInterfaces, null))
                retObject.ChildInterfaces = (UserInterfaces)this.ChildInterfaces.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Parent, null))
                retObject.Parent = (UserInterface)this.Parent.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDocumentType, null))
                retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Picture, null))
                retObject.Picture = (Icon)this.Picture.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoSubSystem, null))
                retObject.CoSubSystem = (SubSystem)this.CoSubSystem.Clone(sNodeName);
            if (!object.ReferenceEquals(this.DefaultFolder, null))
                retObject.DefaultFolder = (Folder)this.DefaultFolder.Clone(sNodeName);
            if (!object.ReferenceEquals(this.WorkerAccessrights, null))
                retObject.WorkerAccessrights = (WorkerAccessrights)this.WorkerAccessrights.Clone(sNodeName);
            return retObject;
        }
        public static string at_WebPageURL
        {
            get
            {
                return "UserInterface.WebPageURL";
            }
        }
        public static string at_IconStream
        {
            get
            {
                return "UserInterface.IconStream";
            }
        }
        public static string at_ObjectNameSpace
        {
            get
            {
                return "UserInterface.ObjectNameSpace";
            }
        }
        public static string at_CoAccessRightsID
        {
            get
            {
                return "UserInterface.CoAccessRightsID";
            }
        }
        public static string at_CoAccessRightsTitle
        {
            get
            {
                return "UserInterface.CoAccessRights.Title";
            }
        }
        public static string at_CoAccessRightsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoAccessRightsFirstLevelAttributes";
            }
        }
        public static string at_ChildInterfacesID
        {
            get
            {
                return "UserInterface.ChildInterfacesID";
            }
        }
        public static string at_ChildInterfacesTitle
        {
            get
            {
                return "UserInterface.ChildInterfaces.Title";
            }
        }
        public static string at_ChildInterfacesFirstLevelAttributes
        {
            get
            {
                return "UserInterface.ChildInterfacesFirstLevelAttributes";
            }
        }
        public static string at_ParentID
        {
            get
            {
                return "UserInterface.ParentID";
            }
        }
        public static string at_ParentTitle
        {
            get
            {
                return "UserInterface.Parent.Title";
            }
        }
        public static string at_ParentFirstLevelAttributes
        {
            get
            {
                return "UserInterface.ParentFirstLevelAttributes";
            }
        }
        public static string at_Parent_WebPageURL
        {
            get
            {
                return "UserInterface.Parent.WebPageURL";
            }
        }
        public static string at_Parent_IconStream
        {
            get
            {
                return "UserInterface.Parent.IconStream";
            }
        }
        public static string at_Parent_ObjectNameSpace
        {
            get
            {
                return "UserInterface.Parent.ObjectNameSpace";
            }
        }
        public static string at_Parent_CoAccessRightsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.CoAccessRightsFirstLevelAttributes";
            }
        }
        public static string at_Parent_ChildInterfacesFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.ChildInterfacesFirstLevelAttributes";
            }
        }
        public static string at_Parent_ParentFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.ParentFirstLevelAttributes";
            }
        }
        public static string at_Parent_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_Parent_PictureFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.PictureFirstLevelAttributes";
            }
        }
        public static string at_Parent_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_Parent_DefaultFolderFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.DefaultFolderFirstLevelAttributes";
            }
        }
        public static string at_Parent_WorkerAccessrightsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.Parent.WorkerAccessrightsFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentTypeID
        {
            get
            {
                return "UserInterface.CoDocumentTypeID";
            }
        }
        public static string at_CoDocumentTypeTitle
        {
            get
            {
                return "UserInterface.CoDocumentType.Title";
            }
        }
        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_ObjectNameSpace
        {
            get
            {
                return "UserInterface.CoDocumentType.ObjectNameSpace";
            }
        }
        public static string at_CoDocumentType_IconStream
        {
            get
            {
                return "UserInterface.CoDocumentType.IconStream";
            }
        }
        public static string at_CoDocumentType_ObjectName
        {
            get
            {
                return "UserInterface.CoDocumentType.ObjectName";
            }
        }
        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_PictureID
        {
            get
            {
                return "UserInterface.PictureID";
            }
        }
        public static string at_PictureTitle
        {
            get
            {
                return "UserInterface.Picture.Title";
            }
        }
        public static string at_PictureFirstLevelAttributes
        {
            get
            {
                return "UserInterface.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoSubSystemID
        {
            get
            {
                return "UserInterface.CoSubSystemID";
            }
        }
        public static string at_CoSubSystemTitle
        {
            get
            {
                return "UserInterface.CoSubSystem.Title";
            }
        }
        public static string at_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "UserInterface.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoSubSystem_DocumentIDRange
        {
            get
            {
                return "UserInterface.CoSubSystem.DocumentIDRange";
            }
        }
        public static string at_CoSubSystem_ClientObjectNamespace
        {
            get
            {
                return "UserInterface.CoSubSystem.ClientObjectNamespace";
            }
        }
        public static string at_CoSubSystem_UIOjbectNamespace
        {
            get
            {
                return "UserInterface.CoSubSystem.UIOjbectNamespace";
            }
        }
        public static string at_DefaultFolderID
        {
            get
            {
                return "UserInterface.DefaultFolderID";
            }
        }
        public static string at_DefaultFolderTitle
        {
            get
            {
                return "UserInterface.DefaultFolder.Title";
            }
        }
        public static string at_DefaultFolderFirstLevelAttributes
        {
            get
            {
                return "UserInterface.DefaultFolderFirstLevelAttributes";
            }
        }
        public static string at_DefaultFolder_ParentFirstLevelAttributes
        {
            get
            {
                return "UserInterface.DefaultFolder.ParentFirstLevelAttributes";
            }
        }
        public static string at_DefaultFolder_ChildsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.DefaultFolder.ChildsFirstLevelAttributes";
            }
        }
        public static string at_DefaultFolder_ItemsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.DefaultFolder.ItemsFirstLevelAttributes";
            }
        }
        public static string at_DefaultFolder_CoUIsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.DefaultFolder.CoUIsFirstLevelAttributes";
            }
        }
        public static string at_DefaultFolder_WorkerAccessrightsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.DefaultFolder.WorkerAccessrightsFirstLevelAttributes";
            }
        }
        public static string at_WorkerAccessrightsID
        {
            get
            {
                return "UserInterface.WorkerAccessrightsID";
            }
        }
        public static string at_WorkerAccessrightsTitle
        {
            get
            {
                return "UserInterface.WorkerAccessrights.Title";
            }
        }
        public static string at_WorkerAccessrightsFirstLevelAttributes
        {
            get
            {
                return "UserInterface.WorkerAccessrightsFirstLevelAttributes";
            }
        }
    }
}
