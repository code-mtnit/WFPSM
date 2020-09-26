namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessionOrder"), Description("دستور جلسات کمیسیون"), DisplayName("دستور جلسات کمیسیون"), SystemName("GEP")]
    public class CommissionSessionOrders : SbnListObject<CommissionSessionOrder>
    {
        public override object Clone(string sNodeName)
        {
            CommissionSessionOrders orders = new CommissionSessionOrders();
            foreach (CommissionSessionOrder order in this)
            {
                orders.Add((CommissionSessionOrder) order.Clone(sNodeName));
            }
            return orders;
        }
    }
}
