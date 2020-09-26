using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
    [Description("نوع سندي كه در گردش كار بين كارمندان جابجا مي شود. هر زير سيستم محدوده كد نمايشي مخصوص خود را دارد.")]
    [DisplayName("نوع سندي كه در گردش كار بين كارمندان جابجا مي شود. هر زير سيستم محدوده كد نمايشي مخصوص خود را دارد.")]
    [ObjectCode("2011")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.DocumentTypes")]
    [Serializable]
    public class DocumentType : SbnObject
    {
        public DocumentType()
            : base()
        {
        }
        public DocumentType(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _ObjectNameSpace;
        /// <summary>
        /// مسیر اسمبلی
        /// </summary>
        [Description("مسیر اسمبلی")]
        [DisplayName("مسیر اسمبلی")]
        [Category("مشخصات کتابخانه")]
        [DocumentAttributeID("27034")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ObjectNameSpace
        {
            get { return _ObjectNameSpace; }
            set { _ObjectNameSpace = value; }
        }
        private byte[] _IconStream;
        /// <summary>
        /// آیکون
        /// </summary>
        [Description("آیکون")]
        [DisplayName("آیکون")]
        [Category("")]
        [DocumentAttributeID("27053")]
        [IsRelationalAttribute("false")]
        [AttributeType("Binary")]
        [Browsable(true)]
        public byte[] IconStream
        {
            get { return _IconStream; }
            set { _IconStream = value; }
        }
        private string _ObjectName;
        /// <summary>
        /// نام شیء
        /// </summary>
        [Description("نام شیء")]
        [DisplayName("نام شیء")]
        [Category("مشخصات کتابخانه")]
        [DocumentAttributeID("27106")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ObjectName
        {
            get { return _ObjectName; }
            set { _ObjectName = value; }
        }
        private SbnBoolean _IsDocumentBased = SbnBoolean.OutOfValue;
        /// <summary>
        /// آیا این نوع مبتنی بر اسناد است یا خیر جهت نگهداری در جدول اسناد
        /// </summary>
        [Description("آیا این نوع مبتنی بر اسناد است یا خیر جهت نگهداری در جدول اسناد")]
        [DisplayName("مبتنی بر سند")]
        [Category("مشخصات اصلی")]
        [DocumentAttributeID("27183")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsDocumentBased
        {
            get { return _IsDocumentBased; }
            set { _IsDocumentBased = value; }
        }
        private Icon _Picture;
        /// <summary>
        /// تصویر
        /// </summary>
        [Description("تصویر")]
        [DisplayName("تصویر")]
        [Category("")]
        [DocumentAttributeID("27007")]
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
        private DocumentProperties _Properties;
        /// <summary>
        /// ویژگیهای سند مورد استفاده در تعیین محدودیتها
        /// </summary>
        [Description("ویژگیهای سند مورد استفاده در تعیین محدودیتها")]
        [DisplayName("ویژگیها")]
        [Category("")]
        [DocumentAttributeID("2016")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("DocumentProperties")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public DocumentProperties Properties
        {
            get { return _Properties; }
            set { _Properties = value; }
        }
        private SubSystem _SubSystem;
        /// <summary>
        /// زیر سیستمی که سند در آن جریان دارد
        /// </summary>
        [Description("زیر سیستمی که سند در آن جریان دارد")]
        [DisplayName("سیستم مرتبط")]
        [Category("")]
        [DocumentAttributeID("2097")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SubSystem")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SubSystem SubSystem
        {
            get { return _SubSystem; }
            set { _SubSystem = value; }
        }
        private UserInterface _CoDefaultUI;
        /// <summary>
        /// محیط کاربری پیش فرض
        /// </summary>
        [Description("محیط کاربری پیش فرض")]
        [DisplayName("محیط کاربری")]
        [Category("")]
        [DocumentAttributeID("27018")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("UserInterface")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public UserInterface CoDefaultUI
        {
            get { return _CoDefaultUI; }
            set { _CoDefaultUI = value; }
        }
        private SbnBoolean _IsVirtualDocument = SbnBoolean.OutOfValue;
        /// <summary>
        /// موجودیت مجازی
        /// </summary>
        [Description("موجودیت مجازی")]
        [DisplayName("موجودیت مجازی")]
        [Category("")]
        [DocumentAttributeID("27213")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsVirtualDocument
        {
            get { return _IsVirtualDocument; }
            set { _IsVirtualDocument = value; }
        }
        private SbnBoolean _ArchiveChange = SbnBoolean.OutOfValue;
        /// <summary>
        /// آرشیو تغییرات
        /// </summary>
        [Description("آرشیو تغییرات")]
        [DisplayName("آرشیو تغییرات")]
        [Category("")]
        [DocumentAttributeID("27327")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean ArchiveChange
        {
            get { return _ArchiveChange; }
            set { _ArchiveChange = value; }
        }
        private SbnOwnershipDomain _DefaultOwnershipType = SbnOwnershipDomain.OutOfValue;
        /// <summary>
        /// نوع مالکیت پیش فرض برای ثبت این سند
        /// </summary>
        [Description("نوع مالکیت پیش فرض برای ثبت این سند")]
        [DisplayName("مالکیت پیشفرض")]
        [Category("")]
        [DocumentAttributeID("27479")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnOwnershipDomain")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnOwnershipDomain DefaultOwnershipType
        {
            get { return _DefaultOwnershipType; }
            set { _DefaultOwnershipType = value; }
        }
        public override string ToString()
        {
            try { return this.Title; }
            catch { } return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._ObjectNameSpace = "";
            this._IconStream = new byte[1];
            this._ObjectName = "";
            this._IsDocumentBased = SbnBoolean.OutOfValue;
            this._Picture = new Icon();
            this._Properties = new DocumentProperties();
            this._SubSystem = new SubSystem();
            this._CoDefaultUI = new UserInterface();
            this._IsVirtualDocument = SbnBoolean.OutOfValue;
            this._ArchiveChange = SbnBoolean.OutOfValue;
            this._DefaultOwnershipType = SbnOwnershipDomain.OutOfValue;
        }
        public override SbnObject Clone(string sNodeName)
        {
            DocumentType retObject = new DocumentType(this);
            retObject.ObjectNameSpace = this._ObjectNameSpace;
            if (this._IconStream != null) retObject.IconStream = (byte[])this._IconStream.Clone();
            retObject.ObjectName = this._ObjectName;
            retObject.IsDocumentBased = this.IsDocumentBased;
            if (!object.ReferenceEquals(this.Picture, null))
                retObject.Picture = (Icon)this.Picture.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Properties, null))
                retObject.Properties = (DocumentProperties)this.Properties.Clone(sNodeName);
            if (!object.ReferenceEquals(this.SubSystem, null))
                retObject.SubSystem = (SubSystem)this.SubSystem.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDefaultUI, null))
                retObject.CoDefaultUI = (UserInterface)this.CoDefaultUI.Clone(sNodeName);
            retObject.IsVirtualDocument = this.IsVirtualDocument;
            retObject.ArchiveChange = this.ArchiveChange;
            retObject.DefaultOwnershipType = this.DefaultOwnershipType;
            return retObject;
        }
        public static string at_ObjectNameSpace
        {
            get
            {
                return "DocumentType.ObjectNameSpace";
            }
        }
        public static string at_IconStream
        {
            get
            {
                return "DocumentType.IconStream";
            }
        }
        public static string at_ObjectName
        {
            get
            {
                return "DocumentType.ObjectName";
            }
        }
        public static string at_IsDocumentBased
        {
            get
            {
                return "DocumentType.IsDocumentBased";
            }
        }
        public static string at_PictureID
        {
            get
            {
                return "DocumentType.PictureID";
            }
        }
        public static string at_PictureTitle
        {
            get
            {
                return "DocumentType.Picture.Title";
            }
        }
        public static string at_PictureFirstLevelAttributes
        {
            get
            {
                return "DocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_PropertiesID
        {
            get
            {
                return "DocumentType.PropertiesID";
            }
        }
        public static string at_PropertiesTitle
        {
            get
            {
                return "DocumentType.Properties.Title";
            }
        }
        public static string at_PropertiesFirstLevelAttributes
        {
            get
            {
                return "DocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_SubSystemID
        {
            get
            {
                return "DocumentType.SubSystemID";
            }
        }
        public static string at_SubSystemTitle
        {
            get
            {
                return "DocumentType.SubSystem.Title";
            }
        }
        public static string at_SubSystemFirstLevelAttributes
        {
            get
            {
                return "DocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_SubSystem_DocumentIDRange
        {
            get
            {
                return "DocumentType.SubSystem.DocumentIDRange";
            }
        }
        public static string at_SubSystem_ClientObjectNamespace
        {
            get
            {
                return "DocumentType.SubSystem.ClientObjectNamespace";
            }
        }
        public static string at_SubSystem_UIOjbectNamespace
        {
            get
            {
                return "DocumentType.SubSystem.UIOjbectNamespace";
            }
        }
        public static string at_CoDefaultUIID
        {
            get
            {
                return "DocumentType.CoDefaultUIID";
            }
        }
        public static string at_CoDefaultUITitle
        {
            get
            {
                return "DocumentType.CoDefaultUI.Title";
            }
        }
        public static string at_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_WebPageURL
        {
            get
            {
                return "DocumentType.CoDefaultUI.WebPageURL";
            }
        }
        public static string at_CoDefaultUI_IconStream
        {
            get
            {
                return "DocumentType.CoDefaultUI.IconStream";
            }
        }
        public static string at_CoDefaultUI_ObjectNameSpace
        {
            get
            {
                return "DocumentType.CoDefaultUI.ObjectNameSpace";
            }
        }
        public static string at_CoDefaultUI_CoAccessRightsFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.CoAccessRightsFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_ChildInterfacesFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.ChildInterfacesFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_ParentFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.ParentFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_PictureFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_DefaultFolderFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.DefaultFolderFirstLevelAttributes";
            }
        }
        public static string at_CoDefaultUI_WorkerAccessrightsFirstLevelAttributes
        {
            get
            {
                return "DocumentType.CoDefaultUI.WorkerAccessrightsFirstLevelAttributes";
            }
        }
        public static string at_IsVirtualDocument
        {
            get
            {
                return "DocumentType.IsVirtualDocument";
            }
        }
        public static string at_ArchiveChange
        {
            get
            {
                return "DocumentType.ArchiveChange";
            }
        }
        public static string at_DefaultOwnershipType
        {
            get
            {
                return "DocumentType.DefaultOwnershipType";
            }
        }
    }
}
