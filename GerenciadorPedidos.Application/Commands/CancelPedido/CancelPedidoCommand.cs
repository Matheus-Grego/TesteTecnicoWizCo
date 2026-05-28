using GerenciadorPedidos.Application.Common.Result;
using MediatR;

namespace GerenciadorPedidos.Application.Commands.CancelPedido;

public class CancelPedidoCommand : IRequest<Result>
{
    public CancelPedidoCommand(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }
    public Guid PedidoId { get; private set; }
}