using Empresa.Ecommerce.Aplication.Interface.UseCases;
using Empresa.Ecommerce.Application.UseCases.Customers;
using Empresa.Ecommerce.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Ecommerce.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            return services;
        }
    }
}
