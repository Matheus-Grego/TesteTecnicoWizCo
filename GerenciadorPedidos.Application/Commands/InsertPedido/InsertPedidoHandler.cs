using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Domain.Entities;
using GerenciadorPedidos.Domain.IRepositories;
using MediatR;

namespace GerenciadorPedidos.Application.Commands.InsertPedido;

public class InsertPedidoHandler : IRequestHandler<InsertPedidoCommand, Result>
{
    private readonly IPedidoRepository _repository;

    public InsertPedidoHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result> Handle(InsertPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = new Pedido(request.ClienteNome, request.ItemsPedido.Sum(x => x.ValorUnitario));
        await _repository.InsertPedido(pedido);
        return Result.Success;
    }
}