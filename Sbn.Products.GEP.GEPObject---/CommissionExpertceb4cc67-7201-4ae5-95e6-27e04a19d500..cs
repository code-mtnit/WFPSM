namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9087"), SystemName("GEP"), DisplayName("كارشناس كميسيون"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionExperts"), Description("كارشناس كميسيون")]
    public class CommissionExpert : SbnObject
    {
        private BasicInfoDetail _CorrelateCommission;
        private WFPerson _CorrelatePerson;
        private string _ExpertID;
        private SbnBoolean _IsActive;
        private SbnBoolean _IsSecretary;

        public CommissionExpert()
        {
            this._IsActive = SbnBoolean.OutOfValue;
            this._IsSecretary = SbnBoolean.OutOfValue;
        }

        public CommissionExpert(SbnObject InitialObject) : base(InitialObject)
        {
            this._IsActive = SbnBoolean.OutOfValue;
            this._IsSecretary = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionExpert expert = new CommissionExpert {
                ID = base.ID,
                ExpertID = this._ExpertID
            };
            if (!object.ReferenceEquals(this.CorrelateCommission, null))
            {
                expert.CorrelateCommission = (BasicInfoDetail) this.CorrelateCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelatePerson, null))
            {
                expert.CorrelatePerson = (WFPerson) this.CorrelatePerson.Clone(sNodeName);
            }
            expert.IsActive = this.IsActive;
            expert.IsSecretary = this.IsSecretary;
            return expert;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._ExpertID = "";
            this._CorrelateCommission = new BasicInfoDetail();
            this._CorrelatePerson = new WFPerson();
            this._IsActive = SbnBoolean.OutOfValue;
            this._IsSecretary = SbnBoolean.OutOfValue;
        }

        public override string ToString()
        {
            if (this.CorrelatePerson != null)
            {
                return (this.CorrelatePerson.SurName + " " + this.CorrelatePerson.FirstName);
            }
            return "";
        }

        public static string at_CorrelateCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "CommissionExpert.CorrelateCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "CommissionExpert.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionID
        {
            get
            {
                return "CommissionExpert.CorrelateCommissionID";
            }
        }

        public static string at_CorrelatePerson_SexFirstLevelAttributes
        {
            get
            {
                return "CommissionExpert.CorrelatePerson.SexFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePerson_WorkersFirstLevelAttributes
        {
            get
            {
                return "CommissionExpert.CorrelatePerson.WorkersFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "CommissionExpert.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelatePersonID
        {
            get
            {
                return "CommissionExpert.CorrelatePersonID";
            }
        }

        public static string at_ExpertID
        {
            get
            {
                return "CommissionExpert.ExpertID";
            }
        }

        public static string at_IsActive
        {
            get
            {
                return "CommissionExpert.IsActive";
            }
        }

        public static string at_IsSecretary
        {
            get
            {
                return "CommissionExpert.IsSecretary";
            }
        }

        [Category(""), DocumentAttributeID("9063"), RelationTable(""), Browsable(true), IsRelational("False"), Description("کمیسیون مرتبط"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), DisplayName("کمیسیون مرتبط")]
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

        [IsRelational("False"), Description("شخص مرتبط با کارشناس"), Category(""), DocumentAttributeID("9323"), Browsable(true), AttributeType("WFPerson"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("نام کارشناس")]
        public WFPerson CorrelatePerson
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

        [AttributeType("String"), Category(""), DisplayName("کد کارشناس"), IsRelational("false"), DocumentAttributeID("9028"), Browsable(true), Description("کد داخلی کارشناس در کمیسیون")]
        public string ExpertID
        {
            get
            {
                return this._ExpertID;
            }
            set
            {
                this._ExpertID = value;
            }
        }

        [Browsable(true), Description("وضعیت"), Category(""), DocumentAttributeID("9356"), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("وضعیت")]
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

        [Description("دبیر کمیسیون"), DisplayName("دبیر کمیسیون"), Category(""), DocumentAttributeID("27038"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), AttributeType("SbnBoolean"), Browsable(true)]
        public SbnBoolean IsSecretary
        {
            get
            {
                return this._IsSecretary;
            }
            set
            {
                this._IsSecretary = value;
            }
        }
    }
}
