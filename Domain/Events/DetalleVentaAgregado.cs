using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record DetalleVentaAgregado : DomainEvent
    {
        public Guid ProductoId { get; }
        public int Cantidad { get; }
        public decimal Precio { get; }

        public DetalleVentaAgregado(Guid productoId, int cantidad, decimal precio) : base(DateTime.Now)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
