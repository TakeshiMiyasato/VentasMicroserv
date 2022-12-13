using Domain.Factories;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Ventas.RegistrarVenta
{
    internal class RegistrarVentaHandler : IRequestHandler<RegistrarVentaCommand, Guid>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IVentaFactory _ventaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarVentaHandler(IVentaRepository ventaRepository, IVentaFactory ventaFactory, IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _ventaFactory = ventaFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegistrarVentaCommand request, CancellationToken cancellationToken)
        {
            var venta = _ventaFactory.CrearVenta(request.CompradorId);
            foreach(var item in request.Detalle)
            {
                venta.AgregarDetalleVenta(item.ProductoId, item.Cantidad, item.Precio);
            }
            await _ventaRepository.CreateAsync(venta);
            await _unitOfWork.Commit();
            return venta.Id;
        }
    }
}
