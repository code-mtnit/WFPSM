namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.Precept"), SystemName("GEP")]
    public class Precepts : SbnListObject<Precept>
    {
        public override object Clone(string sNodeName)
        {
            Precepts precepts = new Precepts();
            foreach (Precept precept in this)
            {
                precepts.Add((Precept) precept.Clone(sNodeName));
            }
            return precepts;
        }
    }
}
