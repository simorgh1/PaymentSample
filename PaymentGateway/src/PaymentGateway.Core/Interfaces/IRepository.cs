using PaymentGateway.Core.Common;
using System;

namespace PaymentGateway.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
    }
}
