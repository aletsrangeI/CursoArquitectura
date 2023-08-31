using Empresa.Ecommerce.Domain.Entity;

namespace Empresa.Ecommerce.Infrastructure.Interface
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);
    }
}
