namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("شركت كننده در جلسه كميسيون"), SystemName("GEP"), Description("شركت كننده در جلسه كميسيون"), ObjectCode("9098"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessionMembers")]
    public class CommissionSessionMember : SbnObject
    {
        private MFOrgPosition _CorrelateOrgPosition;
        private MFPerson _CorrelatePerson;
        private CommissionSession _CorrelateSession;
        private string _Description;
        private string _EnterTime;
        private string _ExitTime;
        private SbnBoolean _IsPresent;
        private SbnBoolean _IsStaticMember;
        private SbnBoolean _Justifiable;

        public CommissionSessionMember()
        {
            this._IsPresent = SbnBoolean.OutOfValue;
            this._IsStaticMember = SbnBoolean.OutOfValue;
            this._Justifiable = SbnBoolean.OutOfValue;
        }

        public CommissionSessionMember(SbnObject InitialObject) : base(InitialObject)
        {
            this._IsPresent = SbnBoolean.OutOfValue;
            this._IsStaticMember = SbnBoolean.OutOfValue;
            this._Justifiable = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionSessionMember member = new CommissionSessionMember {
                ID = base.ID,
                EnterTime = this._EnterTime,
                Description = this._Description,
                ExitTime = this._ExitTime
            };
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                member.CorrelateSession = (CommissionSession) this.CorrelateSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelatePerson, null))
            {
                member.CorrelatePerson = (MFPerson) this.CorrelatePerson.Clone(sNodeName);
            }
            member.IsPresent = this.IsPresent;
            member.IsStaticMember = this.IsStaticMember;
            if (!object.ReferenceEquals(this.CorrelateOrgPosition, null))
            {
                member.CorrelateOrgPosition = (MFOrgPosition) this.CorrelateOrgPosition.Clone(sNodeName);
            }
            member.Justifiable = this.Justifiable;
            return member;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._EnterTime = "";
            this._Description = "";
            this._ExitTime = "";
            this._CorrelateSession = new CommissionSession();
            this._CorrelatePerson = new MFPerson();
            this._IsPresent = SbnBoolean.OutOfValue;
            this._IsStaticMember = SbnBoolean.OutOfValue;
            this._CorrelateOrgPosition = new MFOrgPosition();
            this._Justifiable = SbnBoolean.OutOfValue;
        }

        public override string ToString()
        {
            if (this.CorrelatePerson != null)
            {
                return this.CorrelatePerson.ToString();
            }
            return "";
        }

        public static string at_CorrelateOrgPosition_InterdictsFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateOrgPosition.InterdictsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgPosition_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateOrgPosition.OrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgPositionFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateOrgPositionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgPositionID
        {
            get
            {
                return "CommissionSessionMember.CorrelateOrgPositionID";
            }
        }

        public static string at_CorrelatePerson_PicAttachmentFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelatePerson.PicAttachmentFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonID
        {
            get
            {
                return "CommissionSessionMember.CorrelatePersonID";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CommissionSessionTypeFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSession.CommissionSessionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSession.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionMember.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "CommissionSessionMember.CorrelateSessionID";
            }
        }

        public static string at_Description
        {
            get
            {
                return "CommissionSessionMember.Description";
            }
        }

        public static string at_EnterTime
        {
            get
            {
                return "CommissionSessionMember.EnterTime";
            }
        }

        public static string at_ExitTime
        {
            get
            {
                return "CommissionSessionMember.ExitTime";
            }
        }

        public static string at_IsPresent
        {
            get
            {
                return "CommissionSessionMember.IsPresent";
            }
        }

        public static string at_IsStaticMember
        {
            get
            {
                return "CommissionSessionMember.IsStaticMember";
            }
        }

        public static string at_Justifiable
        {
            get
            {
                return "CommissionSessionMember.Justifiable";
            }
        }

        [Browsable(true), RelationTable(""), Description("سمت شخص"), DisplayName("سمت شخص"), Category(""), DocumentAttributeID("9319"), IsRelational("False"), AttributeType("MFOrgPosition"), IsMiddleTableExist("False")]
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

        [Browsable(true), IsRelational("False"), AttributeType("MFPerson"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("شخص مرتبط"), Category(""), DocumentAttributeID("9083"), Description("شخص مرتبط")]
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

        [IsMiddleTableExist("False"), DocumentAttributeID("9082"), AttributeType("CommissionSession"), Description("جلسه کمیسیون"), RelationTable(""), Browsable(true), IsRelational("False"), DisplayName("جلسه مرتبط"), Category("")]
        public CommissionSession CorrelateSession
        {
            get
            {
                return this._CorrelateSession;
            }
            set
            {
                this._CorrelateSession = value;
            }
        }

        [DocumentAttributeID("9236"), IsRelational("false"), Browsable(true), AttributeType("String"), DisplayName("شرح"), Category(""), Description("شرح یا علت حضور در جلسه")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        [DocumentAttributeID("9037"), AttributeType("String"), Browsable(true), DisplayName("زمان ورود"), Category(""), Description("زمان ورود"), IsRelational("false")]
        public string EnterTime
        {
            get
            {
                return this._EnterTime;
            }
            set
            {
                this._EnterTime = value;
            }
        }

        [IsRelational("false"), AttributeType("String"), Browsable(true), DisplayName("زمان خروج"), Category(""), DocumentAttributeID("9235"), Description("زمان خروج")]
        public string ExitTime
        {
            get
            {
                return this._ExitTime;
            }
            set
            {
                this._ExitTime = value;
            }
        }

        [Browsable(true), Description("وضعیت حضور"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), DisplayName("حاضر"), Category(""), DocumentAttributeID("9285")]
        public SbnBoolean IsPresent
        {
            get
            {
                return this._IsPresent;
            }
            set
            {
                this._IsPresent = value;
            }
        }

        [Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("عضو ثابت"), Category(""), DocumentAttributeID("9318"), Description("وضعیت عضویت ثابت یا غیر ثابت")]
        public SbnBoolean IsStaticMember
        {
            get
            {
                return this._IsStaticMember;
            }
            set
            {
                this._IsStaticMember = value;
            }
        }

        [AttributeType("SbnBoolean"), Description("غیبت موجه"), DisplayName("غیبت موجه"), Category(""), DocumentAttributeID("9357"), Browsable(true), IsRelational("False"), IsMiddleTableExist("False"), RelationTable("")]
        public SbnBoolean Justifiable
        {
            get
            {
                return this._Justifiable;
            }
            set
            {
                this._Justifiable = value;
            }
        }
    }
}
