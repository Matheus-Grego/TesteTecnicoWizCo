using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetAllPedidos;

public class GetAllPedidosQuery : IRequest<Result<List<PedidoDTO>>>
{
    public GetAllPedidosQuery()
    {
    }
    public GetAllPedidosQuery(string? status, int? page, int? size)
    {
        Status = status;
        Page = page;
        Size = size;
    }
    public string? Status { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }
}