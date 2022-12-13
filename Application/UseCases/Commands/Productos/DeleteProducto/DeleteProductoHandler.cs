using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareKernel.Core;
using System.Collections;
using Domain.Repositories;

namespace Application.UseCases.DeleteProducto
{
    public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductoHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var obj = await _productoRepository.FindByIdAsync(request.ProductoId);
            if (obj == null)
            {
                throw new Exception("Producto no encontrado");
            }
            await _productoRepository.RemoveAsync(obj);
            await _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
