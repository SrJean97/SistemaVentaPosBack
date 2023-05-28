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
    public class BranchOfficeConfiguracion : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> entity)
        {
            entity.Property(e => e.Address).IsUnicode(false);

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Business)
                .WithMany(p => p.BranchOffices)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BranchOff__Busin__48CFD27E");

            entity.HasOne(d => d.District)
                .WithMany(p => p.BranchOffices)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BranchOff__Distr__49C3F6B7");
        }
    }
}
