using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.CompradorQueries
{
    public class GetListaCompradoresQuery : IRequest<IEnumerable<CompradorDto>>
    {
        public string NombreComprador { get; set; }
    }
}
