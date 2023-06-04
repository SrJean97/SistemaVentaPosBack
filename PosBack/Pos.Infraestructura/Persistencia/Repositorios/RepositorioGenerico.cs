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
using Pos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Pos.Utilidades.Constantes;
using System.Linq.Expressions;

namespace Pos.Infraestructura.Persistencia.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : EntidadBase
    {
        //Acá especificaremos los métodos reutilizables.

        private readonly POSContext _context;
        private readonly DbSet<T> _entidad;

        public RepositorioGenerico(POSContext context)
        {
            _context = context;
            _entidad = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObtenerTodoAsync()
        {
            var response =  await _entidad.Where(x => x.State.Equals((int)CategoriaEstados.Activo) && x.AuditDeleteUser == null && x.AuditDeleteDate == null).AsNoTracking().ToListAsync();

            return response;
        }

        public async Task<T> ConsultarPorIdAsync(int id)
        {
            var response = await _entidad.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return response!;
        }

        public async Task<bool> RegistrarAsync(T entidad)
        {
            entidad.AuditCreateUser = 1;
            entidad.AuditCreateDate = DateTime.Now;

            await _context.AddAsync(entidad);
            var registrosAfectados = await _context.SaveChangesAsync();

            return registrosAfectados > 0;
        }

        public async Task<bool> EditarAsync(T entidad)
        {
            entidad.AuditUpdateUser = 1;
            entidad.AuditUpdateDate = DateTime.Now;

            _context.Update(entidad);
            var registrosAfectados = await _context.SaveChangesAsync();
            return registrosAfectados > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            T entidad = await ConsultarPorIdAsync(id);

            entidad.AuditDeleteUser = 1;
            entidad.AuditDeleteDate = DateTime.Now;

            _context.Update(entidad);
            var registrosAfectado = await _context.SaveChangesAsync();
            return registrosAfectado > 0;
        }

        public IQueryable<T> BuscarEntidadQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entidad;
            if(filter != null) query = query.Where(filter);
            return query;
        }


        //Especificar el método que nos va a organizar los atributos
        public IQueryable<TDTO> Ordenamiento<TDTO>(BasePaginacionRequest bpr, IQueryable<TDTO> queryable, bool paginacion = false) where TDTO : class
        {
            IQueryable<TDTO> queryDtoResultadoOrdenado = bpr.Ordenar == "desc" ? queryable.OrderBy($"{bpr.AtributoPorCualOrdenar} descending") : queryable.OrderBy($"{bpr.AtributoPorCualOrdenar} ascending");

            if (paginacion) queryDtoResultadoOrdenado = queryDtoResultadoOrdenado.Paginacion(bpr);

            return queryDtoResultadoOrdenado;
        }

    }
}
