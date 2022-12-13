using Domain.Model.Compradores;
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Compradores.CreateComprador
{
    internal class CreateCompradorHandler : IRequestHandler<CreateCompradorCommand, Guid>
    {
        private readonly ICompradorRepository _compradorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompradorHandler(ICompradorRepository compradorRepository, IUnitOfWork unitOfWork)
        {
            _compradorRepository = compradorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCompradorCommand request, CancellationToken cancellationToken)
        {
            Comprador obj = new Comprador(request.Nombre, request.Ubicacion, request.NombreTienda, request.TipoTienda, request.Telefono);
            await _compradorRepository.CreateAsync(obj);
            await _unitOfWork.Commit();
            return obj.Id;
        }
    }
}
