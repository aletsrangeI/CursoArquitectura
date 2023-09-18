using System;
using Empresa.Ecommerce.Aplication.Interface.Persistence;

namespace Empresa.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(ICustomersRepository customers, IUserRepository users)
        {
            Customers = customers;
            Users = users;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this); // GC es garbage collector
        }
    }
}
