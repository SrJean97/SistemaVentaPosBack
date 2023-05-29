using Pos.Dominio.Entidades;
using Pos.Infraestructura.Commons.Base.Request;
using Pos.Infraestructura.Commons.Base.Response;
using Pos.Infraestructura.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Repositorios
{
    public class CategoriaRepositorio : RepositorioGenerico<Category>, ICategoriaRepositorio
    {
        private readonly POSContext _context;

        public CategoriaRepositorio(POSContext context)
        {
            _context = context;
        }

        public Task<BaseEntidadResponse<Category>> ListaCategoriasConFiltro(BaseFiltrosRequest filtros)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> ListaCategoriasSinFiltro()
        {
            throw new NotImplementedException();
        }

        public Task<Category> BuscarCategoriaxId(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrarCategoria(Category categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarCategoria(Category categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }
  
    }
}
