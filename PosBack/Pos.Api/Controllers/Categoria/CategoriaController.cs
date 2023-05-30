using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Aplicacion.Interfaces;
using Pos.Infraestructura.Commons.Base.Request;

namespace Pos.Api.Controllers.Categoria
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAplicacion _categoriaAplicacion;

        public CategoriaController(ICategoriaAplicacion categoriaAplicacion)
        {
            _categoriaAplicacion = categoriaAplicacion;
        }

        //Primer método para listar las categorias con filtro
        [HttpPost]
        public async Task<IActionResult> ListaCategoriasConFiltro([FromBody] BaseFiltrosRequest filtros)
        {
            var response = await _categoriaAplicacion.ListarCategoriasConFiltro(filtros);
            return Ok(response);
        }
    }
}
