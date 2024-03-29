﻿using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.Interfaces.Services.ThirdParty.PaymentGateway.Common;
using System;
using System.Text;
using System.Xml;
using System.Net;
using System.Collections.Specialized;
using JuniorMath.ApplicationCore.DTOs.ThirdPartyService.PaymentGateway.Common;
using JuniorMath.ApplicationCore.DTOs.ThirdPartyService.PaymentGateway.Helcim;
using JuniorMath.ApplicationCore.DTOs.Payment;

namespace JuniorMath.Infrastructure.Services.ThirdParty.PaymentGateway.Helcim
{
    public class HelcimPaymentService : IThirdPartyPaymentService
    {
        private const string LIVE_URL = "https://secure.myhelcim.com/api/";

        private XmlDocument BasicRequest(NameValueCollection values)
        {
            using (var client = new WebClient())
            {
                // EXECUTE REQUEST
                var response = client.UploadValues(LIVE_URL, values);

                // BUILD RESPONSE STRING
                var responseString = Encoding.Default.GetString(response);

                // BUILD XML DOCUMENT FROM RESPONSE
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseString);

                // CHECK RESPONSE
                if (doc != null)
                {
                    return doc;
                }

                return null;
            }
        }

        private NameValueCollection GetBasicData(HelcimBasicRequestModel data)
        {
            var values = new NameValueCollection();
            values["accountId"] = data.AccountId;
            values["apiToken"] = data.ApiToken;

            return values;
        }

        public PaymentResultModel ProcessPayment(BasicRequestModel requestModel)
        {
            PaymentResultModel result = new PaymentResultModel();

            var paymentData = (HelcimBasicRequestModel)requestModel;

            var values = GetBasicData(paymentData);
            values["transactionType"] = "purchase";
            values["terminalId"] = paymentData.TerminalId;
            values["test"] = paymentData.Test ? "1" : "0";
            values["amount"] = paymentData.Amount.ToString("0.00");

            if (paymentData.CreditCard != null)
            {
                var creditCard = (HelcimCreditCardRequestModel)paymentData.CreditCard;
                values["cardHolderName"] = creditCard.CardHolderName;
                values["cardNumber"] = creditCard.cardNumber;
                values["cardExpiry"] = creditCard.cardExpiry;
                values["cardCVV"] = creditCard.cardCVV;
                values["cardHolderAddress"] = creditCard.cardHolderAddress;
                values["cardHolderPostalCode"] = creditCard.cardHolderPostalCode;
            }
            else
            {
                values["cardToken"] = paymentData.CardToken;
                values["cardF4L4"] = paymentData.CardF4L4;
                values["comments"] = paymentData.Comments;
            }


            var data = BasicRequest(values);
            if (data != null)
            {
                result.Success = true;
                result.Message = "Process success. ";
                result.Data = data;
            }
            else
            {
                result.Message = "Process failed ";
            }

            return result;
        }

        public PaymentResultModel ProcessVoid(BasicRequestModel requestModel)
        {
            var result = new PaymentResultModel();

            var paymentData = (HelcimBasicRequestModel)requestModel;

            var values = GetBasicData(paymentData);
            values["transactionType"] = "void";

            values["transactionId"] = paymentData.TransactionId;

            var data = BasicRequest(values);
            if (data != null)
            {
                result.Success = true;
                result.Message = "Process void success. ";
                result.Data = data;
            }
            else
            {
                result.Message = "Process void failed. ";
            }

            return result;
        }

        public PaymentResultModel ProcessRefund(BasicRequestModel requestModel)
        {
            var result = new PaymentResultModel
            {
                Message = "Process refund failed. "
            };

            var paymentData = (HelcimBasicRequestModel)requestModel;

            var values = GetBasicData(paymentData);
            values["transactionType"] = "refund";
            values["terminalId"] = paymentData.TerminalId;
            values["test"] = paymentData.Test ? "1" : "0";
            values["amount"] = paymentData.Amount.ToString("0.00");

            if (paymentData.CreditCard != null)
            {
                var creditCard = (HelcimCreditCardRequestModel)paymentData.CreditCard;
                values["cardHolderName"] = creditCard.CardHolderName;
                values["cardNumber"] = creditCard.cardNumber;
                values["cardExpiry"] = creditCard.cardExpiry;
                values["cardCVV"] = creditCard.cardCVV;

                var data = BasicRequest(values);
                if (data != null)
                {
                    result.Success = true;
                    result.Message = "Process refund success. ";
                    result.Data = data;
                }
            }

            return result;
        }
    }
}
