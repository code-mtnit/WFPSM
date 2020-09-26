using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sbn.Products.GEP.GEPObject
{
    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferRelation"), SystemName("GEP")]
    public class OfferRelations : SbnListObject<OfferRelation>
    {
        public override object Clone(string sNodeName)
        {
            OfferRelations OfferRelations = new OfferRelations();
            foreach (OfferRelation offerRelation in this)
            {
                OfferRelations.Add((OfferRelation)offerRelation.Clone(sNodeName));
            }
            return OfferRelations;
        }
    }
}
