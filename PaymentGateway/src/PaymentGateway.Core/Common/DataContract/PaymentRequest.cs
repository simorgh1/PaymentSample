
namespace PaymentGateway.Core.Common.DataContract
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public decimal Amount { get; set; }
        public int Cvv { get; set; }
        public string Currency { get; set; }
    }
}
