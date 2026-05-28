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
        
        int? page = null;

        if (int.TryParse(request.Page, out var parsedPage) && parsedPage > 0)
        {
            page = parsedPage;
        }

        int? size = null;

        if (int.TryParse(request.Size, out var parsedSize) && parsedSize > 0)
        {
            size = parsedSize;
        }


        var result = await _repository.GetAllPedidos(status, page, size);
        var data = result.Select(p => PedidoDTO.FromEntity(p)).ToList();
        return Result<List<PedidoDTO>>.Success(data);
    }
}