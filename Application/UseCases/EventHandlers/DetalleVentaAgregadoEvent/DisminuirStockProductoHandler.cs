using Domain.Events;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.EventHandlers.DetalleVentaAgregadoEvent
{
    internal class DisminuirStockProductoHandler : INotificationHandler<DetalleVentaAgregado>
    {
        private readonly IProductoRepository _productoRepository;

        public DisminuirStockProductoHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task Handle(DetalleVentaAgregado notification, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.FindByIdAsync(notification.ProductoId);
            producto.DisminuirStock(notification.Cantidad);
            await _productoRepository.UpdateAsync(producto);
        }
    }
}
