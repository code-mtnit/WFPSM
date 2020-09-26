using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sbn.Libs.AssemblyTools
{
    #region Entity Attributes , Atts
    [AttributeUsage(AttributeTargets.All)]
    public class ItemsType : Attribute
    {
        public ItemsType(string  Description_in)
        {
            this.description = Description_in;
        }
        protected string   description;
        public string   Description
        {
            get
            {
                return this.description;

            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class AttributeType : Attribute
    {
        public AttributeType(String Description_in)
        {
            this.description = Description_in;
        }

        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class IsRelationalAttribute : Attribute
    {
        public IsRelationalAttribute(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class IsMiddleTableExist : Attribute
    {
        public IsMiddleTableExist(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class RelationTable : Attribute
    {
        public RelationTable(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class DocumentAttributeID : Attribute
    {
        public DocumentAttributeID(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }
    #endregion Entity Attributes , Atts

    [AttributeUsage(AttributeTargets.All)]
    public class ObjectCode : Attribute
    {
        public ObjectCode(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class SystemName : Attribute
    {
        public SystemName(String Description_in)
        {
            this.description = Description_in;
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;

            }
        }
    }

    //[AttributeUsage(AttributeTargets.All)]
    //public class DisplayCategory : Attribute
    //{
    //    public DisplayCategory(String Description_in)
    //    {
    //        this.description = Description_in;
    //    }
    //    protected String description;
    //    public String Description
    //    {
    //        get
    //        {
    //            return this.description;

    //        }
    //    }
    //}

}
