namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ObjectCode("9302"), ItemsType("Sbn.Products.GEP.GEPObject.Ideas"), SystemName("GEP")]
    public class Idea : SbnObject
    {
        private string _Brief;
        private IdeaCategories _Categories;
        private string _CompleteText;
        private BasicInfoDetail _CoUnit;
        private string _Creator;
        private BasicInfoDetail _IdeaType;
        private string _IssueDate;
        private Laws _References;
        private string _RegisterDate;
        private BasicInfoDetail _Status;
        //IdeaSubject _ideaSubject;

        public Idea()
        {
        }

        public Idea(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Idea idea = new Idea(this)
            {
                Brief = this._Brief
            };
            if (this._CompleteText != null)
            {
                idea.CompleteText = (string)this._CompleteText.Clone();
            }
            idea.Creator = this._Creator;
            if (this._IssueDate != null)
            {
                idea.IssueDate = (string)this._IssueDate.Clone();
            }
            if (this._RegisterDate != null)
            {
                idea.RegisterDate = (string)this._RegisterDate.Clone();
            }
            if (!object.ReferenceEquals(this.CoUnit, null))
            {
                idea.CoUnit = (BasicInfoDetail)this.CoUnit.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.References, null))
            {
                idea.References = (Laws)this.References.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Status, null))
            {
                idea.Status = (BasicInfoDetail)this.Status.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Categories, null))
            {
                idea.Categories = (IdeaCategories)this.Categories.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.IdeaType, null))
            {
                idea.IdeaType = (BasicInfoDetail)this.IdeaType.Clone(sNodeName);
            }
            //if (!object.ReferenceEquals(this.IdeaSubject, null))
            //{
            //    idea.IdeaSubject = (IdeaSubject)this.IdeaSubject.Clone(sNodeName);
            //}
            return idea;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Brief = "";
            this._CompleteText = "";
            this._Creator = "";
            this._IssueDate = "";
            this._RegisterDate = "";
            this._CoUnit = new BasicInfoDetail();
            this._References = new Laws();
            this._Status = new BasicInfoDetail();
            this._Categories = new IdeaCategories();
            this._IdeaType = new BasicInfoDetail();
            //this._ideaSubject = new IdeaSubject();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_Brief
        {
            get
            {
                return "Idea.Brief";
            }
        }

        public static string at_CategoriesFirstLevelAttributes
        {
            get
            {
                return "Idea.CategoriesFirstLevelAttributes";
            }
        }

        public static string at_CategoriesID
        {
            get
            {
                return "Idea.CategoriesID";
            }
        }

        public static string at_CompleteText
        {
            get
            {
                return "Idea.CompleteText";
            }
        }

        public static string at_CoUnitFirstLevelAttributes
        {
            get
            {
                return "Idea.CoUnitFirstLevelAttributes";
            }
        }

        public static string at_CoUnitID
        {
            get
            {
                return "Idea.CoUnitID";
            }
        }

        public static string at_Creator
        {
            get
            {
                return "Idea.Creator";
            }
        }

        public static string at_IdeaTypeFirstLevelAttributes
        {
            get
            {
                return "Idea.IdeaTypeFirstLevelAttributes";
            }
        }

        public static string at_IdeaTypeID
        {
            get
            {
                return "Idea.IdeaTypeID";
            }
        }

        public static string at_IssueDate
        {
            get
            {
                return "Idea.IssueDate";
            }
        }

        public static string at_ReferencesFirstLevelAttributes
        {
            get
            {
                return "Idea.ReferencesFirstLevelAttributes";
            }
        }

        public static string at_ReferencesID
        {
            get
            {
                return "Idea.ReferencesID";
            }
        }

        public static string at_RegisterDate
        {
            get
            {
                return "Idea.RegisterDate";
            }
        }

        public static string at_StatusFirstLevelAttributes
        {
            get
            {
                return "Idea.StatusFirstLevelAttributes";
            }
        }

        public static string at_StatusID
        {
            get
            {
                return "Idea.StatusID";
            }
        }

        //public static string at_IdeaSubjectID
        //{
        //    get
        //    {
        //        return "IdeaSubject.ID";
        //    }
        //}

        //public static string at_IdeaSubjectFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "IdeaSubject.IdeaSubjectFirstLevelAttributes";
        //    }
        //}

        [Browsable(true), AttributeType("String"), DisplayName(""), DocumentAttributeID("27148"), Description(""), IsRelational("false"), Category("")]
        public string Brief
        {
            get
            {
                return this._Brief;
            }
            set
            {
                this._Brief = value;
            }
        }

        [Browsable(true), DocumentAttributeID("27236"), Description(""), IsRelational("False"), AttributeType("IdeaCategories"), IsMiddleTableExist("True"), RelationTable(""), Category(""), DisplayName("")]
        public IdeaCategories Categories
        {
            get
            {
                return this._Categories;
            }
            set
            {
                this._Categories = value;
            }
        }

        [IsRelational("false"), Description(""), DocumentAttributeID("27149"), Browsable(true), Category(""), DisplayName(""), AttributeType("LongText")]
        public string CompleteText
        {
            get
            {
                return this._CompleteText;
            }
            set
            {
                this._CompleteText = value;
            }
        }

        [Category(""), Description(""), DisplayName(""), IsRelational("False"), RelationTable(""), Browsable(true), AttributeType("BasicInfoDetail"), DocumentAttributeID("27233"), IsMiddleTableExist("False")]
        public BasicInfoDetail CoUnit
        {
            get
            {
                return this._CoUnit;
            }
            set
            {
                this._CoUnit = value;
            }
        }

        [Category(""), AttributeType("String"), DisplayName(""), Description(""), DocumentAttributeID("27150"), IsRelational("false"), Browsable(true)]
        public string Creator
        {
            get
            {
                return this._Creator;
            }
            set
            {
                this._Creator = value;
            }
        }

        [Category(""), AttributeType("BasicInfoDetail"), RelationTable(""), DisplayName("نوع"), DocumentAttributeID("27338"), Browsable(true), IsRelational("False"), Description("نظر/سیاست"), IsMiddleTableExist("False")]
        public BasicInfoDetail IdeaType
        {
            get
            {
                return this._IdeaType;
            }
            set
            {
                this._IdeaType = value;
            }
        }

        [AttributeType("DateString"), IsRelational("false"), Category(""), Description(""), DisplayName(""), DocumentAttributeID("27151"), Browsable(true)]
        public string IssueDate
        {
            get
            {
                return this._IssueDate;
            }
            set
            {
                this._IssueDate = value;
            }
        }

        [RelationTable("Idea_References_M"), IsRelational("False"), IsMiddleTableExist("False"), DisplayName(""), Category(""), DocumentAttributeID("27234"), Browsable(true), Description(""), AttributeType("Laws")]
        public Laws References
        {
            get
            {
                return this._References;
            }
            set
            {
                this._References = value;
            }
        }

        [Description(""), AttributeType("DateString"), Browsable(true), Category(""), DocumentAttributeID("27152"), IsRelational("false"), DisplayName("")]
        public string RegisterDate
        {
            get
            {
                return this._RegisterDate;
            }
            set
            {
                this._RegisterDate = value;
            }
        }

        [AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), DisplayName(""), Browsable(true), IsRelational("False"), DocumentAttributeID("27235"), RelationTable(""), Category(""), Description("")]
        public BasicInfoDetail Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }

        //[AttributeType("IdeaSubject"), IsMiddleTableExist("False"), DisplayName(""), Browsable(true), IsRelational("False"), DocumentAttributeID(""), RelationTable(""), Category(""), Description("")]
        //public IdeaSubject IdeaSubject { get { return _ideaSubject; } set { _ideaSubject = value; } }
    }
}
