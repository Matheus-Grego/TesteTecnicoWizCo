using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedidos.API.Controllers;

[ApiController]
[Route("pedidos")]
public class PedidosController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllPedidos()
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult GetPedidoById(Guid id)
    {
        return NoContent();
    }

    [HttpPost]
    public IActionResult InsertPedido()
    {
        return CreatedAtAction(nameof(GetPedidoById), new { id = Guid.Empty }, null);
    }

    [HttpPut("{id}")]
    public IActionResult CancelPedido(Guid id)
    {
        return NoContent();
    }
}