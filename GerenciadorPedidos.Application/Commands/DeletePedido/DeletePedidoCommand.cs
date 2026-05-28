using GerenciadorPedidos.Application.Common.Result;
using MediatR;

namespace GerenciadorPedidos.Application.Commands.DeletePedido;

public class DeletePedidoCommand : IRequest<Result>
{
    public DeletePedidoCommand(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }
    public Guid PedidoId { get; set; }
}