using System;

namespace PaymentGateway.Core.Common.DataContract
{
    public class PaymentResponse
    {
        public Guid PaymentId { get; }
        public bool SuccessStatus { get; }

        public PaymentResponse(Guid paymentId, bool status)
        {
            PaymentId = paymentId;
            SuccessStatus = status;
        }
    }
}