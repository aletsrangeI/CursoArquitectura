using Empresa.Ecommerce.Domain.Entity;

namespace Empresa.Ecommerce.Aplication.Interface.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
