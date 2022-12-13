using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.ProductoQueries
{
    public class GetProductoByIdQuery : IRequest<ProductoDto>
    {
        public Guid Id { get; set; }
        public GetProductoByIdQuery(Guid id)
        {
            Id = id;
        }
        public GetProductoByIdQuery() { }
    }
}
