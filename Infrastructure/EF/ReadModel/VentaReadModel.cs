using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class VentaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Total { get; set; } 
        public CompradorReadModel? Comprador { get; set; }
        public Guid? CompradorId { get; set; }
        public ICollection<DetalleVentaReadModel> Detalle { get; set; }
    }
}
