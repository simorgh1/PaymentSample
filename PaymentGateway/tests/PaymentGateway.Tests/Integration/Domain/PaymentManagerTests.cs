
using Xunit;
using PaymentGateway.Core.Common.DataContract;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace PaymentGateway.Tests.Integration.Domain
{
    public class PaymentManagerTests : baseDomainTests
    {
        [Fact]
        public async Task ValidPaymentRequestReturnsSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 10,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            Assert.True(response.SuccessStatus);
        }

        [Fact]
        public async Task InValidCardnumberPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "411111111111X111",
                Amount = 10,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public async Task InValidExpiryPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 10,
                Expiry = "10X20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public async Task InValidCurrencyPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 10,
                Expiry = "10/20",
                Currency = "TRY",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public async Task InValidAmountPaymentRequestReturnsUnSuccessfullPaymentStatus()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 1000,
                Expiry = "10/20",
                Currency = "TRY",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            Assert.False(response.SuccessStatus);
        }

        [Fact]
        public async Task UnknownPaymentIdReturnsNull()
        {
            var response = await PaymentManager.GetByIdAsync(Guid.NewGuid(), CancellationToken.None);

            Assert.Null(response);
        }

        [Fact]
        public async Task ValidPaymentIdReturnsPaymentDetails()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 100,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            var paymentDetail = await PaymentManager.GetByIdAsync(response.PaymentId, CancellationToken.None);

            Assert.True(paymentDetail.SuccessStatus);
        }

        [Fact]
        public async Task ValidPaymentIdReturnsPaymentDetailsWithMaskedCardNumber()
        {
            var paymentRequest = new PaymentRequest()
            {
                CardNumber = "4111111111111111",
                Amount = 100,
                Expiry = "10/20",
                Currency = "EUR",
                Cvv = 888
            };

            var response = await PaymentManager.ProcessPaymentAsync(paymentRequest, CancellationToken.None);

            var paymentDetail = await PaymentManager.GetByIdAsync(response.PaymentId, CancellationToken.None);

            Assert.Contains("************", paymentDetail.CardNumber);
        }
    }
}
