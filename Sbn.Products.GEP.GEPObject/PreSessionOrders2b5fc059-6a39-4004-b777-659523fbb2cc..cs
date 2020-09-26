namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("بندهاي مطروحه پيش از دستور كار هيات دولت"), DisplayName("بندهاي مطروحه پيش از دستور كار هيات دولت"), ItemsType("Sbn.Products.GEP.GEPObject.PreSessionOrder")]
    public class PreSessionOrders : SbnListObject<PreSessionOrder>
    {
        public override object Clone(string sNodeName)
        {
            PreSessionOrders orders = new PreSessionOrders();
            foreach (PreSessionOrder order in this)
            {
                orders.Add((PreSessionOrder) order.Clone(sNodeName));
            }
            return orders;
        }
    }
}
