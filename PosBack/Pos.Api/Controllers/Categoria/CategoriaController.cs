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
        [HttpPost("ListaConFiltros")]
        public async Task<IActionResult> ListaCategoriasConFiltro([FromBody] BaseFiltrosRequest filtros)
        {
            var response = await _categoriaAplicacion.ListarCategoriasConFiltro(filtros);
            return Ok(response);
        }

        //Listar categorias sin iltros
        [HttpGet("ListaSinFiltros")]
        public async Task<IActionResult> ListaCategoriasSinFiltro()
        {
            var response = await _categoriaAplicacion.ListarCategoriasSinFiltro();
            return Ok(response);
        }

        [HttpGet("{categoriaId:int}")]
        public async Task<IActionResult> BuscarCategoriaxId(int categoriaId)
        {
            var response = await _categoriaAplicacion.BuscarCategoriaxId(categoriaId);
            return Ok(response);
        }
    }
}
