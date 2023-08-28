using Empresa.Ecommerce.Aplication.Interface;
using Empresa.Ecommerce.Services.WebApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Empresa.Ecommerce.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static IConfiguration  _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }
        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: donde se prepara el escenario de la prueba
            
            var username = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validacion";

            //Act: donde se ejecuta el metodo a probar

            var response = context.Authenticate(username, password);
            var actual = response.Message;

            //Assert: donde se verifica el resultado de la prueba

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: donde se prepara el escenario de la prueba

            var username = "aletsrangel";
            var password = "123456";
            var expected = "Autenticación exitosa";

            //Act: donde se ejecuta el metodo a probar

            var response = context.Authenticate(username, password);
            var actual = response.Message;

            //Assert: donde se verifica el resultado de la prueba

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornaUsuarioNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: donde se prepara el escenario de la prueba

            var username = "alejandro";
            var password = "rangel";
            var expected = "El usuario no existe";

            //Act: donde se ejecuta el metodo a probar

            var response = context.Authenticate(username, password);
            var actual = response.Message;

            //Assert: donde se verifica el resultado de la prueba

            Assert.AreEqual(expected, actual);
        }
    }
}
