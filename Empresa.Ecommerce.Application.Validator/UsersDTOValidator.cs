using System;
using FluentValidation;
using Empresa.Ecommerce.Application.DTO;

namespace Empresa.Ecommerce.Application.Validator
{
    public class UsersDTOValidator : AbstractValidator<UserDTO>
    {
        public UsersDTOValidator() 
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
