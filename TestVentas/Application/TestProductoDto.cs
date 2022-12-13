using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVentas.Application
{
    public class TestProductoDto
    {
        [Fact]
        public void ProductoDtoCreation_Should_Correct()
        {
            var productoId = Guid.NewGuid();
            var nombre = "Nuka cola 1Ltrs";
            var precio = 10;
            var stock = 20;


            ProductoDto obj = new ProductoDto();


            obj.ProductoId = productoId;
            obj.Nombre = nombre;
            obj.Precio = precio;
            obj.Stock = stock;


            Assert.Equal(productoId, obj.ProductoId);
            Assert.Equal(nombre, obj.Nombre);
            Assert.Equal(precio, obj.Precio);
            Assert.Equal(stock, obj.Stock);
        }
    }
}
