using System;

namespace Empresa.Ecommerce.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUserRepository Users { get; }
    }
}
