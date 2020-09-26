namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ObjectCode("9075"), ItemsType("Sbn.Products.GEP.GEPObject.Bookmarks")]
    public class Bookmark : SbnObject
    {
        private string _CorrelateItemData;
        private string _Title;

        public Bookmark()
        {
        }

        public Bookmark(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new Bookmark { ID = base.ID, Title = this._Title, CorrelateItemData = this._CorrelateItemData };
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Title = "";
            this._CorrelateItemData = "";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateItemData
        {
            get
            {
                return "Bookmark.CorrelateItemData";
            }
        }

        public static string at_Title
        {
            get
            {
                return "Bookmark.Title";
            }
        }

        [AttributeType("String"), Browsable(true), Description(""), DisplayName(""), Category(""), DocumentAttributeID("9025"), IsRelational("false")]
        public string CorrelateItemData
        {
            get
            {
                return this._CorrelateItemData;
            }
            set
            {
                this._CorrelateItemData = value;
            }
        }

        [DocumentAttributeID("9024"), Description(""), IsRelational("false"), Browsable(true), DisplayName(""), Category(""), AttributeType("String")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
    }
}
