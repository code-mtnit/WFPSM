using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sbn.Products.GEP.GEPObject
{
     [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferTemp"), SystemName("GEP")]
    public class OfferTemps : SbnListObject<OfferTemp>
    {
        public override object Clone(string sNodeName)
        {
            OfferTemps offers = new OfferTemps();
            foreach (OfferTemp offer in this)
            {
                offers.Add((OfferTemp)offer.Clone(sNodeName));
            }
            return offers;
        }
        //public override string ToString()
        //{
        //    string s = "";
        //    foreach (OfferTemp offer in this)
        //    {
        //        s += "," + offer.OfficialCode + "";

        //    }
        //    return s;
        //}
    }
}
