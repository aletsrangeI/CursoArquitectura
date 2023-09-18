using Empresa.Ecommerce.Transversal.Common;
using Empresa.Ecommerce.Transversal.Logging;

namespace Empresa.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
