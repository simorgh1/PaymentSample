
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Core.Common.DataContract
{
    public class PaymentRequest
    {
        [StringLength(maximumLength: 16, MinimumLength = 16, ErrorMessage = "Please enter a card number with a length of 16")]
        public string CardNumber { get; set; }

        [StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "Please enter an expiry in mm/yy format")]
        public string Expiry { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter the payment amount")]
        public decimal Amount { get; set; }

        [Range(111, 999)]
        public int Cvv { get; set; }

        [Required(ErrorMessage = "Please enter the currency code for example EUR")]
        public string Currency { get; set; }
    }
}
