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
    internal class VentaReadConfig : IEntityTypeConfiguration<VentaReadModel>
    {
        public void Configure(EntityTypeBuilder<VentaReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ventaId");

            builder.Property(x => x.Total)
                .HasColumnName("total")
                .HasPrecision(14, 2)
                .IsRequired();

            builder.Property(x => x.CompradorId)
                .HasColumnName("compradorId");

            builder.HasOne(x => x.Comprador)
                .WithMany()
                .HasForeignKey(x => x.CompradorId);

            builder.HasMany(x => x.Detalle)
                .WithOne(x => x.Venta)
                .HasForeignKey(x => x.VentaId);
        }
    }
}
