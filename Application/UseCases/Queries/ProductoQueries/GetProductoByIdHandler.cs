using Application.Dto;
using Domain.Model.Productos;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Queries.ProductoQueries
{
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoDto>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger _logger;

        public GetProductoByIdHandler(IProductoRepository productoRepository, ILogger<GetProductoByIdQuery> logger)
        {
            _productoRepository = productoRepository;
            _logger = logger;
        }

        public async Task<ProductoDto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            ProductoDto result = null;

            try
            {
                Producto objProducto = await _productoRepository.FindByIdAsync(request.Id);
                result = new ProductoDto()
                {
                    Nombre = objProducto.NombreProducto,
                    Precio = objProducto.Precio,
                    ProductoId = objProducto.Id,
                    Stock = objProducto.Stock
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Producto");
            }
            return result;
        }
    }
}
