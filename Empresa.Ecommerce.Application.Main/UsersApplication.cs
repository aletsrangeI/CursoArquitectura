using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Aplication.Interface;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Transversal.Common;
using AutoMapper;
using System;

namespace Empresa.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {

        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }



        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "El usuario o la contraseña no pueden estar vacíos";
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.isSuccess = true;
                response.Message = "Autenticación exitosa";
            }
            catch (InvalidOperationException) // Esto es propio de dapper sucede cuando no se puede mapear el resultado de la consulta a un objeto
            {
                response.isSuccess = true;
                response.Message = "El usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
