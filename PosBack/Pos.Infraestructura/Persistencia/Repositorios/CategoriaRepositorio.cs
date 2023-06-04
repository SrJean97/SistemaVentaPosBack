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

        public CategoriaRepositorio(POSContext context) : base(context) { }

        public async Task<BaseEntidadResponse<Category>> ListaCategoriasConFiltro(BaseFiltrosRequest filtros)
        {
            
            var response = new BaseEntidadResponse<Category>();


            var categoriasBuscadas = BuscarEntidadQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);

            
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

            if (filtros.AtributoPorCualOrdenar is null) filtros.AtributoPorCualOrdenar = "Id";

            response.TotalRegistros = await categoriasBuscadas.CountAsync();
            response.TotalItems = await Ordenamiento(filtros, categoriasBuscadas, !(bool)filtros.DescargaExcel!).ToListAsync();


            return response;
        }

        //public async Task<IEnumerable<Category>> ListaCategoriasSinFiltro()
        //{
        //    var categoriasVigentes = await _context.Categories
        //        .Where(x => x.State.Equals((int)CategoriaEstados.Activo) && x.AuditDeleteUser == null && x.AuditDeleteDate == null).AsNoTracking().ToListAsync();
        //    return categoriasVigentes;

        //}

        //public async Task<Category> BuscarCategoriaxId(int idCategoria)
        //{
        //    //Cualquiera de estos dos métodos de busqueda funcionan
        //    var categoriaBuscada = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(idCategoria));
        //    //var categoriaBuscada = await _context.Categories.FindAsync(idCategoria);

        //    return categoriaBuscada!;
        //}

        //public async Task<bool> RegistrarCategoria(Category categoria)
        //{
        //    categoria.AuditCreateUser = 1;
        //    categoria.AuditCreateDate = DateTime.Now;

        //    await _context.AddAsync(categoria);
        //    var registrosAfectados = await _context.SaveChangesAsync();
        //    return registrosAfectados > 0;
        //}

        //public async Task<bool> EditarCategoria(Category categoria)
        //{
        //    categoria.AuditUpdateUser = 1;
        //    categoria.AuditUpdateDate = DateTime.Now;

        //    _context.Update(categoria);
        //    _context.Entry(categoria).Property(x => x.AuditCreateUser).IsModified = false;
        //    _context.Entry(categoria).Property(x => x.AuditCreateDate).IsModified = false;

        //    var registrosAfectados = await _context.SaveChangesAsync();
        //    return registrosAfectados > 0;
        //}

        //public async Task<bool> EliminarCategoria(int idCategoria)
        //{
        //    //Acá podemos reutilizar el método o sinpmelente hacer una consula LINQ
        //    var categoriaBuscada = await BuscarCategoriaxId(idCategoria);

        //    categoriaBuscada.AuditDeleteUser = 1;
        //    categoriaBuscada.AuditDeleteDate = DateTime.Now;
        //    categoriaBuscada.State = 0;

        //    _context.Update(categoriaBuscada);
        //    var registrosAfectados = await _context.SaveChangesAsync();
        //    return registrosAfectados > 0;
        //}
  
    }
}
