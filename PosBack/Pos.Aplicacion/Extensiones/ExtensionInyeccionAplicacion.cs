using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Aplicacion.Interfaces;
using Pos.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Aplicacion.Extensiones
{
    public static class ExtensionInyeccionAplicacion
    {
        public static IServiceCollection AgregarInyeccionAplicacion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            //Hacer uso de fluent validation
            services.AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            //Agregado servicio de automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Agregar interaz a nivel de la aplicación.
            services.AddScoped<ICategoriaAplicacion, CategoriaServicioAplicacion>();

            return services;
        }
    }
}
