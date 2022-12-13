using Domain.Model.Compradores;
using Domain.Model.Productos;
using Domain.Model.Ventas;
using Infrastructure.EF.Config.ReadConfig;
using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<Comprador> Compradores { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompradorWriteConfig());
            modelBuilder.ApplyConfiguration(new VentaWriteConfig());
            modelBuilder.ApplyConfiguration(new DetalleVentaWriteConfig());
            modelBuilder.ApplyConfiguration(new ProductoWriteConfig());
        }
    }
}
