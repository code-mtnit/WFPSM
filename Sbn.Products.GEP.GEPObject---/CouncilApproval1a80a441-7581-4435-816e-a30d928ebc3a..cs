namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.CouncilApprovals"), Description(""), DisplayName(""), ObjectCode("9289"), SystemName("GEP")]
    public class CouncilApproval : SbnObject
    {
        private Letter _CoLetter;
        private OrgUnit _CoOrgUnit;
        private BasicInfoDetail _CouncilType;

        public CouncilApproval()
        {
        }

        public CouncilApproval(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            CouncilApproval approval = new CouncilApproval {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CoLetter, null))
            {
                approval.CoLetter = (Letter) this.CoLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CouncilType, null))
            {
                approval.CouncilType = (BasicInfoDetail) this.CouncilType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoOrgUnit, null))
            {
                approval.CoOrgUnit = (OrgUnit) this.CoOrgUnit.Clone(sNodeName);
            }
            return approval;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CoLetter = new Letter();
            this._CouncilType = new BasicInfoDetail();
            this._CoOrgUnit = new OrgUnit();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CoLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CoLetterFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetterID
        {
            get
            {
                return "CouncilApproval.CoLetterID";
            }
        }

        public static string at_CoOrgUnit_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoOrgUnit.BuildingLocationFirstLevelAttributes";
            }
        }

        public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoOrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }

        public static string at_CoOrgUnit_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoOrgUnit.MergedUnitFirstLevelAttributes";
            }
        }

        public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoOrgUnit.ParentUnitFirstLevelAttributes";
            }
        }

        public static string at_CoOrgUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoOrgUnit.PositionsFirstLevelAttributes";
            }
        }

        public static string at_CoOrgUnitFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CoOrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CoOrgUnitID
        {
            get
            {
                return "CouncilApproval.CoOrgUnitID";
            }
        }

        public static string at_CouncilType_ParentFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CouncilType.ParentFirstLevelAttributes";
            }
        }

        public static string at_CouncilTypeFirstLevelAttributes
        {
            get
            {
                return "CouncilApproval.CouncilTypeFirstLevelAttributes";
            }
        }

        public static string at_CouncilTypeID
        {
            get
            {
                return "CouncilApproval.CouncilTypeID";
            }
        }

        [IsRelational("False"), RelationTable(""), Description("نامه مرتبط"), DisplayName("نامه مرتبط"), Category("مشخصات اصلی"), DocumentAttributeID("27127"), Browsable(true), AttributeType("Letter"), IsMiddleTableExist("False")]
        public Letter CoLetter
        {
            get
            {
                return this._CoLetter;
            }
            set
            {
                this._CoLetter = value;
            }
        }

        [DisplayName("سازمان مرتبط"), DocumentAttributeID("27129"), IsRelational("False"), Browsable(true), IsMiddleTableExist("False"), AttributeType("OrgUnit"), RelationTable(""), Description("سازمان مرتبط"), Category("مشخصات اصلی")]
        public OrgUnit CoOrgUnit
        {
            get
            {
                return this._CoOrgUnit;
            }
            set
            {
                this._CoOrgUnit = value;
            }
        }

        [AttributeType("BasicInfoDetail"), RelationTable(""), Description("نوع شورا"), DisplayName("نوع شورا"), Category("مشخصات اصلی"), DocumentAttributeID("27128"), Browsable(true), IsRelational("False"), IsMiddleTableExist("False")]
        public BasicInfoDetail CouncilType
        {
            get
            {
                return this._CouncilType;
            }
            set
            {
                this._CouncilType = value;
            }
        }
    }
}
