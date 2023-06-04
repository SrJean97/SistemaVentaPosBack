using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Aplicacion.Dtos.Request;
using Pos.Aplicacion.Interfaces;
using Pos.Utilidades.Constantes;

namespace Pos.Test.Categoria
{
    [TestClass]
    public class CategoriaAplicacionTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopefactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _textContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopefactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegistrarCategoria_CuandoEnviaNulosVacios_ValidacionesError()
        {
            using var scope = _scopefactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoriaAplicacion>();

            //Arrange
            var name = "";
            var description = "";
            var state = 1;

            var esperado = MensajeRespuestas.MENSAJE_VALIDACION;

            //Action
            var resultado = await context!.RegistrarCategoria(new CategoriaRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = resultado.Mensaje;

            //Asset
            Assert.AreEqual(esperado, current);
           
        }

        [TestMethod]
        public async Task RegistrarCategoria_CuandoEnviaValoresCorrectos_RegistroExitoso()
        {
            using var scope = _scopefactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoriaAplicacion>();

            //Arrange
            var name = "Cartas de vecindad";
            var description = "Cartas de vecindad expedida por la jagua de Ibirico";
            var state = 1;
            var resultadoEsperado = MensajeRespuestas.MENSAJE_GUARDADO;

            //Action
            var resultado = await context!.RegistrarCategoria(new CategoriaRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = resultado.Mensaje;

            //Assert
            Assert.AreEqual(resultadoEsperado, current);
        }
    }
}
