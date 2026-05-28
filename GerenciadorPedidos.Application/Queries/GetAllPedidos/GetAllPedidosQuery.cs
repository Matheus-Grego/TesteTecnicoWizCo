using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using MediatR;

namespace GerenciadorPedidos.Application.Queries.GetAllPedidos;

public class GetAllPedidosQuery : IRequest<Result<List<PedidoDTO>>>
{
    public string Status { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}