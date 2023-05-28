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
    public class BusinessConfiguracion : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> entity)
        {
            entity.ToTable("Business");

            entity.Property(e => e.Address).IsUnicode(false);

            entity.Property(e => e.BusinessName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Logo).IsUnicode(false);

            entity.Property(e => e.Mision).IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.Vision).IsUnicode(false);

            entity.HasOne(d => d.District)
                .WithMany(p => p.Businesses)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Business__Distri__4AB81AF0");
        }
    }
}
