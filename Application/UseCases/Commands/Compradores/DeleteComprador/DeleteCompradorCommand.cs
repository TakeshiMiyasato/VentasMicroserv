using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Compradores.DeleteComprador
{
    public class DeleteCompradorCommand : IRequest
    {
        public Guid CompradorId { get; set; }
    }
}
