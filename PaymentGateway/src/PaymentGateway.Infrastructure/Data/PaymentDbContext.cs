
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.Entities;

namespace PaymentGateway.Infrastructure.Data
{
    /// <summary>
    /// Payment DbContext for storing the payment entity
    /// </summary>
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            :base(options)
        {}

        public DbSet<Payment> Payments { get; set; }
    }
}
