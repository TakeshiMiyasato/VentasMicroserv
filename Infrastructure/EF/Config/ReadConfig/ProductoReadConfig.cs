using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class ProductoReadConfig : IEntityTypeConfiguration<ProductoReadModel>
    {
        public void Configure(EntityTypeBuilder<ProductoReadModel> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("productoId");

            builder.Property(x => x.NombreProducto)
                .HasColumnName("nombreProducto")
                .HasMaxLength(250);

            builder.Property(x => x.Stock)
                .HasColumnName("stock")
                .HasPrecision(12)
                .HasDefaultValue(0);

            builder.Property(x => x.Precio)
                .HasColumnName("precio")
                .HasPrecision(14, 2);
        }
    }
}
