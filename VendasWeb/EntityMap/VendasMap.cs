using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.EntityMap
{
    public class VendasMap : IEntityTypeConfiguration<RegistroVendas>
    {
        public void Configure(EntityTypeBuilder<RegistroVendas> builder)
        {
           



            builder.Property(s => s.Data)
                .IsRequired()
                .HasColumnName("Data")
                .HasColumnType("date");

            builder.Property(s => s.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade")
                .HasColumnType("double");

            builder.Property(s => s.Status)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(s => s.Vendedor)
                .WithMany(s => s.RegistroVendas)
                .HasForeignKey(s => s.VendedorId);


            builder.ToTable("Vendas");
        }
    }
}
