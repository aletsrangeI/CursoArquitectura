using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Empresa.Ecommerce.Transversal.Maper;
using Empresa.Ecommerce.Transversal.Common;
using Empresa.Ecommerce.Infrastructure.Data;
using Empresa.Ecommerce.Infrastructure.Repository;
using Empresa.Ecommerce.Infrastructure.Interface;
using Empresa.Ecommerce.Domain.Interface;
using Empresa.Ecommerce.Domain.Core;
using Empresa.Ecommerce.Aplication.Interface;
using Empresa.Ecommerce.Application.Main;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Empresa.Ecommerce.Services.WebApi.Helpers;

namespace Empresa.Ecommerce.Services.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policyApiEcommerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(Configuration["Config:OriginCors"])
                                                                                      .AllowAnyHeader()
                                                                                      .AllowAnyMethod()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection); // Se hace el mapeo de los valores contenidos en appsettings a la clase AppSettings
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Empresa.Ecommerce.Services.WebApi",
                    Description = "Curso Arquitectura de aplicaciones .net"
                });
                //set the comments path for the swagger json and ui

                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger(); //Enable middleware to serve generated Swagger as a JSON endpoint.

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresa.Ecommerce.Services.WebApi");
            }); //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.

            app.UseCors(myPolicy);

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
