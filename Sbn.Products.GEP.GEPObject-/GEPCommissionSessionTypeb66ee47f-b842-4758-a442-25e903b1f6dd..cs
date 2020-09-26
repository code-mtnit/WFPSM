namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPCommissionSessionType
    {
        Basic = 1,
        None = 0,
        OutOfValue = 0x3e7,
        Subsidary = 3,
        Technical = 2
    }
}
