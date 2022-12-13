
using Application.Compras.UseCases.Commands.Productos.UpdateProducto;
using Application.UseCases.Commands.Productos.CreateProducto;
using Application.UseCases.Commands.Productos.UpdateProducto;
using Application.UseCases.DeleteProducto;
using Application.UseCases.Queries.ProductoQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Compras.Controllers
{
    [Route("api/venta/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchProducto([FromQuery] string? nombre = "")
        {
            var query = new GetListaProductosQuery
            {
                NombreSearchTerm = nombre
            };
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [Route("getById")]
        [HttpGet]
        public async Task<IActionResult> Producto([FromQuery] Guid id)
        {
            var query = new GetProductoByIdQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CreateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] UpdateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarProducto([FromBody] DeleteProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
