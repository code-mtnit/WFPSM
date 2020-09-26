namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPSensitivityType
    {
        Esoteric = 4,
        None = 0,
        Normal = 1,
        OutOfValue = 0x3e7,
        Secret = 2,
        VerySecret = 3
    }
}
