using AutoMapper;
using Empresa.Ecommerce.Aplication.Interface.Persistence;
using Empresa.Ecommerce.Aplication.Interface.UseCases;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Ecommerce.Application.UseCases.Customers
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<CustomersApplication> logger
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Metodos Sincronos
        public Response<bool> Insert(CustomerDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customers);
                response.Data = _unitOfWork.Customers.Insert(customer);
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

        public Response<bool> Update(CustomerDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customers);
                response.Data = _unitOfWork.Customers.Update(customer);
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
                response.Data = _unitOfWork.Customers.Delete(customerId);
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

        public Response<CustomerDTO> Get(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = _unitOfWork.Customers.Get(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);
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

        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = _unitOfWork.Customers.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
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

        public ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(
            int PageNumber,
            int PageSize
        )
        {
            var response = new ResponsePagination<IEnumerable<CustomerDTO>>();
            try
            {
                var count = _unitOfWork.Customers.Count();
                var customers = _unitOfWork.Customers.GetAllWithPagination(PageNumber, PageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

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
        public async Task<Response<bool>> InsertAsync(CustomerDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customers);
                response.Data = await _unitOfWork.Customers.InsertAsync(customer);
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

        public async Task<Response<bool>> UpdateAsync(CustomerDTO customers)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customers);
                response.Data = await _unitOfWork.Customers.UpdateAsync(customer);
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
                response.Data = await _unitOfWork.Customers.DeleteAsync(customerId);
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

        public async Task<Response<CustomerDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = await _unitOfWork.Customers.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);
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

        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _unitOfWork.Customers.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
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

        public async Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int PageNumber, int PageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDTO>>();
            try
            {
                var count = await _unitOfWork.Customers.CountAsync();
                var customers = await _unitOfWork.Customers.GetAllWithPaginationAsync(PageNumber, PageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

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
