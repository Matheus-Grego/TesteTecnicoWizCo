namespace GerenciadorPedidos.Application.DTOs;

public class InserirItemPedidoDTO
{
    public string ProdutoNome { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}