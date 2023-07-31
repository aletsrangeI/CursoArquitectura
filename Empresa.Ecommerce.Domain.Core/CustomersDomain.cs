﻿using System;
using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace Empresa.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private  readonly ICustomersDomain _customersRepository;

        public CustomersDomain(ICustomersDomain customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region Metodos Sincronos
        public bool Insert(Customers customers)
        {
            return _customersRepository.Insert(customers);
        }

        public bool Update(Customers customers)
        {
            return _customersRepository.Update(customers);
        }

        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _customersRepository.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }
        #endregion

        #region Metodos Asincronos
        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _customersRepository.InsertAsync(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _customersRepository.UpdateAsync(customers);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customersRepository.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }
        #endregion
    }
}
