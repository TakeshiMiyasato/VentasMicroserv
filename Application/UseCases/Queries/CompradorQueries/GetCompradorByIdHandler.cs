using Application.Dto;
using Domain.Model.Compradores;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.CompradorQueries
{
    public class GetCompradorByIdHandler : IRequestHandler<GetCompradorByIdQuery, CompradorDto>
    {
        private readonly ICompradorRepository _compradorRepository;
        private readonly ILogger _logger;

        public GetCompradorByIdHandler(ICompradorRepository compradorRepository, ILogger<GetCompradorByIdQuery> logger)
        {
            _compradorRepository = compradorRepository;
            _logger = logger;
        }

        public async Task<CompradorDto> Handle(GetCompradorByIdQuery request, CancellationToken cancellationToken)
        {
            CompradorDto result = null;
            try
            {
                Comprador objComprador = await _compradorRepository.FindByIdAsync(request.Id);
                result = new CompradorDto()
                {
                    CompradorId = objComprador.Id,
                    Nombre = objComprador.NombreCompleto,
                    NombreTienda = objComprador.NombreTienda,
                    Telefono = objComprador.Telefono,
                    TipoTienda = objComprador.TipoTienda,
                    Ubicacion = objComprador.Ubicacion
                };
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener COmprador");
            }

            return result;
        }
    }
}
