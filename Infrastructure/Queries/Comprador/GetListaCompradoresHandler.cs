using Application.Dto;
using Application.UseCases.Queries.CompradorQueries;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Comprador
{
    internal class GetListaCompradoresHandler : IRequestHandler<GetListaCompradoresQuery, IEnumerable<CompradorDto>>
    {
        private readonly DbSet<CompradorReadModel> compradores;

        public GetListaCompradoresHandler(ReadDbContext dbContext)
        {
            compradores = dbContext.Compradores;
        }

        public async Task<IEnumerable<CompradorDto>> Handle(GetListaCompradoresQuery request, CancellationToken cancellationToken)
        {
            var query = compradores.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(request.NombreComprador))
            {
                query = query.Where(x => x.NombreCompleto.ToLower().Contains(request.NombreComprador.ToLower()));
            }

            var lista = await query.Select(x => new CompradorDto
            {
                CompradorId = x.Id,
                Nombre = x.NombreCompleto,
                Ubicacion = x.Ubicacion,
                Telefono = x.Telefono,
                TipoTienda = x.TipoTienda,
                NombreTienda = x.NombreTienda
            }).ToListAsync();

            return lista;
        }
    }
}
