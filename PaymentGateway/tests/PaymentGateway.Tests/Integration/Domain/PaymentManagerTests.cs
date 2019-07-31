
using Xunit;
using PaymentGateway.Core.Common.DataContract;
using System;

namespace PaymentGateway.Tests.Integration.Domain
{
    public class PaymentManagerTests : baseDomainTests
    {
        [Fact]
        public void ValidPaymentRequestReturnsSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 10,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            Assert.True(response.SuccessStatus);
        }

        [Fact]
        public void InValidCardnumberPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "411111111111X111",
                Amount = 10,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public void InValidExpiryPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 10,
                Expiry = "10X20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public void InValidCurrencyPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 10,
                Expiry = "10/20",
                Currency = "TRY",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public void InValidAmountPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 1000,
                Expiry = "10/20",
                Currency = "TRY",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public void UnknownPaymentIdReturnsNull()
        {
            var response = PaymentManager.GetById(Guid.NewGuid());

            Assert.Null(response);
        }

        [Fact]
        public void ValidPaymentIdReturnsPaymentDetails()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 100,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            var paymentDetail = PaymentManager.GetById(response.PaymentId);

            Assert.True(paymentDetail.SuccessStatus);
        }

        [Fact]
        public void ValidPaymentIdReturnsPaymentDetailsWithMaskedCardNumber()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 100,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = PaymentManager.ProcessPayment(paymentRequest);

            var paymentDetail = PaymentManager.GetById(response.PaymentId);

            Assert.Contains("************", paymentDetail.CardNumber);
        }
    }
}
