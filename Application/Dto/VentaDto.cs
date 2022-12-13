using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class VentaDto
    {
        public Guid Id { get; set; }
        public string NroPedido { get; set; }
        public decimal Total { get; set; }
        public ICollection<DetalleVentaDto> Detalle { get; set; }

        public VentaDto()
        {
            Detalle = new List<DetalleVentaDto>();
        }
    }
}
