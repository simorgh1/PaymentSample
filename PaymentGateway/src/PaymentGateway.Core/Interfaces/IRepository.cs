using PaymentGateway.Core.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;
    }
}
