
using PaymentGateway.Core.Common.DataContract;
using System;

namespace PaymentGateway.Core
{
    public interface IPaymentManager
    {
        PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
        Payment GetById(Guid paymentId);
    }
}
