using GerenciadorPedidos.Application.Common.Result;
using GerenciadorPedidos.Domain.IRepositories;
using MediatR;

namespace GerenciadorPedidos.Application.Commands.DeletePedido;

public class DeletePedidoHandler : IRequestHandler<DeletePedidoCommand, Result>
{
    private readonly IPedidoRepository _repository;

    public DeletePedidoHandler(IPedidoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetPedidoById(request.PedidoId);
        if(result == null)
            return Result.Failure("Pedido não encontrado");
        
        if(result.IsDeleted)
            return Result.Failure("o pedido já esta deletado");
        
        result.Deletar();
        await _repository.UpdatePedido(result);
        return Result.Success;
    }
}