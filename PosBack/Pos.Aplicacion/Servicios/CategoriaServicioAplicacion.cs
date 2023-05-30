using AutoMapper;
using Pos.Aplicacion.Commons.Base;
using Pos.Aplicacion.Dtos.Request;
using Pos.Aplicacion.Dtos.Response;
using Pos.Aplicacion.Interfaces;
using Pos.Aplicacion.Validaciones.Categoria;
using Pos.Infraestructura.Commons.Base.Request;
using Pos.Infraestructura.Commons.Base.Response;
using Pos.Infraestructura.Persistencia.Interfaces;
using Pos.Utilidades.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Aplicacion.Servicios
{
    public class CategoriaServicioAplicacion : ICategoriaAplicacion
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoriaValidaciones _validaciones;

        public CategoriaServicioAplicacion(IUnitOfWork unitOfWork, IMapper mapper, CategoriaValidaciones validaciones)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validaciones = validaciones;
        }

        public async Task<BaseResponse<BaseEntidadResponse<CategoriaResponseDto>>> ListarCategoriasConFiltro(BaseFiltrosRequest filtros)
        {
            var response = new BaseResponse<BaseEntidadResponse<CategoriaResponseDto>>();
            var categoriasFiltradas = await _unitOfWork.CategoriaRepositorio.ListaCategoriasConFiltro(filtros);

            if (categoriasFiltradas is not null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map<BaseEntidadResponse<CategoriaResponseDto>>(categoriasFiltradas);
                response.Mensaje = MensajeRespuestas.MENSAJE_CONSULTA;
            }
            else
            {
                response.IsSuccess= false;
                response.Mensaje = MensajeRespuestas.MENSAJE_QUERY_VACIO;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategoriaSelectResponseDto>>> ListarCategoriasSinFiltro()
        {
            var response = new BaseResponse<IEnumerable<CategoriaSelectResponseDto>>();
            var categoriasBuscadas = await _unitOfWork.CategoriaRepositorio.ListaCategoriasSinFiltro();

            if (categoriasBuscadas is not null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map<IEnumerable<CategoriaSelectResponseDto>>(categoriasBuscadas);
                response.Mensaje = MensajeRespuestas.MENSAJE_CONSULTA;
            }
            else
            {
                response.IsSuccess= false;
                response.Mensaje = MensajeRespuestas.MENSAJE_QUERY_VACIO;
            }
            return response;
        }

        public Task<BaseResponse<CategoriaResponseDto>> BuscarCategoriaxId(int categoriaId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RegistrarCategoria(CategoriaRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditarCategoria(int categoriaId, CategoriaRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EliminarCategoria(int CategoriaId)
        {
            throw new NotImplementedException();
        }
        
    }
}
