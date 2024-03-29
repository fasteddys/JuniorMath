﻿using JuniorMath.ApplicationCore.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.Payment
{
    public class PaymentResultModel : Result
    {
        public bool Approved { get; set; }
        public string TransactionId { get; set; }
        public string AuthCode { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountPaidTotal { get; set; }
        public string CardToken { get; set; }
        public string CardLast4 { get; set; }
        public string FailureCode { get; set; }
        public string FailureMessage { get; set; }
    }
}
