using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class DetalleVentaReadConfig : IEntityTypeConfiguration<DetalleVentaReadModel>
    {
        public void Configure(EntityTypeBuilder<DetalleVentaReadModel> builder)
        {
            builder.ToTable("DetalleVenta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("detalleVentaId");

            builder.Property(x => x.Cantidad)
                .HasColumnName("cantidad");

            builder.Property(x => x.Precio)
                .HasPrecision(14, 2)
                .HasColumnName("precio");

            builder.Property(x => x.Subtotal)
                .HasPrecision(14, 2)
                .HasColumnName("subtotal");

            builder.Property(x => x.VentaId)
                .HasColumnName("ventaId");

            builder.Property(x => x.ProductoId)
                .HasColumnName("productoId");

            builder.HasOne(x => x.Producto)
                .WithMany()
                .HasForeignKey(x => x.ProductoId);
        }
    }
}
