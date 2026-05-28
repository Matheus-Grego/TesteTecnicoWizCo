using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using GerenciadorPedidos.Domain.IRepositories;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetPedidoById;

public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdQuery, Result<PedidoDTO?>>
{
    private readonly IPedidoRepository _repository;
    public GetPedidoByIdHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<PedidoDTO?>> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetPedidoById(request.PedidoId);
        if (result == null)
            return Result<PedidoDTO>.Failure("Pedido não encontrado");
        var data = PedidoDTO.FromEntity(result);
        return Result<PedidoDTO>.Success(data);
    }
}