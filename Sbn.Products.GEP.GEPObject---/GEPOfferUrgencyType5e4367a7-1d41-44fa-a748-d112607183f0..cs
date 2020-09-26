namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPOfferUrgencyType
    {
        Immediate = 4,
        None = 0,
        Normal = 1,
        OutOfValue = 0x3e7,
        TowUrgent = 3,
        Urgent = 2
    }
}
