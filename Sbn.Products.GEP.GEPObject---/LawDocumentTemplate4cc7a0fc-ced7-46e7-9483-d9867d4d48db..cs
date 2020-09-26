namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.LawDocumentTemplates"), DisplayName("الگوي مستند قانوني كه براي كارشناسان كميسيونها مورد استفاده قرار مي گيرد"), ObjectCode("9278"), Description("الگوي مستند قانوني كه براي كارشناسان كميسيونها مورد استفاده قرار مي گيرد"), SystemName("GEP")]
    public class LawDocumentTemplate : SbnObject
    {
        private string _DocText;
        private BasicInfoDetail _ReCommission;
        private string _Title;

        public LawDocumentTemplate()
        {
        }

        public LawDocumentTemplate(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            LawDocumentTemplate template = new LawDocumentTemplate {
                ID = base.ID,
                Title = this._Title
            };
            if (this._DocText != null)
            {
                template.DocText = (string) this._DocText.Clone();
            }
            if (!object.ReferenceEquals(this.ReCommission, null))
            {
                template.ReCommission = (BasicInfoDetail) this.ReCommission.Clone(sNodeName);
            }
            return template;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Title = "";
            this._DocText = "";
            this._ReCommission = new BasicInfoDetail();
        }

        public override string ToString()
        {
            return (this.Title ?? "");
        }

        public static string at_DocText
        {
            get
            {
                return "LawDocumentTemplate.DocText";
            }
        }

        public static string at_ReCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "LawDocumentTemplate.ReCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_ReCommissionFirstLevelAttributes
        {
            get
            {
                return "LawDocumentTemplate.ReCommissionFirstLevelAttributes";
            }
        }

        public static string at_ReCommissionID
        {
            get
            {
                return "LawDocumentTemplate.ReCommissionID";
            }
        }

        public static string at_Title
        {
            get
            {
                return "LawDocumentTemplate.Title";
            }
        }

        [DocumentAttributeID("9266"), IsRelational("false"), AttributeType("LongText"), Browsable(true), Description("متن"), DisplayName("متن"), Category("")]
        public string DocText
        {
            get
            {
                return this._DocText;
            }
            set
            {
                this._DocText = value;
            }
        }

        [RelationTable(""), Description("کمیسیون"), DisplayName("کمیسیون"), Category(""), DocumentAttributeID("9403"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail ReCommission
        {
            get
            {
                return this._ReCommission;
            }
            set
            {
                this._ReCommission = value;
            }
        }

        [Browsable(true), DocumentAttributeID("9265"), Description("عنوان"), DisplayName("عنوان"), AttributeType("String"), IsRelational("false"), Category("")]
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
