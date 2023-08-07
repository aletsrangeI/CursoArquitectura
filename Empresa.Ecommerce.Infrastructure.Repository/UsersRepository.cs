using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Infrastructure.Interface;
using Empresa.Ecommerce.Transversal.Common;
using Dapper;
using System.Data;

namespace Empresa.Ecommerce.Infrastructure.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
