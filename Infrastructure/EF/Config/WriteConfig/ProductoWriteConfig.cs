using Domain.Model.Productos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class ProductoWriteConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.Property(x => x.Id).HasColumnName("productoId");

            var nombreConverter = new ValueConverter<ProductNameValue, string>(
                personNameValue => personNameValue.Name,
                stringValue => new ProductNameValue(stringValue)
            );

            builder.Property(x => x.NombreProducto)
                .HasConversion(nombreConverter)
                .HasColumnName("nombreProducto");


            var cantidadConverter = new ValueConverter<CantidadValue, int>(
                cantidadValue => cantidadValue.Value,
                intValue => new CantidadValue(intValue)
            );

            builder.Property(x => x.Stock)
                .HasConversion(cantidadConverter)
                .HasColumnName("stock");


            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                decimalValue => new PrecioValue(decimalValue)
            );

            builder.Property(x => x.Precio)
                .HasConversion(precioConverter)
                .HasColumnName("precio");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
