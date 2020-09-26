namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("فهرست نامه ها"), Description("فهرست نامه ها"), ItemsType("Sbn.Products.GEP.GEPObject.Letter"), SystemName("GEP")]
    public class Letters : SbnListObject<Letter>
    {
        public override object Clone(string sNodeName)
        {
            Letters letters = new Letters();
            foreach (Letter letter in this)
            {
                letters.Add((Letter) letter.Clone(sNodeName));
            }
            return letters;
        }
    }
}
