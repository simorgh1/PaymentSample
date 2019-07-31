using System;

namespace Bank.Core.Common.DataContract
{
    public class PaymentAuthorizationResponse
    {
        public Guid CorrelationId { get; }
        public bool SuccessStatus { get; }

        public PaymentAuthorizationResponse(Guid correlationId, bool status)
        {
            CorrelationId = correlationId;
            SuccessStatus = status;
        }
    }
}