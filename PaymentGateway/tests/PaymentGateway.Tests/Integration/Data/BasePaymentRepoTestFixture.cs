
using PaymentGateway.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentGateway.Tests.Integration.Data
{
    public abstract class BasePaymentRepoTestFixture
    {
        protected PaymentDbContext _dbContext;

        protected static DbContextOptions<PaymentDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<PaymentDbContext>();
            builder.UseInMemoryDatabase("paymentgateway")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected PaymentRepository GetRepository()
        {
            var options = CreateNewContextOptions();

            _dbContext = new PaymentDbContext(options);
            return new PaymentRepository(_dbContext);
        }
    }
}
