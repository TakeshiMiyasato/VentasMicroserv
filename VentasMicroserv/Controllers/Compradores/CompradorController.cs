using Application.UseCases.Commands.Compradores.CreateComprador;
using Application.UseCases.Commands.Compradores.DeleteComprador;
using Application.UseCases.Commands.Compradores.UpdateComprador;
using Application.UseCases.Queries.CompradorQueries;
using Azure.Core;
using Domain.Model.Compradores;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VentasMicroserv.Controllers
{

    [Route("api/venta/comprador")]
    [ApiController]
    public class CompradorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompradorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchComprador([FromQuery] string? nombre = "")
        {
            
            var query = new GetListaCompradoresQuery
            {
                NombreComprador = nombre
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("getById")]
        [HttpGet]
        public async Task<IActionResult> Comprador([FromQuery] Guid id)
        {
            var query = new GetCompradorByIdQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComprador([FromBody] CreateCompradorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComprador([FromBody] UpdateCompradorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComprador([FromBody] DeleteCompradorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        } 
    }
}
