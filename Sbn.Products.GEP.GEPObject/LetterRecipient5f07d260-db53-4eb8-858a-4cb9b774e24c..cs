namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9091"), ItemsType("Sbn.Products.GEP.GEPObject.LetterRecipients"), Description("گيرنده نامه"), SystemName("GEP"), DisplayName("گيرنده نامه")]
    public class LetterRecipient : SbnObject
    {
        private Letter _CorrelateLetter;
        private OrgUnit _CorrelateOrgan;
        private PersonnelInterdict _CorrelatePersonnel;
        private string _ReceiptDate;
        private string _ReceiptDescription;
        private BasicInfoDetail _ReceiptType;

        public LetterRecipient()
        {
        }

        public LetterRecipient(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            LetterRecipient recipient = new LetterRecipient {
                ID = base.ID
            };
            if (this._ReceiptDate != null)
            {
                recipient.ReceiptDate = (string) this._ReceiptDate.Clone();
            }
            recipient.ReceiptDescription = this._ReceiptDescription;
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                recipient.CorrelateLetter = (Letter) this.CorrelateLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ReceiptType, null))
            {
                recipient.ReceiptType = (BasicInfoDetail) this.ReceiptType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOrgan, null))
            {
                recipient.CorrelateOrgan = (OrgUnit) this.CorrelateOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelatePersonnel, null))
            {
                recipient.CorrelatePersonnel = (PersonnelInterdict) this.CorrelatePersonnel.Clone(sNodeName);
            }
            return recipient;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._ReceiptDate = "";
            this._ReceiptDescription = "";
            this._CorrelateLetter = new Letter();
            this._ReceiptType = new BasicInfoDetail();
            this._CorrelateOrgan = new OrgUnit();
            this._CorrelatePersonnel = new PersonnelInterdict();
        }

        public override string ToString()
        {
            if ((this.CorrelatePersonnel != null) && (this.CorrelatePersonnel.Person == null))
            {
                return this.CorrelatePersonnel.Person.ToString();
            }
            return "";
        }

        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "LetterRecipient.CorrelateLetterID";
            }
        }

        public static string at_CorrelateOrgan_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateOrgan.BuildingLocationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateOrgan.ChildUnitsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateOrgan.MergedUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateOrgan.ParentUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_PositionsFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateOrgan.PositionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrganFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelateOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrganID
        {
            get
            {
                return "LetterRecipient.CorrelateOrganID";
            }
        }

        public static string at_CorrelatePersonnel_OrgPositionFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnel.OrgPositionFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonnel_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnel.OrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonnel_PersonFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnel.PersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonnel_PersonnelFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnel.PersonnelFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonnel_WorkerFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnel.WorkerFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonnelFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnelFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonnelID
        {
            get
            {
                return "LetterRecipient.CorrelatePersonnelID";
            }
        }

        public static string at_ReceiptDate
        {
            get
            {
                return "LetterRecipient.ReceiptDate";
            }
        }

        public static string at_ReceiptDescription
        {
            get
            {
                return "LetterRecipient.ReceiptDescription";
            }
        }

        public static string at_ReceiptType_ParentFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.ReceiptType.ParentFirstLevelAttributes";
            }
        }

        public static string at_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "LetterRecipient.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_ReceiptTypeID
        {
            get
            {
                return "LetterRecipient.ReceiptTypeID";
            }
        }

        [AttributeType("Letter"), RelationTable(""), Description("نامه مرتبط"), DisplayName("نامه مرتبط"), Category(""), DocumentAttributeID("9078"), Browsable(true), IsRelational("False"), IsMiddleTableExist("False")]
        public Letter CorrelateLetter
        {
            get
            {
                return this._CorrelateLetter;
            }
            set
            {
                this._CorrelateLetter = value;
            }
        }

        [Description("دستگاه گیرنده برای نامه های استعلام یا مصوبه"), Browsable(true), RelationTable(""), DisplayName("دستگاه"), Category(""), DocumentAttributeID("9268"), IsRelational("False"), AttributeType("OrgUnit"), IsMiddleTableExist("False")]
        public OrgUnit CorrelateOrgan
        {
            get
            {
                return this._CorrelateOrgan;
            }
            set
            {
                this._CorrelateOrgan = value;
            }
        }

        [AttributeType("PersonnelInterdict"), IsRelational("False"), IsMiddleTableExist("False"), Browsable(true), RelationTable(""), Description("شخص گیرنده"), DisplayName("عنوان"), Category(""), DocumentAttributeID("9371")]
        public PersonnelInterdict CorrelatePersonnel
        {
            get
            {
                return this._CorrelatePersonnel;
            }
            set
            {
                this._CorrelatePersonnel = value;
            }
        }

        [DisplayName("تاریخ دریافت"), AttributeType("DateString"), Browsable(true), Description("تاریخ دریافت"), Category(""), DocumentAttributeID("9209"), IsRelational("false")]
        public string ReceiptDate
        {
            get
            {
                return this._ReceiptDate;
            }
            set
            {
                this._ReceiptDate = value;
            }
        }

        [Description("شرح رونوشت"), Browsable(true), DisplayName("شرح رونوشت"), Category(""), DocumentAttributeID("9213"), IsRelational("false"), AttributeType("String")]
        public string ReceiptDescription
        {
            get
            {
                return this._ReceiptDescription;
            }
            set
            {
                this._ReceiptDescription = value;
            }
        }

        [Browsable(true), RelationTable(""), IsMiddleTableExist("False"), Description("نوع دریافت اصل یا رونوشت"), DisplayName("نوع دریافت"), Category(""), DocumentAttributeID("9073"), IsRelational("False"), AttributeType("BasicInfoDetail")]
        public BasicInfoDetail ReceiptType
        {
            get
            {
                return this._ReceiptType;
            }
            set
            {
                this._ReceiptType = value;
            }
        }
    }
}
