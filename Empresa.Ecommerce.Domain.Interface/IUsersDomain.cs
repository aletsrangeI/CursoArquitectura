using Empresa.Ecommerce.Domain.Entity;

namespace Empresa.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
