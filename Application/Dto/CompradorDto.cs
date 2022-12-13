using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CompradorDto
    {
        public Guid CompradorId { get; set; }

        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

        public string NombreTienda { get; set; }

        public string TipoTienda { get; set; }

        public string Telefono { get; set; }
    }
}
