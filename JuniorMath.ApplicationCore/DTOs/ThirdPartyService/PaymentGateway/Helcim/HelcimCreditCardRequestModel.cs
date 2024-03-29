﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.ThirdPartyService.PaymentGateway.Helcim
{
    public class HelcimCreditCardRequestModel
    {
        public string CardHolderName { get; set; }
        public string cardNumber { get; set; }
        public string cardExpiry { get; set; }
        public string cardCVV { get; set; }
        public string cardHolderAddress { get; set; }
        public string cardHolderPostalCode { get; set; }
    }
}
