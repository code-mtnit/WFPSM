using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sbn.Products.GEP.GEPObject
{
    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.ApprovalLetterRefineStatusSearch")]
    public class ApprovalLetterRefineStatusSearchs : SbnListObject<ApprovalLetterRefineStatusSearch>
    {
        public ApprovalLetterRefineStatusSearchs()
            : base()
        {
        }

        public override object Clone(string sNodeName)
        {
            ApprovalLetterRefineStatusSearchs letters = new ApprovalLetterRefineStatusSearchs();
            foreach (ApprovalLetterRefineStatusSearch letter in this)
            {
                letters.Add((ApprovalLetterRefineStatusSearch)letter.Clone(sNodeName));
            }
            return letters;
        }
    }
}
