using GerenciadorPedidos.Application.Commands.InsertPedido;
using GerenciadorPedidos.Application.Queries.GetAllPedidos;
using GerenciadorPedidos.Application.Queries.GetPedidoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedidos.API.Controllers;

[ApiController]
[Route("pedidos")]
public class PedidosController : ControllerBase
{
    
    private readonly IMediator _mediator;
    public PedidosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllPedidos()
    {
        var result = await _mediator.Send(new GetAllPedidosQuery());
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPedidoById(Guid id)
    {
        var result = await _mediator.Send(new GetPedidoByIdQuery(id));
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> InsertPedido(InsertPedidoCommand command)
    {
        var result = await _mediator.Send(command);
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        return CreatedAtAction(nameof(GetPedidoById), new { id = Guid.Empty }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CancelPedido(Guid id)
    {
        var result = await _mediator.Send(new GetPedidoByIdQuery(id));
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        return NoContent();
    }
}