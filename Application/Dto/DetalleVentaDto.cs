using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class DetalleVentaDto
    {
        public Guid ProductoId { set; get; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string ProductoNombre { get; set; }
    }
}
