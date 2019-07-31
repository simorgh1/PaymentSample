
using PaymentGateway.Core.Entities;

namespace PaymentGateway.Tests
{
    public class PaymentBuilder
    {
        private Payment _payment = new Payment();

        public PaymentBuilder WithDefaultValues()
        {
            _payment = new Payment()
            {
                CardNumber = "1234-5678-9101",
                Currency = "EUR",
                Amount = 22.5m,
                Cvv = 777,
                Expiry = "12/22",
                SuccessStatus = true
            };

            return this;
        }

        public Payment Build() => _payment;
    }
}
