using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Data;
using Empresa.Ecommerce.Infrastructure.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Empresa.Ecommerce.Infrastructure.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public Users Authenticate(string username, string password)
        {
            using(var connection = _context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public Users Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Users> GetAllWithPagination(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllWithPaginationAsync(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<Users> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
