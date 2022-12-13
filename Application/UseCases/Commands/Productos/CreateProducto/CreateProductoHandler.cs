using Domain.Model.Productos;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Productos.CreateProducto
{
    internal class CreateProductoHandler : IRequestHandler<CreateProductoCommand, Guid>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductoHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            Producto obj = new Producto(request.NombreProducto, request.Precio, request.Stock);

            await _productoRepository.CreateAsync(obj);
 
            await _unitOfWork.Commit();

            return obj.Id;
        }
    }
}
