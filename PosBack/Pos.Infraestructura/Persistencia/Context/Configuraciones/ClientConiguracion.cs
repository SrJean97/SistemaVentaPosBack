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
    public class ClientConiguracion : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.Property(e => e.Address).IsUnicode(false);

            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.DocumentType)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clients__Documen__4BAC3F29");
        }
    }
}
