using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Ecommerce.Services.WebApi
{
    public static class FeatureExtension
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {

            string myPolicy = "policyApiEcommerce";
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod()));
            services.AddMvc();
            return services;
        }
    }
}
