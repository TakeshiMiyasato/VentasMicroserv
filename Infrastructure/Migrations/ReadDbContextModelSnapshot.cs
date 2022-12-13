﻿// <auto-generated />
using System;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EF.ReadModel.CompradorReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("compradorId");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombreCompleto");

                    b.Property<string>("NombreTienda")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombreTienda");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("telefono");

                    b.Property<string>("TipoTienda")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("tipoTienda");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ubicacion");

                    b.HasKey("Id");

                    b.ToTable("Comprador", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.DetalleVentaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("detalleVentaId");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<decimal>("Precio")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("precio");

                    b.Property<Guid>("ProductoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productoId");

                    b.Property<decimal>("Subtotal")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("subtotal");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ventaId");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("DetalleVenta", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.ProductoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productoId");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombreProducto");

                    b.Property<decimal>("Precio")
                        .HasMaxLength(250)
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("precio");

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasPrecision(12)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.VentaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ventaId");

                    b.Property<Guid?>("CompradorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("compradorId");

                    b.Property<decimal>("Total")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("CompradorId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.DetalleVentaReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModel.ProductoReadModel", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EF.ReadModel.VentaReadModel", "Venta")
                        .WithMany("Detalle")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.VentaReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.ReadModel.CompradorReadModel", "Comprador")
                        .WithMany()
                        .HasForeignKey("CompradorId");

                    b.Navigation("Comprador");
                });

            modelBuilder.Entity("Infrastructure.EF.ReadModel.VentaReadModel", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
