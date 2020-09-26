namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.OPS.OPSObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("عضو ثابت دولت"), DisplayName("عضو ثابت دولت"), ObjectCode("9243"), ItemsType("Sbn.Products.GEP.GEPObject.GovernStaticMembers")]
    public class GovernStaticMember : SbnObject
    {
        private PersonnelInterdict _CoInterdict;
        private SbnBoolean _IsActive;

        public GovernStaticMember()
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public GovernStaticMember(SbnObject InitialObject) : base(InitialObject)
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovernStaticMember member = new GovernStaticMember {
                ID = base.ID,
                IsActive = this.IsActive
            };
            if (!object.ReferenceEquals(this.CoInterdict, null))
            {
                member.CoInterdict = (PersonnelInterdict) this.CoInterdict.Clone(sNodeName);
            }
            return member;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._IsActive = SbnBoolean.OutOfValue;
            this._CoInterdict = new PersonnelInterdict();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CoInterdict_JobFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.JobFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_OrgPositionFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.OrgPositionFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.OrgUnitFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_PersonFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.PersonFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_PersonnelFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.PersonnelFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_PersonnelTypeFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.PersonnelTypeFirstLevelAttributes";
            }
        }

        public static string at_CoInterdict_WorkerFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdict.WorkerFirstLevelAttributes";
            }
        }

        public static string at_CoInterdictFirstLevelAttributes
        {
            get
            {
                return "GovernStaticMember.CoInterdictFirstLevelAttributes";
            }
        }

        public static string at_CoInterdictID
        {
            get
            {
                return "GovernStaticMember.CoInterdictID";
            }
        }

        public static string at_IsActive
        {
            get
            {
                return "GovernStaticMember.IsActive";
            }
        }

        [RelationTable(""), AttributeType("PersonnelInterdict"), IsMiddleTableExist("False"), DisplayName("حکم سازمانی"), Category(""), DocumentAttributeID("27321"), Browsable(true), IsRelational("False"), Description("حکم سازمانی مرتبط")]
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

        [Description("وضعیت فعال"), DisplayName("وضعیت فعال"), Category(""), DocumentAttributeID("9298"), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), RelationTable("")]
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
    }
}
