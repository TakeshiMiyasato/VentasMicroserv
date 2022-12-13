using Domain.Model.Ventas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class DetalleVentaWriteConfig : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");
            builder.Property(x => x.Id)
                .HasColumnName("detalleVentaId");

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
                cantidadValue => cantidadValue.Value,
                intValue => new CantidadValue(intValue)
            );

            builder.Property(x => x.Cantidad)
                .HasConversion(cantidadConverter)
                .HasColumnName("cantidad");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                decimalValue => new PrecioValue(decimalValue)
            );

            builder.Property(x => x.PrecioVenta)
                .HasConversion(precioConverter)
                .HasColumnName("precio");

            builder.Property(x => x.SubTotal)
                .HasConversion(precioConverter)
                .HasColumnName("subtotal");


            builder.Property(x => x.ProductoId)
                .HasColumnName("productoId");


            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
