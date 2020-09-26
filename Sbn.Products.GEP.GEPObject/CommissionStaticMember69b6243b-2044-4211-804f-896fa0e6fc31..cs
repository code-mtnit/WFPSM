namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.CommissionStaticMembers"), SystemName("GEP"), ObjectCode("9245"), Description("اعضاء ثابت كميسيونهاي دولت"), DisplayName("اعضاء ثابت كميسيونهاي دولت")]
    public class CommissionStaticMember : SbnObject
    {
        private BasicInfoDetail _CorrelateCommission;
        private MFOrgPosition _CorrelateOrgPosition;
        private MFPerson _CorrelatePerson;
        private SbnBoolean _IsActive;
        private BasicInfoDetail _SessionType;

        public CommissionStaticMember()
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public CommissionStaticMember(SbnObject InitialObject) : base(InitialObject)
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionStaticMember member = new CommissionStaticMember {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CorrelatePerson, null))
            {
                member.CorrelatePerson = (MFPerson) this.CorrelatePerson.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateCommission, null))
            {
                member.CorrelateCommission = (BasicInfoDetail) this.CorrelateCommission.Clone(sNodeName);
            }
            member.IsActive = this.IsActive;
            if (!object.ReferenceEquals(this.SessionType, null))
            {
                member.SessionType = (BasicInfoDetail) this.SessionType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOrgPosition, null))
            {
                member.CorrelateOrgPosition = (MFOrgPosition) this.CorrelateOrgPosition.Clone(sNodeName);
            }
            return member;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CorrelatePerson = new MFPerson();
            this._CorrelateCommission = new BasicInfoDetail();
            this._IsActive = SbnBoolean.OutOfValue;
            this._SessionType = new BasicInfoDetail();
            this._CorrelateOrgPosition = new MFOrgPosition();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelateCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionID
        {
            get
            {
                return "CommissionStaticMember.CorrelateCommissionID";
            }
        }

        public static string at_CorrelateOrgPosition_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelateOrgPosition.OrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgPosition_PersonnelInterdictsFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelateOrgPosition.PersonnelInterdictsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgPositionFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelateOrgPositionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgPositionID
        {
            get
            {
                return "CommissionStaticMember.CorrelateOrgPositionID";
            }
        }

        public static string at_CorrelatePerson_PicAttachmentFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelatePerson.PicAttachmentFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonID
        {
            get
            {
                return "CommissionStaticMember.CorrelatePersonID";
            }
        }

        public static string at_IsActive
        {
            get
            {
                return "CommissionStaticMember.IsActive";
            }
        }

        public static string at_SessionType_ParentFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.SessionType.ParentFirstLevelAttributes";
            }
        }

        public static string at_SessionTypeFirstLevelAttributes
        {
            get
            {
                return "CommissionStaticMember.SessionTypeFirstLevelAttributes";
            }
        }

        public static string at_SessionTypeID
        {
            get
            {
                return "CommissionStaticMember.SessionTypeID";
            }
        }

        [AttributeType("BasicInfoDetail"), Description("نام کمیسیون"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("نام کمیسیون"), Category(""), DocumentAttributeID("9300"), Browsable(true), IsRelational("False")]
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

        [DisplayName("سمت"), AttributeType("OrgPositionMF"), Description("سمت شخص مرتبط"), IsMiddleTableExist("False"), RelationTable(""), Category(""), DocumentAttributeID("9320"), Browsable(true), IsRelational("False")]
        public MFOrgPosition CorrelateOrgPosition
        {
            get
            {
                return this._CorrelateOrgPosition;
            }
            set
            {
                this._CorrelateOrgPosition = value;
            }
        }

        [AttributeType("MFPerson"), DisplayName("نام وزیر"), IsMiddleTableExist("False"), Category(""), DocumentAttributeID("9299"), RelationTable(""), Description("نام وزیر"), Browsable(true), IsRelational("False")]
        public MFPerson CorrelatePerson
        {
            get
            {
                return this._CorrelatePerson;
            }
            set
            {
                this._CorrelatePerson = value;
            }
        }

        [AttributeType("SbnBoolean"), RelationTable(""), DisplayName("وضعیت"), Category(""), DocumentAttributeID("9301"), Browsable(true), IsRelational("False"), Description("وضعیت فعال یا غیر فعال"), IsMiddleTableExist("False")]
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

        [Description("نوع جلسه"), DisplayName("نوع جلسه"), Category(""), DocumentAttributeID("9373"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable("")]
        public BasicInfoDetail SessionType
        {
            get
            {
                return this._SessionType;
            }
            set
            {
                this._SessionType = value;
            }
        }
    }
}
