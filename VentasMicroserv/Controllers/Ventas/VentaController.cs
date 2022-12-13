using Application.Compras.UseCases.Queries.Venta;
using Application.UseCases.Commands.Ventas.RegistrarVenta;
using Application.UseCases.Queries.Venta;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VentasMicroserv.Controllers.Ventas
{
    [Route("api/venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetVentasByCompradorId([FromQuery] Guid? compradorId)
        {
            var query = new GetListaVentasByCompradorIdQuery
            {
                CompradorId = (Guid)compradorId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllVentas([FromQuery] Guid? compradorId)
        {
            var query = new GetListaVentasQuery { };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenta([FromBody] RegistrarVentaCommand command)
        {
                var result = await _mediator.Send(command);
                return Ok(result);
        }
        
    }
}
