namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.Catalogue")]
    public class Catalogues : SbnListObject<Catalogue>
    {
        public override object Clone(string sNodeName)
        {
            Catalogues catalogues = new Catalogues();
            foreach (Catalogue catalogue in this)
            {
                catalogues.Add((Catalogue) catalogue.Clone(sNodeName));
            }
            return catalogues;
        }
    }
}
