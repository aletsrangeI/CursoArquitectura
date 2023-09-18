using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Empresa.Ecommerce.Ecommerce.Services.WebApi.Modules.HealthCheck;
public class HealthCheckCustom : IHealthCheck
{
    private readonly Random _random = new();

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default
    )
    {
        var responseTime = _random.Next(1, 300);

        if (responseTime < 100)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy($"The response time is {responseTime} ms")
            );
        }
        else if (responseTime < 200)
        {
            return Task.FromResult(
                HealthCheckResult.Degraded($"The response time is {responseTime} ms")
            );
        }
        else
        {
            return Task.FromResult(
                HealthCheckResult.Unhealthy($"The response time is {responseTime} ms")
            );
        }
    }
}
