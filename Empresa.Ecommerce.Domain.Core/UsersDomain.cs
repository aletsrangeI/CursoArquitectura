using Empresa.Ecommerce.Domain.Entity;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Infrastructure.Interface;

namespace Empresa.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }
    }
}
