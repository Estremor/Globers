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
    public class AutoresConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> entity)
        {
            entity.ToTable("Autores");

            entity.Property(e => e.Apellido)
                 .IsRequired()
                 .HasMaxLength(45)
                 .IsUnicode(false);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
