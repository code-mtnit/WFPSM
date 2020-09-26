namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9105"), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.Laws"), Description("قانون"), DisplayName("قانون")]
    public class Law : SbnObject
    {
        private string _LawDate;
        private string _LawText;
        private BasicInfoDetail _LowSourceType;
        private string _Title;

        public Law()
        {
        }

        public Law(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Law law = new Law {
                ID = base.ID,
                Title = this._Title
            };
            if (this._LawDate != null)
            {
                law.LawDate = (string) this._LawDate.Clone();
            }
            law.LawText = this._LawText;
            if (!object.ReferenceEquals(this.LowSourceType, null))
            {
                law.LowSourceType = (BasicInfoDetail) this.LowSourceType.Clone(sNodeName);
            }
            return law;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Title = "";
            this._LawDate = "";
            this._LawText = "";
            this._LowSourceType = new BasicInfoDetail();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_LawDate
        {
            get
            {
                return "Law.LawDate";
            }
        }

        public static string at_LawText
        {
            get
            {
                return "Law.LawText";
            }
        }

        public static string at_LowSourceType_ParentFirstLevelAttributes
        {
            get
            {
                return "Law.LowSourceType.ParentFirstLevelAttributes";
            }
        }

        public static string at_LowSourceTypeFirstLevelAttributes
        {
            get
            {
                return "Law.LowSourceTypeFirstLevelAttributes";
            }
        }

        public static string at_LowSourceTypeID
        {
            get
            {
                return "Law.LowSourceTypeID";
            }
        }

        public static string at_Title
        {
            get
            {
                return "Law.Title";
            }
        }

        [Category(""), DocumentAttributeID("9043"), IsRelational("false"), AttributeType("DateString"), Browsable(true), Description("تاریخ"), DisplayName("تاریخ")]
        public string LawDate
        {
            get
            {
                return this._LawDate;
            }
            set
            {
                this._LawDate = value;
            }
        }

        [DisplayName("متن"), Description("متن"), DocumentAttributeID("9044"), IsRelational("false"), AttributeType("LongText"), Category(""), Browsable(true)]
        public string LawText
        {
            get
            {
                return this._LawText;
            }
            set
            {
                this._LawText = value;
            }
        }

        [DocumentAttributeID("9353"), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), DisplayName("منبع"), Description("منبع"), Category("")]
        public BasicInfoDetail LowSourceType
        {
            get
            {
                return this._LowSourceType;
            }
            set
            {
                this._LowSourceType = value;
            }
        }

        [Browsable(true), Description("عنوان"), DisplayName("عنوان"), Category(""), DocumentAttributeID("9042"), IsRelational("false"), AttributeType("String")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
    }
}
