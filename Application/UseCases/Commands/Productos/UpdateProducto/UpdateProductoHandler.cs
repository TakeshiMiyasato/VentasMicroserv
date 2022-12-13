
using Application.UseCases.Commands.Productos.UpdateProducto;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Productos.UpdateProducto
{
    internal class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductoHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.FindByIdAsync(request.ProductoId);

            if (producto == null)
            {
                throw new Exception("Producto no encontrado");

            }

            producto.EditProducto(request.NombreProducto, request.Precio, request.Stock);

            await _productoRepository.UpdateAsync(producto);

            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
