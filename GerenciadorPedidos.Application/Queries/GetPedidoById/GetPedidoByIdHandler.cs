using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetPedidoById;

public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdQuery, Result<PedidoDTO>>
{
    public Task<Result<PedidoDTO>> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}