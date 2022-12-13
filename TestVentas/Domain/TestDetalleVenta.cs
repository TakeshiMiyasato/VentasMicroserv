using Domain.Model.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVentas.Domain
{
    public class TestDetalleVenta
    {
        [Fact]
        public void DetalleCompraCreation_Should_Correct()
        {
            var productoId = Guid.NewGuid();
            var cantidad = 25;
            var precio = 15;


            DetalleVenta obj = new DetalleVenta(productoId, cantidad, precio);

            Assert.NotNull(obj.Cantidad);
            Assert.NotNull(obj.PrecioVenta);
            Assert.NotNull(obj.SubTotal);

            Assert.Equal(productoId, obj.ProductoId);
            Assert.Equal(cantidad, obj.Cantidad.Value);
            Assert.Equal(precio, obj.PrecioVenta);
        }
    }
}
