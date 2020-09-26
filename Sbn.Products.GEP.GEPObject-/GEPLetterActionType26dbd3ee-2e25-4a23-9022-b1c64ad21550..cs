namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPLetterActionType
    {
        ExitWithNoAction = 2,
        InsertInOfferFolder = 3,
        None = 0,
        OutOfValue = 0x3e7,
        SendToReceipients = 1
    }
}
