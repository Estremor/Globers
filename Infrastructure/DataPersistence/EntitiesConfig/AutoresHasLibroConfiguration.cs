using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataPersistence.EntitiesConfig
{
    public class AutoresHasLibroConfiguration : IEntityTypeConfiguration<AutoresHasLibro>
    {
        public void Configure(EntityTypeBuilder<AutoresHasLibro> entity)
        {
            entity.HasKey(e => new { e.AutoresId, e.LibrosIsbn });

            entity.ToTable("Autores_has_libros");

            entity.Property(e => e.AutoresId).HasColumnName("Autores_Id");

            entity.Property(e => e.LibrosIsbn).HasColumnName("Libros_ISBN");

            entity.HasOne(d => d.Autores)
                .WithMany(p => p.AutoresHasLibros)
                .HasForeignKey(d => d.AutoresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autores_has_libros_Autores");

            entity.HasOne(d => d.LibrosIsbnNavigation)
                .WithMany(p => p.AutoresHasLibros)
                .HasForeignKey(d => d.LibrosIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autores_has_libros_Libros");
        }
    }
}
