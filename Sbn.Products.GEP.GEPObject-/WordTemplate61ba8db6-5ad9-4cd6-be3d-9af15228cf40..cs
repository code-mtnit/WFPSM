namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("الگوي Word"), DisplayName("الگوي Word"), ObjectCode("9074"), ItemsType("Sbn.Products.GEP.GEPObject.WordTemplates")]
    public class WordTemplate : SbnBinary
    {
        private Sbn.Products.GEP.GEPObject.Bookmarks _Bookmarks;
        private BasicInfoDetail _CorrelateCommission;
        private SbnBoolean _IsActive;

        public WordTemplate()
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public WordTemplate(SbnBinary InitialObject) : base(InitialObject)
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            WordTemplate template = new WordTemplate {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.Bookmarks, null))
            {
                template.Bookmarks = (Sbn.Products.GEP.GEPObject.Bookmarks) this.Bookmarks.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateCommission, null))
            {
                template.CorrelateCommission = (BasicInfoDetail) this.CorrelateCommission.Clone(sNodeName);
            }
            template.IsActive = this.IsActive;
            template.Extension = this.Extension;
            return template;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Bookmarks = new Sbn.Products.GEP.GEPObject.Bookmarks();
            this._CorrelateCommission = new BasicInfoDetail();
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public override string ToString()
        {
            try
            {
                return base.Title;
            }
            catch
            {
            }
            return "";
        }

        public static string at_BookmarksFirstLevelAttributes
        {
            get
            {
                return "WordTemplate.BookmarksFirstLevelAttributes";
            }
        }

        public static string at_BookmarksID
        {
            get
            {
                return "WordTemplate.BookmarksID";
            }
        }

        public static string at_CorrelateCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "WordTemplate.CorrelateCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "WordTemplate.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionID
        {
            get
            {
                return "WordTemplate.CorrelateCommissionID";
            }
        }

        public static string at_IsActive
        {
            get
            {
                return "WordTemplate.IsActive";
            }
        }

        public static string at_Extension
        {
            get
            {
                return "WordTemplate.Extension";
            }
        }

        [RelationTable("WORDTEMPLATE_BOOKMARKS_M"), Description(""), DisplayName(""), Category(""), DocumentAttributeID("9041"), Browsable(true), IsRelational("False"), AttributeType("Bookmarks"), IsMiddleTableExist("False")]
        public Sbn.Products.GEP.GEPObject.Bookmarks Bookmarks
        {
            get
            {
                return this._Bookmarks;
            }
            set
            {
                this._Bookmarks = value;
            }
        }

        [DocumentAttributeID("9349"), Description("کمیسیون مرتبط"), DisplayName("کمیسیون مرتبط"), Category(""), IsMiddleTableExist("False"), RelationTable(""), AttributeType("BasicInfoDetail"), Browsable(true), IsRelational("False")]
        public BasicInfoDetail CorrelateCommission
        {
            get
            {
                return this._CorrelateCommission;
            }
            set
            {
                this._CorrelateCommission = value;
            }
        }

        [RelationTable(""), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), Description("فعال"), DisplayName("فعال"), Category(""), DocumentAttributeID("9400"), Browsable(true), IsRelational("False")]
        public SbnBoolean IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }

        string _Extension;
        [AttributeType("string"),
        DisplayName("پسوند فایل"),
        Category(""),
        DocumentAttributeID(""),
        IsMiddleTableExist("False"),
        RelationTable(""),
        Browsable(true),
        IsRelational("False"),
        Description("پسوند فایل سند")]
        public string Extension
        {
            get
            {
                return this._Extension;
            }
            set
            {
                this._Extension = value;
            }
        }
    }
}
