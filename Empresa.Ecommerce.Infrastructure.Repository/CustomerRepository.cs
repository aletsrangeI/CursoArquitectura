using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Empresa.Ecommerce.Infrastructure.Data;
using System.Runtime.CompilerServices;

namespace Empresa.Ecommerce.Infrastructure.Repository
{
    public class CustomerRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        #region Metodos sincronos
        public bool Insert(Customers customers)
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

        public bool Update(Customers customers)
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

        public Customers Get(string CustomerID)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", CustomerID);
                var customer = connection.QuerySingle<Customers>(
                    query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var parameters = new DynamicParameters();
                var customers = connection.Query<Customers>(
                    query,
                    commandType: CommandType.StoredProcedure
                );
                return customers;
            }
        }

        public IEnumerable<Customers> GetAllWithPagination(int page, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", page);
            parameters.Add("PageSize", pageSize);
            var customers = connection.Query<Customers>(
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
        public async Task<bool> InsertAsync(Customers customers)
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

        public async Task<bool> UpdateAsync(Customers customers)
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

        public async Task<Customers> GetAsync(string CustomerID)
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

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var parameters = new DynamicParameters();
                var customers = await connection.QueryAsync<Customers>(
                    query,
                    commandType: CommandType.StoredProcedure
                );
                return customers;
            }
        }

        public Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int page, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", page);
            parameters.Add("PageSize", pageSize);
            var customers = connection.QueryAsync<Customers>(
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
