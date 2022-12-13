using Application.Dto;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using Application.UseCases.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Compras.UseCases.Queries.Venta;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Queries.Venta
{
    internal class GetListaVentasByCompradorIdHandler : IRequestHandler<GetListaVentasByCompradorIdQuery, IEnumerable<VentaDto>>
    {
        private readonly DbSet<VentaReadModel> ventas;

        public GetListaVentasByCompradorIdHandler(ReadDbContext dbContext)
        {
            ventas = dbContext.Ventas;
        }

        public async Task<IEnumerable<VentaDto>> Handle(GetListaVentasByCompradorIdQuery request, CancellationToken cancellationToken)
        {
            var ventaList = await ventas
                .AsNoTracking()
                .Include(x => x.Detalle)
                .ThenInclude(x => x.Producto)
                .Where(x => x.CompradorId.Equals(request.CompradorId))
                .ToListAsync();

            var result = new List<VentaDto>();

            foreach (var objVenta in ventaList)
            {
                var ventaDto = new VentaDto()
                {
                    Id = objVenta.Id,
                    NroPedido = objVenta.Id.ToString(),
                    Total = objVenta.Total
                };

                foreach (var item in objVenta.Detalle)
                {
                    ventaDto.Detalle.Add(new DetalleVentaDto()
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        Precio = item.Precio,
                        ProductoNombre = item.Producto.NombreProducto.ToString(),
                    });
                }

                result.Add(ventaDto);
            }

            return result;
        }
    }
}
