using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Queries.Venta
{
    public class GetListaVentasByCompradorIdQuery : IRequest<IEnumerable<VentaDto>>
    {
        public Guid CompradorId { get; set; }
    }
}
