using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestVentas.Application
{
    public class TestCompradorDto
    {
        [Fact]
        public void CompradorDtoCreation_Should_Correct()
        {
            var compradorId = Guid.NewGuid();
            var nombre = "Takeshi Miyasato Alvarez";
            var ubicacion = "3er anillo";

            CompradorDto obj = new CompradorDto();

            obj.CompradorId = compradorId;
            obj.Nombre = nombre;
            obj.Ubicacion = ubicacion;

            Assert.Equal(compradorId, obj.CompradorId);
            Assert.Equal(nombre, obj.Nombre);
            Assert.Equal(ubicacion, obj.Ubicacion);
        }
    }
}
