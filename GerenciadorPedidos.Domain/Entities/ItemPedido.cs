namespace GerenciadorPedidos.Domain.Entities;

public class ItemPedido : BaseEntity
{
    public ItemPedido(Guid pedidoId, string produtoNome,int quantidade, decimal valorUnitario) : base()
    {
        PedidoId = pedidoId;
        ProdutoNome = produtoNome;
        Quantidade =  quantidade;
        ValorUnitario = valorUnitario;
    }
    public Guid PedidoId { get; private set; } 
    public string ProdutoNome { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    
    public virtual Pedido Pedido { get; set; }
}