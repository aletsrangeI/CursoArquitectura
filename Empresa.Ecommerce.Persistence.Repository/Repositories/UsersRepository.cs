using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Aplication.Interface.Persistence;
using Dapper;
using System.Data;
using Empresa.Ecommerce.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Empresa.Ecommerce.Persistence.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public User Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllWithPagination(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllWithPaginationAsync(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
