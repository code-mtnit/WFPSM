namespace Sbn.Products.GEP.GEPObject
{
    using System;
    using System.ComponentModel;

    [Description("")]
    public enum GEPApprovalType
    {
        Approved = 1,
        NextSession = 4,
        None = 0,
        NotApproved = 3,
        OutOfValue = 0x3e7,
        ReferToCommission = 6,
        Rejected = 2,
        RejectToOrgan = 5
    }
}
