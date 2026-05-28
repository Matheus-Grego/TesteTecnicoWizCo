using GerenciadorPedidos.Application.Commands.CancelPedido;
using GerenciadorPedidos.Domain.Entities;
using GerenciadorPedidos.Domain.Enums;
using GerenciadorPedidos.Domain.IRepositories;
using Moq;
using Xunit;

namespace GerenciadorPedidos.UnitTests.Application;

public class CancelPedidoHandlerTest
{
    private readonly Mock<IPedidoRepository> _repositoryMock;
    private readonly CancelPedidoHandler _handler;

    public CancelPedidoHandlerTest()
    {
        _repositoryMock = new Mock<IPedidoRepository>();
        _handler = new CancelPedidoHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_DeveCancelarPedido_QuandoPedidoExisteEStatusForNovo()
    {
        // Arrange
        var pedidoId = Guid.NewGuid();

        var pedido = new Pedido(
            clienteNome: "Matheus",
            valorTotal: 100
        );

        _repositoryMock
            .Setup(r => r.GetPedidoById(pedidoId))
            .ReturnsAsync(pedido);

        // Act
        var result = await _handler.Handle(
            new CancelPedidoCommand(pedidoId),
            CancellationToken.None
        );

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(StatusPedidoEnum.Cancelado, pedido.Status);

        _repositoryMock.Verify(r => r.UpdatePedido(pedido), Times.Once);
    }

    [Fact]
    public async Task Handle_DeveRetornarFailure_QuandoPedidoNaoExiste()
    {
        // Arrange
        var pedidoId = Guid.NewGuid();

        _repositoryMock
            .Setup(r => r.GetPedidoById(pedidoId))
            .ReturnsAsync((Pedido?)null);

        // Act
        var result = await _handler.Handle(
            new CancelPedidoCommand(pedidoId),
            CancellationToken.None
        );

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Pedido não encontrado", result.Message);

        _repositoryMock.Verify(r => r.UpdatePedido(It.IsAny<Pedido>()), Times.Never);
    }
}