using PaymentGateway.Core.Common;

namespace PaymentGateway.Core.Entities
{
    public class Payment : BaseEntity
    {
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int Cvv { get; set; }
        public bool SuccessStatus { get; set; }
    }
}