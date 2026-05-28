using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Application.DTOs;
using MediatR;

namespace GerenciadorPedidos.Application.Commands.InsertPedido;

public class InsertPedidoCommand : IRequest<Result>
{
    public string ClienteNome { get; set; }
    public List<InserirItemPedidoDTO> ItemsPedido { get; set; }
}