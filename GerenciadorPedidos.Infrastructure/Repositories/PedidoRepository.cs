using GerenciadorPedidos.Domain.Entities;
using GerenciadorPedidos.Domain.IRepositories;
using GerenciadorPedidos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorPedidos.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly GerenciadorPedidosDbContext _dbContext;

    public PedidoRepository(GerenciadorPedidosDbContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Pedido>> GetAllPedidos()
    {
       return await _dbContext.Pedido.Where(p => !p.IsDeleted).ToListAsync();
    }

    public async Task<Pedido?> GetPedidoById(Guid id)
    {
        return await _dbContext.Pedido.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task InsertPedido(Pedido pedido)
    {
        await _dbContext.Pedido.AddAsync(pedido);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePedido(Pedido pedido)
    {
        _dbContext.Pedido.Update(pedido);
        await _dbContext.SaveChangesAsync();

    }
}