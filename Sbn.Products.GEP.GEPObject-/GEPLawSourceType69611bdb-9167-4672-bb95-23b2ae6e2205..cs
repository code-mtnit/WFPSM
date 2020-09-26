namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPLawSourceType
    {
        CouncilOfRecognition = 3,
        IslamicParliament = 2,
        NationalParliament = 1,
        None = 0,
        OutOfValue = 0x3e7
    }
}
