namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using System;
    using System.ComponentModel;


    [Serializable, Description("شركت كننده در جلسه دولت"), DisplayName("شركت كننده در جلسه دولت"), ItemsType("Sbn.Products.GEP.GEPObject.GovSessionMembers"), ObjectCode("9078"), SystemName("GEP")]
    
    public class GovSessionMember : SbnObject
    {
        private PersonnelInterdict _CoInterdict;
        private GovSession _CorrelateSession;
        private string _EnterTime;
        private string _ExitTime;
        private SbnBoolean _IsPresent;
        private SbnBoolean _IsStatic;
        private SbnBoolean _Justifiable;
        private GovSessionMemberOpinions _Opinions;

        public GovSessionMember()
        {
            this._IsPresent = SbnBoolean.OutOfValue;
            this._Justifiable = SbnBoolean.OutOfValue;
            this._IsStatic = SbnBoolean.OutOfValue;
        }

        public GovSessionMember(SbnObject InitialObject)
            : base(InitialObject)
        {
            this._IsPresent = SbnBoolean.OutOfValue;
            this._Justifiable = SbnBoolean.OutOfValue;
            this._IsStatic = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovSessionMember member = new GovSessionMember
            {
                ID = base.ID,
                EnterTime = this._EnterTime
            };
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                member.CorrelateSession = (GovSession)this.CorrelateSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Opinions, null))
            {
                member.Opinions = (GovSessionMemberOpinions)this.Opinions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoInterdict, null))
            {
                member.CoInterdict = (PersonnelInterdict)this.CoInterdict.Clone(sNodeName);
            }
            member.IsPresent = this.IsPresent;
            member.Justifiable = this.Justifiable;
            return member;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._EnterTime = "";
            this._CorrelateSession = new GovSession();
            this._Opinions = new GovSessionMemberOpinions();
            this._CoInterdict = new PersonnelInterdict();
            this._IsPresent = SbnBoolean.OutOfValue;
            this._Justifiable = SbnBoolean.OutOfValue;
            this._IsStatic = SbnBoolean.OutOfValue;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CoInterdict_JobFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.JobFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_OrgPositionFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.OrgPositionFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.OrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_PersonFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.PersonFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_PersonnelFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.PersonnelFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_PersonnelTypeFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.PersonnelTypeFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_WorkerFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdict.WorkerFirstLevelAttributes";
            }
        }

        public static string at_CoInterdictFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CoInterdictFirstLevelAttributes";
            }
        }

        public static string at_CoInterdictID
        {
            get
            {
                return "GovSessionMember.CoInterdictID";
            }
        }

        public static string at_CorrelateSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "GovSessionMember.CorrelateSessionID";
            }
        }

        public static string at_EnterTime
        {
            get
            {
                return "GovSessionMember.EnterTime";
            }
        }

        public static string at_ExitTime
        {
            get
            {
                return "GovSessionMember.ExitTime";
            }
        }

        public static string at_IsPresent
        {
            get
            {
                return "GovSessionMember.IsPresent";
            }
        }

        public static string at_Justifiable
        {
            get
            {
                return "GovSessionMember.Justifiable";
            }
        }

        public static string at_OpinionsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMember.OpinionsFirstLevelAttributes";
            }
        }

        public static string at_OpinionsID
        {
            get
            {
                return "GovSessionMember.OpinionsID";
            }
        }

        public static string at_IsStatic
        {
            get
            {
                return "GovSessionMember.IsStatic";
            }
        }

        [RelationTable(""), DisplayName("پست سازمانی"), Category(""), DocumentAttributeID("27322"), Browsable(true), IsRelational("False"), AttributeType("PersonnelInterdict"), IsMiddleTableExist("False"), Description("پست سازمانی")]
        public PersonnelInterdict CoInterdict
        {
            get
            {
                return this._CoInterdict;
            }
            set
            {
                this._CoInterdict = value;
            }
        }

        [Description("جلسه مرتبط"), DisplayName("جلسه مرتبط"), Category(""), DocumentAttributeID("9054"), Browsable(true), IsRelational("False"), AttributeType("GovSession"), IsMiddleTableExist("False"), RelationTable("")]
        public GovSession CorrelateSession
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

        [DocumentAttributeID("9255"), AttributeType("String"), Browsable(true), DisplayName("زمان ورود"), Category(""), Description("زمان ورود"), IsRelational("false")]
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

        [DocumentAttributeID(""), AttributeType("String"), Browsable(true), DisplayName("زمان خروج"), Category(""), Description("زمان خروج"), IsRelational("false")]
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

        [RelationTable(""), DisplayName("وضعیت حضور"), Category(""), DocumentAttributeID("9360"), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), Description("وضعیت حضور")]
        public SbnBoolean IsPresent
        {
            get
            {
                return this._IsPresent;
            }
            set
            {
                this._IsPresent = value;
                
                //NotifyPropertyChanged("IsPresent");
            }
        }

        [DocumentAttributeID("9361"), DisplayName("غیبت موجه"), Category(""), Description("غیبت موجه"), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), RelationTable("")]
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

        [Description("نظرات"), DisplayName("نظرات"), Category(""), DocumentAttributeID("9052"), Browsable(true), IsRelational("True"), AttributeType("GovSessionMemberOpinions"), IsMiddleTableExist("True"), RelationTable("")]
        public GovSessionMemberOpinions Opinions
        {
            get
            {
                return this._Opinions;
            }
            set
            {
                this._Opinions = value;
            }
        }

        [RelationTable(""), DisplayName("عضو ثابت"), Category(""), DocumentAttributeID(""), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), Description("عضو ثابت")]
        public SbnBoolean IsStatic
        {
            get
            {
                return this._IsStatic;
            }
            set
            {
                this._IsStatic = value;
            }
        }
    }
}
