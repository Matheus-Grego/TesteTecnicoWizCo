using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using GerenciadorPedidos.Domain.Enums;
using GerenciadorPedidos.Domain.IRepositories;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetAllPedidos;

public class GetAllPedidosHandler : IRequestHandler<GetAllPedidosQuery, Result<List<PedidoDTO>>>
{
    private readonly IPedidoRepository _repository;
    public GetAllPedidosHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<PedidoDTO>>> Handle(GetAllPedidosQuery request, CancellationToken cancellationToken)
    {
        StatusPedidoEnum? status = null;

        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            switch (request.Status.ToLower())
            {
                case "novo":
                    status = StatusPedidoEnum.Novo;
                    break;

                case "pago":
                    status = StatusPedidoEnum.Pago;
                    break;

                case "cancelado":
                    status = StatusPedidoEnum.Cancelado;
                    break;

                default:
                    break;
            }
        }

        var result = await _repository.GetAllPedidos(status);
        var data = result.Select(p => PedidoDTO.FromEntity(p)).ToList();
        return Result<List<PedidoDTO>>.Success(data);
    }
}