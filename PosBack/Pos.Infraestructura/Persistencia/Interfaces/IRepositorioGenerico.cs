using Pos.Dominio.Entidades;
using Pos.Infraestructura.Commons.Base.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Interfaces
{
    public interface IRepositorioGenerico<T> where T : EntidadBase
    {
        //Este repositorio generico va a contener el crud común entre todas las clases conocidas.
        //Acá el único repositorio que no se va a encontrar es el de buscado por iltros de categoría, ese le pertenece a la categoría y solo a la categoría como tal.

        Task<IEnumerable<T>> ObtenerTodoAsync();
        Task<T> ConsultarPorIdAsync(int id);
        Task<bool> RegistrarAsync(T entidad);
        Task<bool> EditarAsync(T entidad);
        Task<bool> DeleteAsync(int id);

        //Método Queryable que sirve para realizarconsultas query de base de datos
        IQueryable<T> BuscarEntidadQuery(Expression<Func<T, bool>>? filter = null);

        public IQueryable<TDTO> Ordenamiento<TDTO>(BasePaginacionRequest bpr, IQueryable<TDTO> queryable, bool paginacion = false) where TDTO : class;
    }
}
