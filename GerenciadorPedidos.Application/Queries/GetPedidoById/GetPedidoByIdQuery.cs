using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetPedidoById;

public class GetPedidoByIdQuery : IRequest<Result<PedidoDTO?>>
{
    public GetPedidoByIdQuery(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }
    public Guid PedidoId { get; private set; }
}