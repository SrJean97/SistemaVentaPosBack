using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infraestructura.Persistencia.Context.Configuraciones
{
    public class CategoryConfiguracion : IEntityTypeConfiguration<Category>
    {
        
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.Property(e => e.Id).HasColumnName("CategoryId");

            entity.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
