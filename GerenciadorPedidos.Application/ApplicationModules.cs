using GerenciadorPedidos.Application.Commands.InsertPedido;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorPedidos.Application;

public static class ApplicationModules
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddHandler();
      
        return services;
    }
    
    private static IServiceCollection AddHandler(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertPedidoCommand>());
        return services;
    }
}