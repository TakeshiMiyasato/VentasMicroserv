using Domain.Model.Compradores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedKernel.ValueObjects;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class CompradorWriteConfig : IEntityTypeConfiguration<Comprador>
    {
        public void Configure(EntityTypeBuilder<Comprador> builder)
        {
            builder.ToTable("Comprador");

            builder.Property(x => x.Id).HasColumnName("compradorId");


            var nombreConverter = new ValueConverter<PersonNameValue, string>(
                personNameValue => personNameValue.Name,
                stringValue => new PersonNameValue(stringValue)
            );
            var ubicacionConverter = new ValueConverter<UbicacionValue, string>(
                ubicacionValue => ubicacionValue.Name,
                stringValue => new UbicacionValue(stringValue)
            );
            var nombreTiendaConverter = new ValueConverter<PersonNameValue, string>(
                nombreTiendaValue => nombreTiendaValue.Name,
                stringValue => new PersonNameValue(stringValue)
            );
            var tipoTiendaConverter = new ValueConverter<PersonNameValue, string>(
                tipoTiendaValue => tipoTiendaValue.Name,
                stringValue => new PersonNameValue(stringValue)
            );
            var telefonoConverter = new ValueConverter<TelefonoValue, string>(
                telefonoValue => telefonoValue.Telefono,
                stringValue => new TelefonoValue(stringValue)
            );

            builder.Property(x => x.NombreCompleto)
                .HasConversion(nombreConverter)
                .HasColumnName("nombreCompleto");

            builder.Property(x => x.Ubicacion)
                .HasConversion(ubicacionConverter)
                .HasColumnName("ubicacion");

            builder.Property(x => x.NombreTienda)
                .HasConversion(nombreTiendaConverter)
                .HasColumnName("nombreTienda");

            builder.Property(x => x.TipoTienda)
                .HasConversion(tipoTiendaConverter)
                .HasColumnName("tipoTienda");

            builder.Property(x => x.Telefono)
                .HasConversion(telefonoConverter)
                .HasColumnName("telefono");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
