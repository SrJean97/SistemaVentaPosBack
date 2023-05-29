using Pos.Aplicacion.Commons.Base;
using Pos.Aplicacion.Dtos.Request;
using Pos.Aplicacion.Dtos.Response;
using Pos.Dominio.Entidades;
using Pos.Infraestructura.Commons.Base.Request;
using Pos.Infraestructura.Commons.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Aplicacion.Interfaces
{
    public interface ICategoriaAplicacion
    {
        Task<BaseResponse<BaseEntidadResponse<CategoriaResponseDto>>> ListarCategoriasConFiltro(BaseFiltrosRequest filtros);
        Task<BaseResponse<IEnumerable<CategoriaSelectResponseDto>>> ListarCategoriasSinFiltro();
        Task<BaseResponse<CategoriaResponseDto>> BuscarCategoriaxId(int categoriaId);
        Task<BaseResponse<bool>> RegistrarCategoria(CategoriaRequestDto requestDto);
        Task<BaseResponse<bool>> EditarCategoria(int categoriaId, CategoriaRequestDto requestDto);
        Task<BaseResponse<bool>> EliminarCategoria(int CategoriaId);
    }
}
