using Empresa.Ecommerce.Aplication.Interface;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Services.WebApi.Helpers;
using Empresa.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Empresa.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost, ActionName("Authenticate")]
        public IActionResult Authenticate([FromBody] UsersDTO usersDto)
        {
            var response = _usersApplication.Authenticate(usersDto.UserName, usersDto.Password);

            if (!response.isSuccess) return BadRequest(response);

            if (response.Data == null) return NotFound(response.Message);

            response.Data.Token = BuildToken(response);
            return Ok(response);
        }

        private string BuildToken(Response<UsersDTO> usersDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDTO.Data.UserId.ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
