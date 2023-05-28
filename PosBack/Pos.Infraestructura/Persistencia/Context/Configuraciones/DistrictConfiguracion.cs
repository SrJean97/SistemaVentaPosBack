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
    public class DistrictConfiguracion : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> entity)
        {
            entity.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsUnicode(false);

            entity.HasOne(d => d.Province)
                .WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Districts_Provinces");
        }
    }
}
