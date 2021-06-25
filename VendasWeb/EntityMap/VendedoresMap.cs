using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.EntityMap
{
    public class VendedoresMap : IEntityTypeConfiguration<Vendedor>
    {
    

        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            

            builder.Property(s => s.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar(30)");

            builder.Property(s => s.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("varchar(20)");

            builder.Property(s => s.Aniversario)
                    .IsRequired()
                    .HasColumnName("DataAniversario")
                    .HasColumnType("date");

            builder.HasOne(s => s.Departamentos)
                    .WithMany(s => s.Vendedores)
                    .HasForeignKey(s => s.DepartamentosId);

            builder.ToTable("Vendedor");
        }
    }
}
