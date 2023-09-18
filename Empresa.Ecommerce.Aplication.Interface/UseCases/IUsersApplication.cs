using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Transversal.Common;

namespace Empresa.Ecommerce.Aplication.Interface.UseCases
{
    public interface IUsersApplication
    {
        Response<UserDTO> Authenticate(string username, string password);
    }
}
