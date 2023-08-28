using System;
using AutoMapper;
using Empresa.Ecommerce.Transversal.Maper;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Ecommerce.Services.WebApi
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services){
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
