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
    [Description("زمينه كاري")]
    [DisplayName("زمينه كاري")]
    [ObjectCode("2008")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkContexts")]
    [Serializable]
    public class WorkContext : SbnObject
    {
        public WorkContext()
            : base()
        {
        }
        public WorkContext(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private UserInterface _CoUI;
        /// <summary>
        /// نام محیط کاربری مرتبط
        /// </summary>
        [Description("نام محیط کاربری مرتبط")]
        [DisplayName("محیط کاربری")]
        [Category("")]
        [DocumentAttributeID("2064")]
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
        private DocumentType _CoDocumentType;
        /// <summary>
        /// سند مرتبط با این زمینه کاری
        /// </summary>
        [Description("سند مرتبط با این زمینه کاری")]
        [DisplayName("نوع سند")]
        [Category("")]
        [DocumentAttributeID("2068")]
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
        private OrgUnit _CoOrgan;
        /// <summary>
        /// واحد سازمانی مرتبط با این زمینه کاری که با وظایف ارسالی از بیرون سازمان در ارتباط است
        /// </summary>
        [Description("واحد سازمانی مرتبط با این زمینه کاری که با وظایف ارسالی از بیرون سازمان در ارتباط است")]
        [DisplayName("واحد سازمانی مرتبط")]
        [Category("")]
        [DocumentAttributeID("2095")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgUnit CoOrgan
        {
            get { return _CoOrgan; }
            set { _CoOrgan = value; }
        }
        private Icon _Picture;
        /// <summary>
        /// تصویر
        /// </summary>
        [Description("تصویر")]
        [DisplayName("تصویر")]
        [Category("")]
        [DocumentAttributeID("27008")]
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
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._CoUI = new UserInterface();
            this._CoDocumentType = new DocumentType();
            this._CoOrgan = new OrgUnit();
            this._Picture = new Icon();
        }
        public override SbnObject Clone(string sNodeName)
        {
            WorkContext retObject = new WorkContext(this);
            if (!object.ReferenceEquals(this.CoUI, null))
                retObject.CoUI = (UserInterface)this.CoUI.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDocumentType, null))
                retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoOrgan, null))
                retObject.CoOrgan = (OrgUnit)this.CoOrgan.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Picture, null))
                retObject.Picture = (Icon)this.Picture.Clone(sNodeName);
            return retObject;
        }
        public static string at_CoUIID
        {
            get
            {
                return "WorkContext.CoUIID";
            }
        }
        public static string at_CoUITitle
        {
            get
            {
                return "WorkContext.CoUI.Title";
            }
        }
        public static string at_CoUIFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUIFirstLevelAttributes";
            }
        }
        public static string at_CoUI_WebPageURL
        {
            get
            {
                return "WorkContext.CoUI.WebPageURL";
            }
        }
        public static string at_CoUI_IconStream
        {
            get
            {
                return "WorkContext.CoUI.IconStream";
            }
        }
        public static string at_CoUI_ObjectNameSpace
        {
            get
            {
                return "WorkContext.CoUI.ObjectNameSpace";
            }
        }
        public static string at_CoUI_CoAccessRightsFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.CoAccessRightsFirstLevelAttributes";
            }
        }
        public static string at_CoUI_ChildInterfacesFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.ChildInterfacesFirstLevelAttributes";
            }
        }
        public static string at_CoUI_ParentFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.ParentFirstLevelAttributes";
            }
        }
        public static string at_CoUI_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoUI_PictureFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoUI_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoUI_DefaultFolderFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.DefaultFolderFirstLevelAttributes";
            }
        }
        public static string at_CoUI_WorkerAccessrightsFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoUI.WorkerAccessrightsFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentTypeID
        {
            get
            {
                return "WorkContext.CoDocumentTypeID";
            }
        }
        public static string at_CoDocumentTypeTitle
        {
            get
            {
                return "WorkContext.CoDocumentType.Title";
            }
        }
        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_ObjectNameSpace
        {
            get
            {
                return "WorkContext.CoDocumentType.ObjectNameSpace";
            }
        }
        public static string at_CoDocumentType_IconStream
        {
            get
            {
                return "WorkContext.CoDocumentType.IconStream";
            }
        }
        public static string at_CoDocumentType_ObjectName
        {
            get
            {
                return "WorkContext.CoDocumentType.ObjectName";
            }
        }
        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_CoOrganID
        {
            get
            {
                return "WorkContext.CoOrganID";
            }
        }
        public static string at_CoOrganTitle
        {
            get
            {
                return "WorkContext.CoOrgan.Title";
            }
        }
        public static string at_CoOrganFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoOrganFirstLevelAttributes";
            }
        }
        public static string at_CoOrgan_UnitPath
        {
            get
            {
                return "WorkContext.CoOrgan.UnitPath";
            }
        }
        public static string at_CoOrgan_ExpireDate
        {
            get
            {
                return "WorkContext.CoOrgan.ExpireDate";
            }
        }
        public static string at_CoOrgan_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoOrgan.BuildingLocationFirstLevelAttributes";
            }
        }
        public static string at_CoOrgan_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoOrgan.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_CoOrgan_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoOrgan.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_CoOrgan_PositionsFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoOrgan.PositionsFirstLevelAttributes";
            }
        }
        public static string at_CoOrgan_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "WorkContext.CoOrgan.MergedUnitFirstLevelAttributes";
            }
        }
        public static string at_PictureID
        {
            get
            {
                return "WorkContext.PictureID";
            }
        }
        public static string at_PictureTitle
        {
            get
            {
                return "WorkContext.Picture.Title";
            }
        }
        public static string at_PictureFirstLevelAttributes
        {
            get
            {
                return "WorkContext.PictureFirstLevelAttributes";
            }
        }
    }
}
