using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Ventas
{
    public class DetalleVenta : Entity
    {
        public Guid ProductoId { get; private set; }
        public CantidadValue Cantidad { get; private set; }
        public PrecioValue PrecioVenta { get; private set; }
        public PrecioValue SubTotal { get; set; }

        public DetalleVenta(Guid productoId, int cantidad, decimal precioVenta)
        {
            if(productoId == Guid.Empty)
            {
                throw new ArgumentException("El producto no puede ser vacio");
            }
            Id = Guid.NewGuid();
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioVenta = precioVenta;
            SubTotal = cantidad * precioVenta;
        }

        private DetalleVenta() { }
    }
}
