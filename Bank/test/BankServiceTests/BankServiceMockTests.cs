using System;
using Xunit;

namespace BankTests
{
    /// <summary>
    /// UnitTests related to the Bank Service Mock
    /// </summary>
    public class BankServiceMockTests : baseBankTests
    {
        private int _thisYear = System.DateTime.UtcNow.Year - 2000;
        private const string ValidCreditCard = "4234567891015555";
        private const string ValidCurrency = "EUR";

        [Fact]
        public void AuthorizePaymentRequestNullRequestThrows()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    BankServiceMock.AuthorizePayment(null);
                });
        }

        [Fact]
        public void AuthorizePaymentRequestInvalidExpiryMonthReturnsFalse()
        {
            Assert.False(
                BankServiceMock.AuthorizePayment(
                    new Bank.Core.Common.DataContract.PaymentAuthorizationRequest(
                        ValidCreditCard,
                        $"13/{_thisYear}",
                        10m,
                        989,
                        ValidCurrency)
                    ).SuccessStatus
                );
        }

        [Fact]
        public void AuthorizePaymentRequestValidExpiryMonthReturnsTrue()
        {
            Assert.True(
                BankServiceMock.AuthorizePayment(
                    new Bank.Core.Common.DataContract.PaymentAuthorizationRequest(
                        ValidCreditCard,
                        $"12/{_thisYear}",
                        10m,
                        989,
                        ValidCurrency)
                    ).SuccessStatus
                );
        }

        [Fact]
        public void AuthorizePaymentRequestInvalidCurrencyReturnsFalse()
        {
            Assert.False(
                BankServiceMock.AuthorizePayment(
                    new Bank.Core.Common.DataContract.PaymentAuthorizationRequest(
                        ValidCreditCard,
                        $"12/{_thisYear}",
                        10m,
                        989,
                        "USD")
                    ).SuccessStatus
                );
        }

        [Fact]
        public void AuthorizePaymentRequestInvalidPaymentPolicyMaxAmountReturnsFalse()
        {
            Assert.False(
                BankServiceMock.AuthorizePayment(
                    new Bank.Core.Common.DataContract.PaymentAuthorizationRequest(
                        ValidCreditCard,
                        $"12/{_thisYear}",
                        1000m,
                        989,
                        ValidCurrency)
                    ).SuccessStatus
                );
        }

        [Fact]
        public void AuthorizePaymentRequestInvalidPaymentPolicyMinAmountReturnsFalse()
        {
            Assert.False(
                BankServiceMock.AuthorizePayment(
                    new Bank.Core.Common.DataContract.PaymentAuthorizationRequest(
                        ValidCreditCard,
                        $"12/{_thisYear}",
                        0m,
                        989,
                        ValidCurrency)
                    ).SuccessStatus
                );
        }
    }
}
