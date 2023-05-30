using Microsoft.EntityFrameworkCore;
using Pos.Dominio.Entidades;
using Pos.Infraestructura.Commons.Base.Request;
using Pos.Infraestructura.Commons.Base.Response;
using Pos.Infraestructura.Persistencia.Interfaces;
using Pos.Utilidades.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<BaseEntidadResponse<Category>> ListaCategoriasConFiltro(BaseFiltrosRequest filtros)
        {
            //Primero inicializar nuestra BaseEntidadResponse
            var response = new BaseEntidadResponse<Category>();

            //Realizar consulta con LinQ
            var categoriasBuscadas = (from c in _context.Categories
                                      where c.AuditDeleteUser == null && c.AuditDeleteDate == null
                                      select c).AsNoTracking().AsQueryable();
            
            //La misma consulta sin LinQ
            //var categoriasBuscadas2 = await _context.Categories.Where(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null).AsNoTracking().ToListAsync();

            //Luego de consultar de la base de datos todas las categorias, apliquemos el primer filtro
            if (filtros.NumeroTipoFiltro is not null && filtros.TextoFiltro is not null )
            {
                switch (filtros.NumeroTipoFiltro)
                {
                    case 1:
                        categoriasBuscadas = categoriasBuscadas.Where(x => x.Name!.Contains(filtros.TextoFiltro));
                        break;
                    case 2:
                        categoriasBuscadas = categoriasBuscadas.Where(x => x.Description!.Contains(filtros.TextoFiltro));
                        break;
                }
            }

            if (filtros.EstadoFiltro is not null)
            {
                categoriasBuscadas = categoriasBuscadas.Where(x => x.State.Equals(filtros.EstadoFiltro));
            }

            if (!string.IsNullOrEmpty(filtros.FechaInicio) && !string.IsNullOrEmpty(filtros.FechaFinal))
            {
                categoriasBuscadas = categoriasBuscadas.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filtros.FechaInicio) &&
                                                                x.AuditCreateDate <= Convert.ToDateTime(filtros.FechaFinal));
            }

            if (filtros.AtributoPorCualOrdenar is null) filtros.AtributoPorCualOrdenar = "CategoryId";

            response.TotalRegistros = await categoriasBuscadas.CountAsync();
            response.TotalItems = await Ordenamiento(filtros, categoriasBuscadas, !(bool)filtros.DescargaExcel!).ToListAsync();


            return response;
        }

        public async Task<IEnumerable<Category>> ListaCategoriasSinFiltro()
        {
            var categoriasVigentes = await _context.Categories
                .Where(x => x.State.Equals((int)CategoriaEstados.Activo) && x.AuditDeleteUser == null && x.AuditDeleteDate == null).AsNoTracking().ToListAsync();
            return categoriasVigentes;
        }

        public async Task<Category> BuscarCategoriaxId(int idCategoria)
        {
            //var categoriaBuscada = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId.Equals(idCategoria));
            var categoriaBuscada = await _context.Categories.FindAsync(idCategoria);

            return categoriaBuscada!;
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
