using GerenciadorPedidos.Domain.Entities;
using GerenciadorPedidos.Domain.Enums;

namespace GerenciadorPedidos.Domain.IRepositories;

public interface IPedidoRepository
{ 
    Task<List<Pedido>> GetAllPedidos(StatusPedidoEnum? status);
    Task<Pedido?> GetPedidoById(Guid id);
    Task InsertPedido(Pedido pedido);
    Task UpdatePedido(Pedido pedido);

    
}