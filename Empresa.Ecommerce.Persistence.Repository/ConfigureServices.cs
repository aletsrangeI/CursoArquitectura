using Empresa.Ecommerce.Aplication.Interface.Persistence;
using Empresa.Ecommerce.Persistence.Context;
using Empresa.Ecommerce.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
