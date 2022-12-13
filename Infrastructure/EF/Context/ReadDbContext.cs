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
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<VentaReadModel> Ventas { get; set; }
        public virtual DbSet<CompradorReadModel> Compradores { get; set; }
        public virtual DbSet<ProductoReadModel> Productos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<ProductoReadModel>(new ProductoReadConfig());
            modelBuilder.ApplyConfiguration<CompradorReadModel>(new CompradorReadConfig());
            modelBuilder.ApplyConfiguration<VentaReadModel>(new VentaReadConfig());
            modelBuilder.ApplyConfiguration<DetalleVentaReadModel>(new DetalleVentaReadConfig());
        }
    }
}