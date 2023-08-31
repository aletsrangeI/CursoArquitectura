using System;
using System.Collections.Generic;
using System.Text;
using Empresa.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Empresa.Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Metodos Sincronos
        bool Insert(Customers customers);
        bool Update(Customers customers);
        bool Delete(string customerId);
        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();

        #endregion

        #region Metodos Asincronos
        Task<bool> InsertAsync(Customers customers);
        Task<bool> UpdateAsync(Customers customers);
        Task<bool> DeleteAsync(string customerId);
        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
