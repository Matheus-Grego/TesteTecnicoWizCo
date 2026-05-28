using GerenciadorPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorPedidos.Infrastructure.Persistence;

public class GerenciadorPedidosDbContext : DbContext
{
    public readonly DbContextOptions<GerenciadorPedidosDbContext> _dbContextOptions;

    public GerenciadorPedidosDbContext(DbContextOptions<GerenciadorPedidosDbContext> options) : base(options)
    {
        
    }

    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<ItemPedido>  ItemPedido { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pedido>(e =>
        {
            e.HasKey(x => x.Id);

            e.HasMany(x => x.Itens)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<ItemPedido>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.ProdutoNome)
                .IsRequired()
                .HasMaxLength(150);
        });
        
        base.OnModelCreating(builder);
    }
}