﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Infraestructura.Persistencia;
using Pos.Infraestructura.Persistencia.Interfaces;
using Pos.Infraestructura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Extensiones
{
    public static class ExtensionInyeccionInfraestructura
    {
        public static IServiceCollection AgregarInyeccionInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(POSContext).Assembly.FullName;

            services.AddDbContext<POSContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("PosConnection"), b => b.MigrationsAssembly(assembly)),ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            return services;
        }
    }
}
