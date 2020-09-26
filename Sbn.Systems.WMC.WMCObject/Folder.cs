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
    [Description("پوشه : كاربران داراي دسترسي بصورت شخصي يا گروهي يا عمومي ميتوانند ايجاد كنند")]
    [DisplayName("پوشه : كاربران داراي دسترسي بصورت شخصي يا گروهي يا عمومي ميتوانند ايجاد كنند")]
    [ObjectCode("2065")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Folders")]
    [Serializable]
    public class Folder : SbnObject
    {
        public Folder()
            : base()
        {
        }
        public Folder(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private Folder _Parent;
        /// <summary>
        /// شاخه بالایی
        /// </summary>
        [Description("شاخه بالایی")]
        [DisplayName("شاخه بالایی")]
        [Category("")]
        [DocumentAttributeID("2102")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Folder")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Folder Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        private Folders _Childs;
        /// <summary>
        /// زیر شاخه ها
        /// </summary>
        [Description("زیر شاخه ها")]
        [DisplayName("زیر شاخه ها")]
        [Category("")]
        [DocumentAttributeID("2103")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("Folders")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public Folders Childs
        {
            get { return _Childs; }
            set { _Childs = value; }
        }
        private FolderCategoryType _CategoryType = FolderCategoryType.OutOfValue;
        /// <summary>
        /// نوع محتوای پوشه
        /// </summary>
        [Description("نوع محتوای پوشه")]
        [DisplayName("نوع محتوی")]
        [Category("")]
        [DocumentAttributeID("27041")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("FolderCategoryType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public FolderCategoryType CategoryType
        {
            get { return _CategoryType; }
            set { _CategoryType = value; }
        }
        private FolderItems _Items;
        /// <summary>
        /// محتوای پوشه
        /// </summary>
        [Description("محتوای پوشه")]
        [DisplayName("محتوای پوشه")]
        [Category("")]
        [DocumentAttributeID("27044")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("FolderItems")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public FolderItems Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        private UserInterfaces _CoUIs;
        /// <summary>
        /// محیطهای کاربری مرتبط
        /// </summary>
        [Description("محیطهای کاربری مرتبط")]
        [DisplayName("محیط های کاربری")]
        [Category("")]
        [DocumentAttributeID("27447")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("UserInterfaces")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public UserInterfaces CoUIs
        {
            get { return _CoUIs; }
            set { _CoUIs = value; }
        }
        private FolderAccessrights _Accessrights;
        /// <summary>
        /// دسترسیهای کارمندان
        /// </summary>
        [Description("دسترسیهای کارمندان")]
        [DisplayName("دسترسی کارمندان")]
        [Category("")]
        [DocumentAttributeID("27495")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("FolderAccessrights")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public FolderAccessrights Accessrights
        {
            get { return _Accessrights; }
            set { _Accessrights = value; }
        }
        public override string ToString()
        {
            return this.Title;
        }
        public override void Initialize()
        {
            base.Initialize();
            this._Parent = new Folder();
            this._Childs = new Folders();
            this._CategoryType = FolderCategoryType.OutOfValue;
            this._Items = new FolderItems();
            this._CoUIs = new UserInterfaces();
            this._Accessrights = new FolderAccessrights();
        }
        public override SbnObject Clone(string sNodeName)
        {
            Folder retObject = new Folder(this);
            if (!object.ReferenceEquals(this.Parent, null))
                retObject.Parent = (Folder)this.Parent.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Childs, null))
                retObject.Childs = (Folders)this.Childs.Clone(sNodeName);
            retObject.CategoryType = this.CategoryType;
            if (!object.ReferenceEquals(this.Items, null))
                retObject.Items = (FolderItems)this.Items.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoUIs, null))
                retObject.CoUIs = (UserInterfaces)this.CoUIs.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Accessrights, null))
                retObject.Accessrights = (FolderAccessrights)this.Accessrights.Clone(sNodeName);
            return retObject;
        }
        public static string at_ParentID
        {
            get
            {
                return "Folder.ParentID";
            }
        }
        public static string at_ParentTitle
        {
            get
            {
                return "Folder.Parent.Title";
            }
        }
        public static string at_ParentFirstLevelAttributes
        {
            get
            {
                return "Folder.ParentFirstLevelAttributes";
            }
        }
        public static string at_Parent_ParentFirstLevelAttributes
        {
            get
            {
                return "Folder.Parent.ParentFirstLevelAttributes";
            }
        }
        public static string at_Parent_ChildsFirstLevelAttributes
        {
            get
            {
                return "Folder.Parent.ChildsFirstLevelAttributes";
            }
        }
        public static string at_Parent_ItemsFirstLevelAttributes
        {
            get
            {
                return "Folder.Parent.ItemsFirstLevelAttributes";
            }
        }
        public static string at_Parent_CoUIsFirstLevelAttributes
        {
            get
            {
                return "Folder.Parent.CoUIsFirstLevelAttributes";
            }
        }
        public static string at_Parent_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "Folder.Parent.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_ChildsID
        {
            get
            {
                return "Folder.ChildsID";
            }
        }
        public static string at_ChildsTitle
        {
            get
            {
                return "Folder.Childs.Title";
            }
        }
        public static string at_ChildsFirstLevelAttributes
        {
            get
            {
                return "Folder.ChildsFirstLevelAttributes";
            }
        }
        public static string at_CategoryType
        {
            get
            {
                return "Folder.CategoryType";
            }
        }
        public static string at_ItemsID
        {
            get
            {
                return "Folder.ItemsID";
            }
        }
        public static string at_ItemsTitle
        {
            get
            {
                return "Folder.Items.Title";
            }
        }
        public static string at_ItemsFirstLevelAttributes
        {
            get
            {
                return "Folder.ItemsFirstLevelAttributes";
            }
        }
        public static string at_CoUIsID
        {
            get
            {
                return "Folder.CoUIsID";
            }
        }
        public static string at_CoUIsTitle
        {
            get
            {
                return "Folder.CoUIs.Title";
            }
        }
        public static string at_CoUIsFirstLevelAttributes
        {
            get
            {
                return "Folder.CoUIsFirstLevelAttributes";
            }
        }
        public static string at_AccessrightsID
        {
            get
            {
                return "Folder.AccessrightsID";
            }
        }
        public static string at_AccessrightsTitle
        {
            get
            {
                return "Folder.Accessrights.Title";
            }
        }
        public static string at_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "Folder.AccessrightsFirstLevelAttributes";
            }
        }
    }
}
