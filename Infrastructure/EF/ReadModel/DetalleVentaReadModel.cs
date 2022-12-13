using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class DetalleVentaReadModel
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public VentaReadModel Venta { get; set; }
        public Guid VentaId { get; set; }
        public ProductoReadModel Producto { get; set; }
        public Guid ProductoId { get; set; }
    }
}
