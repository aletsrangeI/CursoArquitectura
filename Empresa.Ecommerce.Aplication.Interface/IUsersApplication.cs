using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Transversal.Common;

namespace Empresa.Ecommerce.Aplication.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
