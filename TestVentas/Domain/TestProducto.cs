using Domain.Model.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVentas.Domain
{
    public class TestProducto
    {
        [Fact]
        public void ProductoCreation_Should_Correct()
        {
            var nombre = "Nuka Cola 1 Litro";
            var precio = 10;
            var stock = 20;


            Producto obj = new Producto(nombre, precio, stock);

            Assert.NotNull(obj.NombreProducto);
            Assert.NotNull(obj.Precio);
            Assert.NotNull(obj.Stock);

            Assert.Equal(nombre, obj.NombreProducto);
            Assert.Equal(precio, obj.Precio, 1);
            Assert.Equal(stock, obj.Stock.Value);
        }
    }
}
