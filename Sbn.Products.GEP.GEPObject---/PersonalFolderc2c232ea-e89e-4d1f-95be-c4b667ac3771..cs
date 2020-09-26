namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description("پرونده شخصي كاربران"), DisplayName("پرونده شخصي كاربران"), ObjectCode("9247"), ItemsType("Sbn.Products.GEP.GEPObject.PersonalFolders"), SystemName("GEP")]
    public class PersonalFolder : SbnObject
    {
        private PersonalFolders _Childs;
        private GeneralDocuments _Documents;
        private WFPerson _Owner;
        private PersonalFolder _Parent;

        public PersonalFolder()
        {
        }

        public PersonalFolder(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            PersonalFolder folder = new PersonalFolder {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.Parent, null))
            {
                folder.Parent = (PersonalFolder) this.Parent.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Childs, null))
            {
                folder.Childs = (PersonalFolders) this.Childs.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Documents, null))
            {
                folder.Documents = (GeneralDocuments) this.Documents.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Owner, null))
            {
                folder.Owner = (WFPerson) this.Owner.Clone(sNodeName);
            }
            return folder;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Parent = new PersonalFolder();
            this._Childs = new PersonalFolders();
            this._Documents = new GeneralDocuments();
            this._Owner = new WFPerson();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_ChildsFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.ChildsFirstLevelAttributes";
            }
        }

        public static string at_ChildsID
        {
            get
            {
                return "PersonalFolder.ChildsID";
            }
        }

        public static string at_DocumentsFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.DocumentsFirstLevelAttributes";
            }
        }

        public static string at_DocumentsID
        {
            get
            {
                return "PersonalFolder.DocumentsID";
            }
        }

        public static string at_Owner_SexFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.Owner.SexFirstLevelAttributes";
            }
        }

        public static string at_Owner_WorkersFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.Owner.WorkersFirstLevelAttributes";
            }
        }

        public static string at_OwnerFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.OwnerFirstLevelAttributes";
            }
        }

        public static string at_OwnerID
        {
            get
            {
                return "PersonalFolder.OwnerID";
            }
        }

        public static string at_Parent_ChildsFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.Parent.ChildsFirstLevelAttributes";
            }
        }

        public static string at_Parent_DocumentsFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.Parent.DocumentsFirstLevelAttributes";
            }
        }

        public static string at_Parent_OwnerFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.Parent.OwnerFirstLevelAttributes";
            }
        }

        public static string at_Parent_ParentFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.Parent.ParentFirstLevelAttributes";
            }
        }

        public static string at_ParentFirstLevelAttributes
        {
            get
            {
                return "PersonalFolder.ParentFirstLevelAttributes";
            }
        }

        public static string at_ParentID
        {
            get
            {
                return "PersonalFolder.ParentID";
            }
        }

        public static string at_Title
        {
            get
            {
                return "PersonalFolder.Title";
            }
        }

        [IsMiddleTableExist("True"), DisplayName(""), Category(""), DocumentAttributeID("9309"), Browsable(true), IsRelational("True"), AttributeType("PersonalFolders"), Description(""), RelationTable("")]
        public PersonalFolders Childs
        {
            get
            {
                return this._Childs;
            }
            set
            {
                this._Childs = value;
            }
        }

        [DocumentAttributeID("9350"), DisplayName("محتوی"), Category(""), Description("مستندات مرتبط با پوشه"), Browsable(true), IsRelational("True"), AttributeType("GeneralDocuments"), IsMiddleTableExist("True"), RelationTable("")]
        public GeneralDocuments Documents
        {
            get
            {
                return this._Documents;
            }
            set
            {
                this._Documents = value;
            }
        }

        [IsMiddleTableExist("False"), Category(""), IsRelational("False"), AttributeType("WFPerson"), Description("مالک پوشه"), RelationTable(""), DisplayName("مالک پوشه"), DocumentAttributeID("9359"), Browsable(true)]
        public WFPerson Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                this._Owner = value;
            }
        }

        [DocumentAttributeID("9308"), Browsable(true), IsRelational("False"), AttributeType("PersonalFolder"), IsMiddleTableExist("False"), RelationTable(""), DisplayName(""), Category(""), Description("")]
        public PersonalFolder Parent
        {
            get
            {
                return this._Parent;
            }
            set
            {
                this._Parent = value;
            }
        }
    }
}
