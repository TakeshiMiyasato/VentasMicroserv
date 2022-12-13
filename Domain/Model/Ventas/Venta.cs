using Domain.Events;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Ventas
{
    public class Venta : AggregateRoot
    {
        private readonly ICollection<DetalleVenta> _detalle;
        public decimal Total { get; private set; }

        public Guid? CompradorId { get; set; }
        public IEnumerable<DetalleVenta> DetalleVenta
        {
            get { return _detalle; }
        }

        internal Venta()
        {
            Id = Guid.NewGuid();
            _detalle = new List<DetalleVenta>();
        }

        internal Venta(Guid compradorId)
        {
            Id = Guid.NewGuid();
            _detalle = new List<DetalleVenta>();
            CompradorId = compradorId;
        }

        public void AgregarDetalleVenta(Guid productoId, int cantidad, decimal precio)
        {
            var detalle = new DetalleVenta(productoId, cantidad, precio);
            _detalle.Add(detalle);
            Total += detalle.SubTotal;

            var evento = new DetalleVentaAgregado(productoId, cantidad, precio);
            AddDomainEvent(evento);
        }
    }
}
