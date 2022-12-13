using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.CompradorQueries
{
    public class GetCompradorByIdQuery :IRequest<CompradorDto>
    {
        public Guid Id { get; set; }
        public GetCompradorByIdQuery(Guid id)
        {
            Id = id;
        }

        public GetCompradorByIdQuery() { }
    }
}
