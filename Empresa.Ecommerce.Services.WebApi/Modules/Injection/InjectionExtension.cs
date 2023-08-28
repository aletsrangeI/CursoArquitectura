using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Empresa.Ecommerce.Aplication.Interface;
using Empresa.Ecommerce.Application.Main;
using Empresa.Ecommerce.Domain.Core;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Infrastructure.Data;
using Empresa.Ecommerce.Infrastructure.Interface;
using Empresa.Ecommerce.Infrastructure.Repository;
using Empresa.Ecommerce.Transversal.Common;
using Empresa.Ecommerce.Transversal.Logging;


namespace Empresa.Ecommerce.Services.WebApi
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
