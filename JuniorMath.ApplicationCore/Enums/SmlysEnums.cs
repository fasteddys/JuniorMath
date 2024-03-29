﻿using System.ComponentModel;


namespace JuniorMath.ApplicationCore.Enums
{
    public enum SiteUserLevelType
    {
        [Description("AdminUser")]
        AdminUser = 1,
        [Description("User")]
        User = 2
    }

    public enum PaymentType
    {
        [Description("Cash")]
        Cash = 1,
        [Description("Check")]
        Check = 2,
        [Description("CreditCard")]
        CreditCard = 3,
    }

    public enum PaymentMethodType
    {
        [Description("Visa")]
        Visa = 1,
        [Description("MasterCard")]
        MasterCard = 2,
        [Description("American Express")]
        AmericanExpress = 3,
        [Description("Cash")]
        Cash = 11,
        [Description("Check")]
        Check = 12,
    }

    public enum PaymentStatusType
    {
        [Description("Purchase")]
        Purchase = 1,
        [Description("Void")]
        Void = 2,
        [Description("Refund")]
        Refund = 3,
    }

    public enum PaymentGateWayType
    {
        [Description("HelCim")]
        HelCim= 1,
        [Description("Stripe")]
        Stripe = 2
    }

    public enum CurrencyType
    {
        [Description("USD")]
        USD = 1,
        [Description("CAD")]
        CAD = 2
    }

    public enum IndexNameType
    {
        [Description("patient-index")]
        Patient = 1,
        [Description("invoice-index")]
        Invoice = 2,
        [Description("service-index")]
        Service = 3
    }

    public enum InvoiceStatusType
    {
        [Description("new-invoice")]
        NewInvoice = 1,
        [Description("draft")]
        Draft = 2
    }
}
