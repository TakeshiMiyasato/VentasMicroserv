
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Compradores.UpdateComprador
{
    internal class UpdateCompradorHandler : IRequestHandler<UpdateCompradorCommand>
    {
        private readonly ICompradorRepository _compradorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompradorHandler(ICompradorRepository compradorRepository, IUnitOfWork unitOfWork)
        {
            _compradorRepository = compradorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCompradorCommand request, CancellationToken cancellationToken)
        {
            var comprador = await _compradorRepository.FindByIdAsync(request.CompradorId);

            if(comprador == null)
            {
                throw new Exception("Comprador no encontrado");
            }
            comprador.EditComprador(request.Nombre, request.Ubicacion, request.NombreTienda, request.TipoTienda, request.Telefono);
            await _compradorRepository.UpdateAsync(comprador);
            await _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
