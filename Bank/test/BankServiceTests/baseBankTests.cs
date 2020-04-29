using Bank.Core.Interfaces;
using Bank.Mock;

namespace BankTests
{
    public class baseBankTests
    {
        protected IBankService BankServiceMock { get; }

        public baseBankTests()
        {
            BankServiceMock = new BankService
                (new Bank.Core.PaymentPolicy());
        }
    }
}
