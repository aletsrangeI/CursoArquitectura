using System;
using Empresa.Ecommerce.Infrastructure.Interface;

namespace Empresa.Ecommerce.Infrastructure.Repository
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
