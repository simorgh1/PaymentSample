
using Bank.Core.Diagnostics;

namespace Bank.Core.Common.DataContract
{
    public class PaymentAuthorizationRequest
    {
        public string CardNumber { get; private set; }
        public string Expiry { get; private set; }
        public decimal Amount { get; private set; }
        public int Cvv { get; private set; }
        public string Currency { get; private set; }

        public PaymentAuthorizationRequest(
            string cardNumber,
            string expiry,
            decimal amount,
            int cvv,
            string currency)
        {
            Check.NotNull(cardNumber, nameof(cardNumber));
            Check.NotNull(expiry, nameof(expiry));
            Check.NotNull(currency, nameof(currency));

            CardNumber = cardNumber;
            Expiry = expiry;
            Amount = amount;
            Cvv = cvv;
            Currency = currency;
        }
    }
}
