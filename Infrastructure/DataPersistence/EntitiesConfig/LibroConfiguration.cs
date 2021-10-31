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
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> entity)
        {
            entity.ToTable("Libros");
            entity.HasKey(e => e.Isbn);

            entity.Property(e => e.Isbn).HasColumnName("ISBN");

            entity.Property(e => e.EditorialesId).HasColumnName("Editoriales_id");

            entity.Property(e => e.NPaginas)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("N_paginas");

            entity.Property(e => e.Sipnosis)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Editoriales)
                .WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libros_Editoriales");
        }
    }
}
