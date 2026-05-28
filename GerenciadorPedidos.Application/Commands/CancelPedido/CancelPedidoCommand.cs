namespace GerenciadorPedidos.Application.Commands.CancelPedido;

public class CancelPedidoCommand
{
    public CancelPedidoCommand(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }
    public Guid PedidoId { get; private set; }
}