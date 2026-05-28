using GerenciadorPedidos.Domain.Entities;

namespace GerenciadorPedidos.Application.DTOs;

public class ItemPedidoDTO
{
    public ItemPedidoDTO(Guid id, string produtoNome, int quantidade, decimal valorUnitario)
    {
        Id = id;
        ProdutoNome = produtoNome;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public Guid Id { get; private set; }
    public string ProdutoNome { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }

    public static ItemPedidoDTO FromEntity(ItemPedido item) =>
        new ItemPedidoDTO(
            item.Id,
            item.ProdutoNome,
            item.Quantidade,
            item.ValorUnitario
        );
}