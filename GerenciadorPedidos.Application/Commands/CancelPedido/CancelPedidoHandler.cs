using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Domain.Enums;
using GerenciadorPedidos.Domain.IRepositories;
using MediatR;

namespace GerenciadorPedidos.Application.Commands.CancelPedido;

public class CancelPedidoHandler : IRequestHandler<CancelPedidoCommand, Result>
{
    private readonly IPedidoRepository _repository;

    public CancelPedidoHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result> Handle(CancelPedidoCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetPedidoById(request.PedidoId);
        if (result == null)
            return Result.Failure("Pedido não encontrado");
        
        if(result.Status != StatusPedidoEnum.Novo)
            return Result.Failure("não é possivel cancelar o pedido devido ao seu status");
        
        result.CancelarPedido();
        await _repository.UpdatePedido(result);
        return Result.Success;
    }
}