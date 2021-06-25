using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.EntityMap
{
    public class DepartamentosMap : IEntityTypeConfiguration<Departamentos>
    {
        public void Configure(EntityTypeBuilder<Departamentos> builder)
        {
            

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(30)");

            builder.ToTable("Departamentos");
        }
    }
}
