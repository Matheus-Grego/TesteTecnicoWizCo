using GerenciadorPedidos.Domain.Entities;

namespace GerenciadorPedidos.Domain.IRepositories;

public interface IPedidoRepository
{ 
    Task<List<Pedido>> GetAllPedidos();
    Task<Pedido?> GetPedidoById(Guid id);
    Task InsertPedido(Pedido pedido);
    Task UpdatePedido(Pedido pedido);

    
}