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
    public Guid PedidoId { get; set; } 
    public string ProdutoNome { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
   
    public virtual Pedido Pedido { get; set; }
}