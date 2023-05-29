using Pos.Infraestructura.Commons.Base.Request;
using Pos.Infraestructura.Persistencia.Interfaces;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Pos.Infraestructura.Helpers;

namespace Pos.Infraestructura.Persistencia.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        //Acá especificaremos los métodos reutilizables.
        //Especificar el método que nos va a organizar los atributos
        public IQueryable<TDTO> Ordenamiento<TDTO>(BasePaginacionRequest bpr, IQueryable<TDTO> queryable, bool paginacion = false) where TDTO : class
        {
            IQueryable<TDTO> queryDtoResultadoOrdenado = bpr.Ordenar == "desc" ? queryable.OrderBy($"{bpr.AtributoPorCualOrdenar} descending") : queryable.OrderBy($"{bpr.AtributoPorCualOrdenar} ascending");

            if (paginacion) queryDtoResultadoOrdenado = queryDtoResultadoOrdenado.Paginacion(bpr);

            return queryDtoResultadoOrdenado;
        }
    }
}
