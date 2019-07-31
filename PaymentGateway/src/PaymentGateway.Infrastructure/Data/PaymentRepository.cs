using PaymentGateway.Core.Common;
using PaymentGateway.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure.Data
{
    /// <summary>
    /// Repository for adding and getting a Payment to/from the database
    /// </summary>
    public class PaymentRepository : IRepository
    {
        private readonly PaymentDbContext _dbContext;

        public PaymentRepository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync<T>(
            Guid id, CancellationToken cancellationToken) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(
                keyValues: new object[] { id }, 
                cancellationToken: cancellationToken);
        }

        public async Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
