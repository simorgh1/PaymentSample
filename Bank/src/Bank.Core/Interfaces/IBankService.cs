
using Bank.Core.Common.DataContract;

namespace Bank.Core.Interfaces
{
    public interface IBankService
    {
        PaymentAuthorizationResponse AuthorizePayment(PaymentAuthorizationRequest paymentAuthorizationRequest);
    }
}
