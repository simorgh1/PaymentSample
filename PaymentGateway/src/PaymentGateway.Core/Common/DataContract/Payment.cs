using System.Runtime.Serialization;

namespace PaymentGateway.Core.Common.DataContract
{
    [DataContract(Name = "payment")]
    public class Payment
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "cardNumber")]
        public string CardNumber { get; set; }

        [DataMember(Name = "expiry")]
        public string Expiry { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "cvv")]
        public int Cvv { get; set; }

        [DataMember(Name = "successStatus")]
        public bool SuccessStatus { get; set; }
    }
}
