using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Infra.Data.Mapping
{
    internal class RotaMap : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("ROTA");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Origin)
                .IsRequired()
                .HasColumnName("Origin")
                .HasColumnType("VARCHAR(140)");

            builder.Property(prop => prop.Destination)
               .IsRequired()
               .HasColumnName("Destination")
               .HasColumnType("varchar(140)");

            builder.Property(prop => prop.Cost)
                .IsRequired()
                .HasColumnName("Cost")
                .HasColumnType("Decimal(12,2)");

            
        }
    }
}
