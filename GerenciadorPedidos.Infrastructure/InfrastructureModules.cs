using GerenciadorPedidos.Domain.IRepositories;
using GerenciadorPedidos.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorPedidos.Infrastructure;

public static class InfrastructureModules
{
    public static IServiceCollection AddInfrasctucture(this IServiceCollection services)
    {
        services.AddRepositories();
           
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        return services;
    }
}