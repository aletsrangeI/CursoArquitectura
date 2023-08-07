﻿using System;
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

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
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
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
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
        #endregion


        

    }
}
