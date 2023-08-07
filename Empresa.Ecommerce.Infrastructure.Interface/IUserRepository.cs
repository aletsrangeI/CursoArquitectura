using Empresa.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Ecommerce.Infrastructure.Interface
{
    public interface IUserRepository
    {
        Users Authenticate(string username, string password);
    }
}
