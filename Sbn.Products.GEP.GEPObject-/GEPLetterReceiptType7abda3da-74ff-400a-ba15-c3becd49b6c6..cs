namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPLetterReceiptType
    {
        Copy = 2,
        Direct = 1,
        None = 0,
        OutOfValue = 0x3e7,
        RefferTo = 3
    }
}
