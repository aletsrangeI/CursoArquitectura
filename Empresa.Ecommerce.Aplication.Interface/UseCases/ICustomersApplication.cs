using System;
using System.Collections.Generic;
using System.Text;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Transversal.Common;
using System.Threading.Tasks;


namespace Empresa.Ecommerce.Aplication.Interface.UseCases
{
    public interface ICustomersApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(CustomerDTO customers);
        Response<bool> Update(CustomerDTO customers);
        Response<bool> Delete(string customerId);
        Response<CustomerDTO> Get(string customerId);
        Response<IEnumerable<CustomerDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int PageNumber, int PageSize);
        #endregion

        #region Metodos Asincronos
        Task<Response<bool>> InsertAsync(CustomerDTO customers);
        Task<Response<bool>> UpdateAsync(CustomerDTO customers);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int PageNumber, int PageSize);
        #endregion
    }
}
