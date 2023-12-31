﻿using Empresa.Ecommerce.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Ecommerce.Services.WebApi.Modules.HealthCheck;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddHealthCheck(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddHealthChecks()
            .AddSqlServer(
                configuration.GetConnectionString("NorthwindConnection"),
                tags: new[] { "db", "sql", "sqlserver" }
            )
            .AddCheck<HealthCheckCustom>(
                "HealthCheckCustom",
                failureStatus: null,
                tags: new[] { "custom" }
            );
        services.AddHealthChecksUI().AddInMemoryStorage();
        return services;
    }
}
