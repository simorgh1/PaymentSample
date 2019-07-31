
using PaymentGateway.Core.Common.DataContract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Core
{
    public interface IPaymentManager
    {
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest paymentRequest, CancellationToken cancellationToken);
        Task<Payment> GetByIdAsync(Guid paymentId, CancellationToken cancellationToken);
    }
}
