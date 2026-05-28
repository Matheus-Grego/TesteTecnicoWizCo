using GerenciadorPedidos.Domain.Entities;
using GerenciadorPedidos.Domain.Enums;
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
    public async Task<List<Pedido>> GetAllPedidos(StatusPedidoEnum? status)
    {
        var query = _dbContext.Pedido.AsNoTracking().Include(x => x.Itens)
            .Where(p => !p.IsDeleted);

        if (status.HasValue)
            query = query.Where(p => p.Status == status.Value);

        return await query.ToListAsync();
        
    }

    public async Task<Pedido?> GetPedidoById(Guid id)
    {
        return await _dbContext.Pedido.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
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