using Pos.Dominio.Entidades;
using Pos.Infraestructura.Commons.Base.Request;
using Pos.Infraestructura.Commons.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Interfaces
{
    public interface ICategoriaRepositorio : IRepositorioGenerico<Category>
    {
        //Buscar las categorias aplicando algun tipo de filtro
        Task<BaseEntidadResponse<Category>> ListaCategoriasConFiltro(BaseFiltrosRequest filtros);

        //Buscar las categorias sin filtro.
        Task<IEnumerable<Category>> ListaCategoriasSinFiltro();

        //Buscar categoria por id
        Task<Category> BuscarCategoriaxId(int idCategoria);

        //Registrar una categoria.
        Task<bool> RegistrarCategoria(Category categoria);

        //Editar una categoria
        Task<bool> EditarCategoria(Category categoria);

        //Eliminar una categoria.
        Task<bool> EliminarCategoria(int idCategoria);
    }
}
