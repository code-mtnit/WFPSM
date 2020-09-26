namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.Engineering"), SystemName("GEP"), Description("فهرست کار کارشناسی"), DisplayName("فهرست کار کارشناسی")]
    public class Engineerings : SbnListObject<Engineering>
    {
        public override object Clone(string sNodeName)
        {
            Engineerings engineerings = new Engineerings();
            foreach (Engineering engineering in this)
            {
                engineerings.Add((Engineering) engineering.Clone(sNodeName));
            }
            return engineerings;
        }
    }
}
