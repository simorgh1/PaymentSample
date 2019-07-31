using PaymentGateway.Core.Entities;
using System;
using Xunit;

namespace PaymentGateway.Tests.Integration.Data
{
    public class PaymentRepositoryTests : BasePaymentRepoTestFixture
    {
        [Fact]
        public void AddNewPaymentSetsId()
        {
            var repository = GetRepository();

            var payment = new PaymentBuilder().WithDefaultValues().Build();

            repository.Add(payment);

            Assert.NotEqual(Guid.Empty, payment.Id);
        }

        [Fact]
        public void GetByIdReturnsExistingPayment()
        {
            var repository = GetRepository();

            var payment = new PaymentBuilder().WithDefaultValues().Build();

            repository.Add(payment);

            var newPayment = repository.GetById<Payment>(payment.Id);
            Assert.Equal(payment, newPayment);
        }
    }
}
