using System;
using System.Collections.Generic;
using System.Text;
using Empresa.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Empresa.Ecommerce.Aplication.Interface.Persistence
{
    public interface ICustomersRepository : IGenericRepository<Customer> { }
}
