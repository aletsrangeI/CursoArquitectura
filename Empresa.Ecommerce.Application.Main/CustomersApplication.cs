using System;
using AutoMapper;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Aplication.Interface;
using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Empresa.Ecommerce.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(
            ICustomersDomain customersDomain,
            IMapper mapper,
            IAppLogger<CustomersApplication> logger
        )
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Metodos Sincronos
        public Response<bool> Insert(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = "Eliminación exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta exitosa";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public ResponsePagination<IEnumerable<CustomersDTO>> GetAllWithPagination(
            int PageNumber,
            int PageSize
        )
        {
            var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
            try
            {
                var count = _customersDomain.Count();
                var customers = _customersDomain.GetAllWithPagination(PageNumber, PageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta exitosa";
                    response.PageNumber = PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                    response.TotalCount = count;
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        #endregion

        #region Metodos Asincronos
        public async Task<Response<bool>> InsertAsync(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customers);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = "Eliminación exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllWithPaginationAsync(int PageNumber, int PageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
            try
            {
                var count = await _customersDomain.CountAsync();
                var customers = await _customersDomain.GetAllWithPaginationAsync(PageNumber, PageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta exitosa";
                    response.PageNumber = PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                    response.TotalCount = count;
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        #endregion
    }
}
