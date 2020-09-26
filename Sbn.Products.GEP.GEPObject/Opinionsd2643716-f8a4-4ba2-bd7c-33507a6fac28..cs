namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.Opinion"), Description(""), DisplayName("")]
    public class Opinions : SbnListObject<Opinion>
    {
        public override object Clone(string sNodeName)
        {
            Opinions opinions = new Opinions();
            foreach (Opinion opinion in this)
            {
                opinions.Add((Opinion) opinion.Clone(sNodeName));
            }
            return opinions;
        }
    }
}
