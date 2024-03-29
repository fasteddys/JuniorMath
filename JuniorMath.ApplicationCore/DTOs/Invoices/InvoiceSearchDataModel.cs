﻿using JuniorMath.ApplicationCore.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.Invoices
{
    public class InvoiceSearchDataModel: BasicDataModel
    {
        public int? DisplayId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? InvoiceFromDate { get; set; }
        public DateTime? InvoiceToDate { get; set; }
    }
}
