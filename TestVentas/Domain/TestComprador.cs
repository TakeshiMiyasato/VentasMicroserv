using Domain.Model.Compradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVentas.Domain
{
    public class TestComprador
    {
        [Fact]
        public void CompradorCreation_Should_Correct()
        {
            var nombre = "Robert Perez";
            var ubicacion = "Warnes media calle";
            var nombreTienda = "Hipermaxi";
            var tipoTienda = "SuperMercado";
            var telefono = "75401412";

            Comprador obj = new Comprador(nombre, ubicacion, nombreTienda, tipoTienda, telefono);

            Assert.NotNull(obj.NombreCompleto);
            Assert.NotNull(obj.Ubicacion);
            Assert.Equal(nombre, obj.NombreCompleto);
            Assert.Equal(tipoTienda, obj.TipoTienda);
            Assert.Equal(ubicacion, obj.Ubicacion);
        }
    }
}
