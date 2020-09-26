namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.ApprovalLetter")]
    public class ApprovalLetters : SbnListObject<ApprovalLetter>
    {
        public override object Clone(string sNodeName)
        {
            ApprovalLetters letters = new ApprovalLetters();
            foreach (ApprovalLetter letter in this)
            {
                letters.Add((ApprovalLetter) letter.Clone(sNodeName));
            }
            return letters;
        }
    }
}
