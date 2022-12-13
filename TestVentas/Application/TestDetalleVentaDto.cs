using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVentas.Application
{
    public class TestDetalleVentaDto
    {
        [Fact]
        public void DetalleVentaDtoCreation_Should_Correct()
        {
            var productoId = Guid.NewGuid();
            var cantidad = 10;
            var precio = 20;

            DetalleVentaDto obj = new DetalleVentaDto();

            Assert.Equal(Guid.Empty, obj.ProductoId);
            Assert.Equal(0, obj.Cantidad);
            Assert.Equal(0, obj.Precio);

            obj.ProductoId = productoId;
            obj.Cantidad = cantidad;
            obj.Precio = precio;

            Assert.Equal(productoId, obj.ProductoId);
            Assert.Equal(cantidad, obj.Cantidad);
            Assert.Equal(precio, obj.Precio);
        }
    }
}
