using GerenciadorPedidos.Domain.Entities;

namespace GerenciadorPedidos.Application.DTOs;

public class PedidoDTO
{
    public PedidoDTO(Guid id, string clienteNome, string status, decimal valorTotal, DateTime dataCriacao)
    {
        Id = id;
        ClienteNome = clienteNome;
        Status = status;
        ValorTotal = valorTotal;
        DataCriacao = dataCriacao;
    }

    public Guid Id { get; private set; }
    public string ClienteNome { get; private set; }
    public string Status { get; private set; } 
    public decimal ValorTotal { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public static PedidoDTO FromEntity(Pedido pedido) =>
        new PedidoDTO(
            pedido.Id,
            pedido.ClienteNome,
            pedido.Status.ToString(),
            pedido.ValorTotal,
            pedido.DataCriacao);
}