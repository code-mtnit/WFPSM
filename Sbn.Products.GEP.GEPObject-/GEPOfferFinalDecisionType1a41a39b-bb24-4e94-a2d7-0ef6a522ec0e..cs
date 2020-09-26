namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPOfferFinalDecisionType
    {
        None = 0,
        OutOfValue = 0x3e7,
        Rejection = 1,
        Resolution = 2,
        Suspention = 4
    }
}
