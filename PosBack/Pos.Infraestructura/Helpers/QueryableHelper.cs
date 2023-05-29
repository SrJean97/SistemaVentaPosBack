using Pos.Infraestructura.Commons.Base.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Helpers
{
    public static class QueryableHelper
    {
        //Necesito retornar los registros iniciales de la paginación
        public static IQueryable Paginacion(this IQueryable queryable, BasePaginacionRequest request)
        {
            //Skip -> Va a omitir de la primera pagina los registros iniciales.
            //Take -> Va a mostrar los registros de la página inicial.   
            return queryable.Skip((request.NumPagina - 1) * request.RegistroInicial).Take(request.RegistroInicial);
        }
    }
}
