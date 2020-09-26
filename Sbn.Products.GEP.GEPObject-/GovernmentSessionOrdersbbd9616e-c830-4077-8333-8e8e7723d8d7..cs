namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.GovernmentSessionOrder"), Description(""), DisplayName("")]
    public class GovernmentSessionOrders : SbnListObject<GovernmentSessionOrder>
    {
        public override object Clone(string sNodeName)
        {
            GovernmentSessionOrders orders = new GovernmentSessionOrders();
            foreach (GovernmentSessionOrder order in this)
            {
                orders.Add((GovernmentSessionOrder) order.Clone(sNodeName));
            }
            return orders;
        }
    }
}
