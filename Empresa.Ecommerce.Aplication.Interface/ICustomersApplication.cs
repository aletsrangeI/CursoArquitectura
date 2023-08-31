using System;
using System.Collections.Generic;
using System.Text;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Transversal.Common;
using System.Threading.Tasks;


namespace Empresa.Ecommerce.Aplication.Interface
{
    public interface ICustomersApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(CustomersDTO customers);
        Response<bool> Update(CustomersDTO customers);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> Get(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomersDTO>> GetAllWithPagination(int PageNumber, int PageSize);
        #endregion

        #region Metodos Asincronos
        Task<Response<bool>> InsertAsync(CustomersDTO customers);
        Task<Response<bool>> UpdateAsync(CustomersDTO customers);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllWithPaginationAsync(int PageNumber, int PageSize);
        #endregion
    }
}
