using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Ventas.RegistrarVenta
{
    public record RegistrarVentaCommand : IRequest<Guid>
    {
        public Guid? CompradorId { get; set; }
        public ICollection<DetalleVentaDto> Detalle { get; set; }
        public RegistrarVentaCommand(Guid compradorId, ICollection<DetalleVentaDto> detalle)
        {
            CompradorId = compradorId;
            Detalle = detalle;
        }

        public RegistrarVentaCommand()
        {
            Detalle = new List<DetalleVentaDto>();
        }
    }
}
