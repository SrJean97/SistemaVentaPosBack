using AutoMapper;
using Pos.Aplicacion.Dtos.Request;
using Pos.Aplicacion.Dtos.Response;
using Pos.Dominio.Entidades;
using Pos.Utilidades.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Aplicacion.Mappers
{
    public class CategoriaMappingProfile : Profile
    {
        public CategoriaMappingProfile()
        {
            //Primer mapeo
            CreateMap<Category, CategoriaResponseDto>()
                .ForMember(x => x.EstadoDescriptivo, x => x.MapFrom(y => y.State.Equals((int)CategoriaEstados.Activo) ? "Activo" : "Inactivo"))
                .ReverseMap();

            //Segundo mapeo
            
        }
    }
}
