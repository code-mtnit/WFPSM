namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description("دستگاههاي مرتبط با پيشنهاد"), DisplayName("دستگاههاي مرتبط با پيشنهاد"), ObjectCode("9056"), ItemsType("Sbn.Products.GEP.GEPObject.OfferOrgUnits"), SystemName("GEP")]
    public class OfferOrgUnit : SbnObject
    {
        private Offer _CorrelateOffer;
        private OrgUnit _CorrelateOrgUnit;
        private GEPRellationToOfferType _RelationType;

        public OfferOrgUnit()
        {
            this._RelationType = GEPRellationToOfferType.OutOfValue;
        }

        public OfferOrgUnit(SbnObject InitialObject) : base(InitialObject)
        {
            this._RelationType = GEPRellationToOfferType.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferOrgUnit unit = new OfferOrgUnit {
                ID = base.ID,
                RelationType = this.RelationType
            };
            if (!object.ReferenceEquals(this.CorrelateOrgUnit, null))
            {
                unit.CorrelateOrgUnit = (OrgUnit) this.CorrelateOrgUnit.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                unit.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            return unit;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._RelationType = GEPRellationToOfferType.OutOfValue;
            this._CorrelateOrgUnit = new OrgUnit();
            this._CorrelateOffer = new Offer();
        }

        public override string ToString()
        {
            if (this.CorrelateOrgUnit != null)
            {
                return this.CorrelateOrgUnit.Title;
            }
            return "";
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "OfferOrgUnit.CorrelateOfferID";
            }
        }

        public static string at_CorrelateOrgUnit_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnit.BuildingLocationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgUnit_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnit.MergedUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnit.ParentUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnit.PositionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgUnitFirstLevelAttributes
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgUnitID
        {
            get
            {
                return "OfferOrgUnit.CorrelateOrgUnitID";
            }
        }

        public static string at_RelationType
        {
            get
            {
                return "OfferOrgUnit.RelationType";
            }
        }

        [Description("پیشنهاد مرتبط"), RelationTable(""), DisplayName("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9274"), Browsable(true), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False")]
        public Offer CorrelateOffer
        {
            get
            {
                return this._CorrelateOffer;
            }
            set
            {
                this._CorrelateOffer = value;
            }
        }

        [DocumentAttributeID("9020"), Description("دستگاه مرتبط"), DisplayName("دستگاه مرتبط"), Category(""), Browsable(true), IsRelational("False"), AttributeType("OrgUnit"), IsMiddleTableExist("False"), RelationTable("")]
        public OrgUnit CorrelateOrgUnit
        {
            get
            {
                return this._CorrelateOrgUnit;
            }
            set
            {
                this._CorrelateOrgUnit = value;
            }
        }

        [DocumentAttributeID("9019"), RelationTable(""), Description("نوع ارتباط"), DisplayName("نوع ارتباط"), Category(""), Browsable(true), IsRelational("False"), AttributeType("GEPRellationToOfferType"), IsMiddleTableExist("False")]
        public GEPRellationToOfferType RelationType
        {
            get
            {
                return this._RelationType;
            }
            set
            {
                this._RelationType = value;
            }
        }
    }
}
