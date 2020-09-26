namespace Sbn.Products.GAP.GAPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GAP.GAPObject.Pursuits"), DisplayName("پيگيري"), ObjectCode("10000"), Description("پيگيري"), SystemName("GAP")]
    public class Pursuit : SbnObject
    {
        private Document _CoDocuemnt;
        private DocumentType _CoDocumentType;
        private OrgUnit _CoOrgan;
        private string _OpportunityDate;
        private string _PursuitReport;
        private PursuitResponses _Responses;

        public Pursuit()
        {
        }

        public Pursuit(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Pursuit pursuit = new Pursuit(this);
            if (this._PursuitReport != null)
            {
                pursuit.PursuitReport = (string) this._PursuitReport.Clone();
            }
            if (this._OpportunityDate != null)
            {
                pursuit.OpportunityDate = (string) this._OpportunityDate.Clone();
            }
            if (!object.ReferenceEquals(this.CoOrgan, null))
            {
                pursuit.CoOrgan = (OrgUnit) this.CoOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Responses, null))
            {
                pursuit.Responses = (PursuitResponses) this.Responses.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoDocumentType, null))
            {
                pursuit.CoDocumentType = (DocumentType) this.CoDocumentType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoDocuemnt, null))
            {
                pursuit.CoDocuemnt = (Document) this.CoDocuemnt.Clone(sNodeName);
            }
            return pursuit;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._PursuitReport = "";
            this._OpportunityDate = "";
            this._CoOrgan = new OrgUnit();
            this._Responses = new PursuitResponses();
            this._CoDocumentType = new DocumentType();
            this._CoDocuemnt = new Document();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CoDocuemntFirstLevelAttributes
        {
            get
            {
                return "Pursuit.CoDocuemntFirstLevelAttributes";
            }
        }

        public static string at_CoDocuemntID
        {
            get
            {
                return "Pursuit.CoDocuemntID";
            }
        }

        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Pursuit.CoDocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentTypeID
        {
            get
            {
                return "Pursuit.CoDocumentTypeID";
            }
        }

        public static string at_CoOrganFirstLevelAttributes
        {
            get
            {
                return "Pursuit.CoOrganFirstLevelAttributes";
            }
        }

        public static string at_CoOrganID
        {
            get
            {
                return "Pursuit.CoOrganID";
            }
        }

        public static string at_OpportunityDate
        {
            get
            {
                return "Pursuit.OpportunityDate";
            }
        }

        public static string at_PursuitReport
        {
            get
            {
                return "Pursuit.PursuitReport";
            }
        }

        public static string at_ResponsesFirstLevelAttributes
        {
            get
            {
                return "Pursuit.ResponsesFirstLevelAttributes";
            }
        }

        public static string at_ResponsesID
        {
            get
            {
                return "Pursuit.ResponsesID";
            }
        }

        [DisplayName("سند مرتبط"), IsMiddleTableExist("False"), RelationTable(""), Description("سند مرتبط"), IsRelational("False"), AttributeType("Document"), DocumentAttributeID("27342"), Browsable(true), Category("")]
        public Document CoDocuemnt
        {
            get
            {
                return this._CoDocuemnt;
            }
            set
            {
                this._CoDocuemnt = value;
            }
        }

        [Browsable(true), IsRelational("False"), AttributeType("DocumentType"), IsMiddleTableExist("False"), RelationTable(""), Description("نوع سند مورد پیگیری"), DisplayName("نوع سند"), Category(""), DocumentAttributeID("27341")]
        public DocumentType CoDocumentType
        {
            get
            {
                return this._CoDocumentType;
            }
            set
            {
                this._CoDocumentType = value;
            }
        }

        [IsMiddleTableExist("False"), DisplayName("دستگاه مرتبط"), Category(""), DocumentAttributeID("27329"), Browsable(true), IsRelational("False"), AttributeType("OrgUnit"), Description("دستگاه مرتبط"), RelationTable("")]
        public OrgUnit CoOrgan
        {
            get
            {
                return this._CoOrgan;
            }
            set
            {
                this._CoOrgan = value;
            }
        }

        [IsRelational("false"), DisplayName("مهلت ارسال پاسخ"), Browsable(true), DocumentAttributeID("27154"), AttributeType("DateString"), Category(""), Description("مهلت ارسال پاسخ")]
        public string OpportunityDate
        {
            get
            {
                return this._OpportunityDate;
            }
            set
            {
                this._OpportunityDate = value;
            }
        }

        [Browsable(true), Description("گزارش پیگیری"), DisplayName("گزارش پیگیری"), Category(""), DocumentAttributeID("27157"), IsRelational("false"), AttributeType("LongText")]
        public string PursuitReport
        {
            get
            {
                return this._PursuitReport;
            }
            set
            {
                this._PursuitReport = value;
            }
        }

        [RelationTable(""), Description("پاسخها"), DisplayName("پاسخها"), Category(""), IsMiddleTableExist("True"), DocumentAttributeID("27337"), Browsable(true), IsRelational("True"), AttributeType("PursuitResponses")]
        public PursuitResponses Responses
        {
            get
            {
                return this._Responses;
            }
            set
            {
                this._Responses = value;
            }
        }
    }
}
