namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPOfferStatusType
    {
        GovernmentOpinion = 3,
        InCommission = 6,
        InCommissionEngineering = 7,
        InCommissionSession = 8,
        InCommunique = 4,
        InSession = 2,
        None = 0,
        OutOfValue = 0x3e7,
        ReadyForCommSession = 5,
        ReadyToGovSession = 1
    }
}
