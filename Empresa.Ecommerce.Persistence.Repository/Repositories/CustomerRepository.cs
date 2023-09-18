using Dapper;
using Empresa.Ecommerce.Aplication.Interface.Persistence;
using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Persistence.Context;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Empresa.Ecommerce.Persistence.Repositories
{
    public class CustomerRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        #region Metodos sincronos
        public bool Insert(Customer customers)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerID);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);
                var result = connection.Execute(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public bool Update(Customer customers)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerID);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);
                var result = connection.Execute(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public bool Delete(string CustomerID)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", CustomerID);
                var result = connection.Execute(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public Customer Get(string CustomerID)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", CustomerID);
                var customer = connection.QuerySingle<Customer>(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return customer;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var parameters = new DynamicParameters();
                var customers = connection.Query<Customer>(
                    query,
                    commandType: CommandType.StoredProcedure
                );
                return customers;
            }
        }

        public IEnumerable<Customer> GetAllWithPagination(int page, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", page);
            parameters.Add("PageSize", pageSize);
            var customers = connection.Query<Customer>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure
            );
            return customers;
        }

        public int Count()
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT COUNT(*) FROM Customers";
            var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion

        #region Metodos asincronos
        public async Task<bool> InsertAsync(Customer customers)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerID);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);
                var result = await connection.ExecuteAsync(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customer customers)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerID);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);
                var result = await connection.ExecuteAsync(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string CustomerID)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", CustomerID);
                var result = await connection.ExecuteAsync(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public async Task<Customer> GetAsync(string CustomerID)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", CustomerID);
                var customer = await connection.QuerySingleAsync(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return customer;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var parameters = new DynamicParameters();
                var customers = await connection.QueryAsync<Customer>(
                    query,
                    commandType: CommandType.StoredProcedure
                );
                return customers;
            }
        }

        public Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int page, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", page);
            parameters.Add("PageSize", pageSize);
            var customers = connection.QueryAsync<Customer>(
                query,
                param: parameters,
                commandType: CommandType.StoredProcedure
            );
            return customers;
        }

        public Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT COUNT(*) FROM Customers";
            var count = connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion
    }
}
