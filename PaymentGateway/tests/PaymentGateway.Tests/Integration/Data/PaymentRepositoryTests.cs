using PaymentGateway.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Tests.Integration.Data
{
    public class PaymentRepositoryTests : BasePaymentRepoTestFixture
    {
        [Fact]
        public async Task  AddNewPaymentSetsId()
        {
            var repository = GetRepository();

            var payment = new PaymentBuilder().ValidVisaCard().Build();

            await repository.AddAsync(payment, CancellationToken.None);

            Assert.NotEqual(Guid.Empty, payment.Id);
        }

        [Fact]
        public async Task GetByIdReturnsExistingPayment()
        {
            var repository = GetRepository();

            var payment = new PaymentBuilder().ValidVisaCard().Build();

            await repository.AddAsync(payment, CancellationToken.None);

            var newPayment = await repository.GetByIdAsync<Payment>(payment.Id, CancellationToken.None);
            Assert.Equal(payment, newPayment);
        }
    }
}
