
using Bank.Core.Interfaces;
using Bank.Mock;
using PaymentGateway.Core;
using PaymentGateway.Domain;
using PaymentGateway.Tests.Integration.Data;

namespace PaymentGateway.Tests.Integration.Domain
{
    public class baseDomainTests : BasePaymentRepoTestFixture
    {
        protected IBankService BankServiceMock { get; }
        protected IPaymentManager PaymentManager { get; } 

        public baseDomainTests()
        {
            BankServiceMock = new BankService(new Bank.Core.PaymentPolicy());
            PaymentManager = new PaymentManager(GetRepository(), BankServiceMock);
        }
    }
}
