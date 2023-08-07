using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Infrastructure.Interface;

namespace Empresa.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUserRepository _usersRepository;

        public UsersDomain(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
