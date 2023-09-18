using System;

namespace Empresa.Ecommerce.Aplication.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUserRepository Users { get; }
    }
}
