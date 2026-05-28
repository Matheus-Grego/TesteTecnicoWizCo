using GerenciadorPedidos.Domain.Enums;

namespace GerenciadorPedidos.Domain.Entities;

public class Pedido : BaseEntity
{
    public Pedido(string clienteNome, decimal valorTotal) : base()
    {
        ClienteNome = clienteNome;
        Status = StatusPedidoEnum.Novo;
        ValorTotal = valorTotal;
    }
    public string ClienteNome { get; private set; }
    public StatusPedidoEnum Status { get; private set; } 
    public decimal ValorTotal { get; private set; }
    public ICollection<ItemPedido> Itens { get; private set; }

    
    public void CancelarPedido()
    {
        Status = StatusPedidoEnum.Cancelado;
    }
    
    public void PagarPedido()
    {
        Status = StatusPedidoEnum.Pago;
    }
    
    
}