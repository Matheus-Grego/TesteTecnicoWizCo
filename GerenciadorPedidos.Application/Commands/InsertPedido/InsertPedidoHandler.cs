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
        var valorTotal = request.ItemsPedido
            .Sum(x => x.ValorUnitario * x.Quantidade);

        var pedido = new Pedido(request.ClienteNome, valorTotal);
        await _repository.InsertPedido(pedido);
        return Result.Success;
    }
}