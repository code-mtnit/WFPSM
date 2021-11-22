namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GEP"), DisplayName(""), ObjectCode("9049"), ItemsType("Sbn.Products.GEP.GEPObject.Catalogue_Offers_M")]
    public class Color : SbnObject
    {
        private string _TitleBackColor;
        private string _TitleForeColor;
        public Color()
        {
        }
        public override SbnObject Clone(string sNodeName)
        {
            Color catalogue_offers_m = new Color();

            catalogue_offers_m.TitleBackColor = this._TitleBackColor;
            catalogue_offers_m.TitleForeColor = this._TitleForeColor;
            return catalogue_offers_m;

        }
        public override void Initialize()
        {
            base.Initialize();
            this._TitleBackColor = "";
            this._TitleForeColor = "";
        }
        public static string at_TitleBackColor
        {
            get
            {
                return "Catalogue.TitleBackColor";
            }
        }
        public static string at_TitleForeColor
        {
            get
            {
                return "Catalogue.TitleForeColor";
            }
        }
        public static string at_OfferID
        {
            get
            {
                return "Catalogue_Offers_M.OfferID";
            }
        }
        public static string at_CatalogueID
        {
            get
            {
                return "Catalogue_Offers_M.CatalogueID";
            }
        }
        public static string at_CorrrlateOfferFirstLevelAttributes
        {
            get
            {
                return "Catalogue_Offers_M.CorrrlateOfferFirstLevelAttributes";
            }
        }
        public static string at_CorrrlateCatalogueFirstLevelAttributes
        {
            get
            {
                return "Catalogue_Offers_M.CorrrlateCatalogueFirstLevelAttributes";
            }
        }

        [Description("رنگ پس زمینه"), DisplayName("رنگ پس زمینه"), Category(""), DocumentAttributeID("6578"), Browsable(true), IsRelational("False"), AttributeType("String")]
        public string TitleBackColor
        {
            get
            {
                return this._TitleBackColor;
            }
            set
            {
                this._TitleBackColor = value;
            }
        }
        [Description("رنگ قلم"), DisplayName("رنگ قلم"), Category(""), DocumentAttributeID("4958"), Browsable(true), IsRelational("False"), AttributeType("String")]
        public string TitleForeColor
        {
            get
            {
                return this._TitleForeColor;
            }
            set
            {
                this._TitleForeColor = value;
            }
        }
    }
}