namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), ItemsType("Sbn.Products.GEP.GEPObject.AO_ApprovalLetter"), SystemName("GEP"), DisplayName("")]
    public class AO_ApprovalLetters : SbnListObject<AO_ApprovalLetter>
    {
        public override object Clone(string sNodeName)
        {
            AO_ApprovalLetters letters = new AO_ApprovalLetters();
            foreach (AO_ApprovalLetter letter in this)
            {
                letters.Add((AO_ApprovalLetter) letter.Clone(sNodeName));
            }
            return letters;
        }
    }
}
