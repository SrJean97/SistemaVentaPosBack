using Pos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Interfaces
{
    public interface IRepositorioGenerico<T> where T : EntidadBase
    {
        //Este repositorio generico va a contener el crud común entre todas las clases conocidas.
        //Acá el único repositorio que no se va a encontrar es el de buscado por iltros de categoría, ese le pertenece a la categoría y solo a la categoría como tal.

        Task<IEnumerable<T>> ObtenerTodoAsync();

        Task<T> ConsultarAsync(int id);
    }
}
