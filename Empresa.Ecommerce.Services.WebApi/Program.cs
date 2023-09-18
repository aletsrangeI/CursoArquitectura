using Empresa.Ecommerce.Application.UseCases;
using Empresa.Ecommerce.Persistence;
using Empresa.Ecommerce.Services.WebApi.Modules.Authentication;
using Empresa.Ecommerce.Services.WebApi.Modules.Feature;
using Empresa.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Empresa.Ecommerce.Services.WebApi.Modules.Injection;
using Empresa.Ecommerce.Services.WebApi.Modules.Mapper;
using Empresa.Ecommerce.Services.WebApi.Modules.RateLimiter;
using Empresa.Ecommerce.Services.WebApi.Modules.Swagger;
using Empresa.Ecommerce.Services.WebApi.Modules.Validator;
using Empresa.Ecommerce.Services.WebApi.Modules.Watch;
using HealthChecks.UI.Client;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();

// configure the Http request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresa.Ecommerce.Services.WebApi");
        }); //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    });
}
app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks(
    "/health",
    new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }
);

app.UseWatchDog(conf => {
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});

app.Run();

public partial class Program { };
