using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sbn.Products.GEP.GEPObject
{
    [Serializable,
    Description("ارتباط یک پیشنهاد با یک پیشنهاد دیگر"),
    SystemName("GEP"),
    DisplayName("ارتباط پیشنهاد"),
    ObjectCode("9300"),
    ItemsType("Sbn.Products.GEP.GEPObject.OfferRelations")]
    public class OfferRelation : SbnObject
    {
        public OfferRelation() { }

        public OfferRelation(SbnObject InitialObject) : base(InitialObject) { }

        Offer _RelationOffer;
        [IsMiddleTableExist("True"),
        RelationTable(""),
        Description("پیشنهاد"),
        DisplayName("پیشنهاد"),
        Category(""),
        DocumentAttributeID(""),
        Browsable(true),
        IsRelational("True"),
        AttributeType("Offer")]
        public Offer RelationOffer
        {
            get
            {
                return this._RelationOffer;
            }
            set
            {
                this._RelationOffer = value;
            }
        }



        private Offer _CoOffer;
        /// <summary>
        /// پوشه مرتبط
        /// </summary>
        [Description("پوشه مرتبط")]
        [DisplayName("پوشه مرتبط")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Offer")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Offer CoOffer
        {
            get { return _CoOffer; }
            set { _CoOffer = value; }
        }


        public override void Initialize()
        {
            base.Initialize();
            this._CoOffer = new Offer();
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferRelation retObject = new OfferRelation(this);
            if (this.CoOffer != null)
                retObject.CoOffer = (Offer)this.CoOffer.Clone(sNodeName);
            return retObject;
        }

        public static string at_CoOfferID
        {
            get
            {
                return "OfferRelation.CoOfferID";
            }
        }
        public static string at_CoOfferFirstLevelAttributes
        {
            get
            {
                return "OfferRelation.CoOfferFirstLevelAttributes";
            }
        }

        public static string at_RelationOfferFirstLevelAttributes
        {
            get
            {
                return "OfferRelation.RelationOfferFirstLevelAttributes";
            }
        }
    }
}
