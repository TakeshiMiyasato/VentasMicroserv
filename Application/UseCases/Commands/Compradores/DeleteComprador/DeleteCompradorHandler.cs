
using Domain.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Compradores.DeleteComprador
{
    public class DeleteCompradorHandler : IRequestHandler<DeleteCompradorCommand>
    {
        private readonly ICompradorRepository _compradorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompradorHandler(ICompradorRepository compradorRepository, IUnitOfWork unitOfWork)
        {
            _compradorRepository = compradorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCompradorCommand request, CancellationToken cancellationToken)
        {
            var obj = await _compradorRepository.FindByIdAsync(request.CompradorId);
            if(obj == null)
            {
                throw new Exception("Comprador no encontrado");
            }
            await _compradorRepository.RemoveAsync(obj);
            await _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
