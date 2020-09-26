using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
namespace Sbn.Products.GEP.GEPObject.TMU
{
    [Description("")]
    [DisplayName("")]
    [ObjectCode("13228")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.TMU.Subjects")]
    [Serializable]
    public class Subject : SbnObject
    {
        public Subject()
            : base()
        {
        }
        public Subject(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private Subject _Parent;
        /// <summary>
        /// موضوع بالادستی
        /// </summary>
        [Description("موضوع بالادستی")]
        [DisplayName("موضوع بالادستی")]
        [Category("")]
        [DocumentAttributeID("27367")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Subject")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Subject Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        private Subjects _Childs;
        /// <summary>
        /// موضوعات زیرمجموعه
        /// </summary>
        [Description("موضوعات زیرمجموعه")]
        [DisplayName("موضوعات زیرمجموعه")]
        [Category("")]
        [DocumentAttributeID("27368")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Subjects")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Subjects Childs
        {
            get { return _Childs; }
            set { _Childs = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._Parent = new Subject();
            this._Childs = new Subjects();
        }
        public override SbnObject Clone(string sNodeName)
        {
            Subject retObject = new Subject(this);
            if (!object.ReferenceEquals(this.Parent, null))
                retObject.Parent = (Subject)this.Parent.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Childs, null))
                retObject.Childs = (Subjects)this.Childs.Clone(sNodeName);
            return retObject;
        }
        public static string at_ParentID
        {
            get
            {
                return "Subject.ParentID";
            }
        }
        public static string at_ParentFirstLevelAttributes
        {
            get
            {
                return "Subject.ParentFirstLevelAttributes";
            }
        }
        public static string at_Parent_ParentFirstLevelAttributes
        {
            get
            {
                return "Subject.Parent.ParentFirstLevelAttributes";
            }
        }
        public static string at_Parent_ChildsFirstLevelAttributes
        {
            get
            {
                return "Subject.Parent.ChildsFirstLevelAttributes";
            }
        }
        public static string at_ChildsID
        {
            get
            {
                return "Subject.ChildsID";
            }
        }
        public static string at_ChildsFirstLevelAttributes
        {
            get
            {
                return "Subject.ChildsFirstLevelAttributes";
            }
        }
    }

}
