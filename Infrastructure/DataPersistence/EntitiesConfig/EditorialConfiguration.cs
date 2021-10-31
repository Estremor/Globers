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
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> entity)
        {
            entity.ToTable("Editoriales");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Sede)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
