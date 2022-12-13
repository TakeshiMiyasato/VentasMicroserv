using Application.Dto;
using Application.UseCases.Queries.Venta;
using Infrastructure.EF.Context;
using Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Venta
{
    internal class GetListaVentasHandler : IRequestHandler<GetListaVentasQuery, IEnumerable<VentaDto>>
    {
        private readonly DbSet<VentaReadModel> ventas;

        public GetListaVentasHandler(ReadDbContext dbContext)
        {
            ventas = dbContext.Ventas;
        }

        public async Task<IEnumerable<VentaDto>> Handle(GetListaVentasQuery request, CancellationToken cancellationToken)
        {
            var ventaList = await ventas
                .AsNoTracking()
                .Include(x => x.Detalle)
                .ThenInclude(x => x.Producto)
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
