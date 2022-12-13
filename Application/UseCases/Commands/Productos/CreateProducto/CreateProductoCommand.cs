using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Productos.CreateProducto
{
    public class CreateProductoCommand : IRequest<Guid>
    {
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }


    }
}
