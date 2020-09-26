namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.CancelCommissionSessionOrder"), Description("دستور لغو جلسات کمیسیون"), DisplayName("دستور لغو جلسات کمیسیون"), SystemName("GEP")]
    public class CancelCommissionSessionOrders : SbnListObject<CancelCommissionSessionOrder>
    {
        public override object Clone(string sNodeName)
        {
            CancelCommissionSessionOrders cancels = new CancelCommissionSessionOrders();
            foreach (CancelCommissionSessionOrder cancel in this)
            {
                cancels.Add((CancelCommissionSessionOrder) cancel.Clone(sNodeName));
            }
            return cancels;
        }
    }
}
