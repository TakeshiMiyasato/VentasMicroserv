using Application.Dto;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.ProductoQueries
{
    public class GetListaProductosQuery : IRequest<IEnumerable<ProductoDto>>
    {
        public string NombreSearchTerm { get; set; }
    }
}
