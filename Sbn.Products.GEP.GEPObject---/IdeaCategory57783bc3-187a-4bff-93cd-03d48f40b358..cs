namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Products.GEP.GEPObject.TMU;
    using System;
    using System.ComponentModel;

    [Serializable, Description("دسته بندي نظريات"), DisplayName("دسته بندي نظريات"), ObjectCode("9301"), ItemsType("Sbn.Products.GEP.GEPObject.IdeaCategories"), SystemName("GEP")]
    public class IdeaCategory : SbnObject
    {
        private Idea _CorrelateIdea;
        private Subject _CorrelateSubject;
        private string _SubjectPath;

        public IdeaCategory()
        {
        }

        public IdeaCategory(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            IdeaCategory category = new IdeaCategory {
                ID = base.ID,
                SubjectPath = this._SubjectPath
            };
            if (!object.ReferenceEquals(this.CorrelateIdea, null))
            {
                category.CorrelateIdea = (Idea) this.CorrelateIdea.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateSubject, null))
            {
                category.CorrelateSubject = (Subject) this.CorrelateSubject.Clone(sNodeName);
            }
            return category;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._SubjectPath = "";
            this._CorrelateIdea = new Idea();
            this._CorrelateSubject = new Subject();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateIdea_CategoriesFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateIdea.CategoriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdea_CoUnitFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateIdea.CoUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdea_ReferencesFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateIdea.ReferencesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdea_StatusFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateIdea.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdeaFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateIdeaFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdeaID
        {
            get
            {
                return "IdeaCategory.CorrelateIdeaID";
            }
        }

        public static string at_CorrelateSubject_CommissionTypeFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateSubject.CommissionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSubject_TitleTypeFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateSubject.TitleTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSubjectFirstLevelAttributes
        {
            get
            {
                return "IdeaCategory.CorrelateSubjectFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSubjectID
        {
            get
            {
                return "IdeaCategory.CorrelateSubjectID";
            }
        }

        public static string at_SubjectPath
        {
            get
            {
                return "IdeaCategory.SubjectPath";
            }
        }

        [DocumentAttributeID("27231"), RelationTable(""), DisplayName("نظریه مرتبط"), Category("مشخصات اصلی"), AttributeType("Idea"), IsMiddleTableExist("False"), IsRelational("False"), Description("نظریه مرتبط"), Browsable(true)]
        public Idea CorrelateIdea
        {
            get
            {
                return this._CorrelateIdea;
            }
            set
            {
                this._CorrelateIdea = value;
            }
        }

        [IsRelational("False"), Description("موضوع مرتبط"), AttributeType("Subject"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("موضوع مرتبط"), Category("مشخصات اصلی"), DocumentAttributeID("27232"), Browsable(true)]
        public Subject CorrelateSubject
        {
            get
            {
                return this._CorrelateSubject;
            }
            set
            {
                this._CorrelateSubject = value;
            }
        }

        [Category("مشخصات فرعی"), Browsable(true), DocumentAttributeID("27147"), IsRelational("false"), Description("مسیر موضوعات"), DisplayName("مسیر موضوعات"), AttributeType("String")]
        public string SubjectPath
        {
            get
            {
                return this._SubjectPath;
            }
            set
            {
                this._SubjectPath = value;
            }
        }
    }
}
