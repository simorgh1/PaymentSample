using PaymentGateway.Core.Common;
using PaymentGateway.Core.Interfaces;
using System;
using System.Linq;

namespace PaymentGateway.Infrastructure.Data
{
    public class PaymentRepository : IRepository
    {
        private readonly PaymentDbContext _dbContext;

        public PaymentRepository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(Guid id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
