using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetAllPedidos;

public class GetAllPedidosQuery : IRequest<Result<List<PedidoDTO>>>
{
    public GetAllPedidosQuery()
    {
    }
    public GetAllPedidosQuery(string? status, string? page, string? size)
    {
        Status = status;
        Page = page;
        Size = size;
    }
    public string? Status { get; set; }
    public string? Page { get; set; }
    public string? Size { get; set; }
}