﻿
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JuniorMath.Web.Models.Invoices
{
    [DataContract(Name = "invoice_email")]
    public class InvoiceEmailRequestModel
    {
        [DataMember(Name = "invoice_id")]
        public int InvoiceId { get; set; }
       
    }
}
