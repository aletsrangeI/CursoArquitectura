﻿using Empresa.Ecommerce.Application.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDTOValidator>();
            return services;
        }
    }
}