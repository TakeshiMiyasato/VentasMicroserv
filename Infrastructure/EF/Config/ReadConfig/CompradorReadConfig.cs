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
    internal class CompradorReadConfig : IEntityTypeConfiguration<CompradorReadModel>
    {
        public void Configure(EntityTypeBuilder<CompradorReadModel> builder)
        {
            builder.ToTable("Comprador");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("compradorId");

            builder.Property(x => x.NombreCompleto)
                .HasColumnName("nombreCompleto")
                .HasMaxLength(250);

            builder.Property(x => x.Ubicacion)
                .HasColumnName("ubicacion")
                .HasMaxLength(250);

            builder.Property(x => x.NombreTienda)
                .HasColumnName("nombreTienda")
                .HasMaxLength(250);

            builder.Property(x => x.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(250);
        }
    }
}
