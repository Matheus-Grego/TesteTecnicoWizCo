using FluentValidation;
using GerenciadorPedidos.Application.Commands.InsertPedido;

namespace GerenciadorPedidos.Application.Validators;

public class InsertPedidoValidator : AbstractValidator<InsertPedidoCommand>
{
    public InsertPedidoValidator()
    {
        RuleFor(p => p.ClienteNome)
            .NotEmpty()
            .WithMessage("O nome do cliente é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O nome do cliente deve ter no máximo 100 caracteres.");

        RuleFor(p => p.ItemsPedido)
            .NotNull()
            .WithMessage("Os itens do pedido são obrigatórios.")
            .NotEmpty()
            .WithMessage("O pedido deve possuir pelo menos um item.");

        RuleForEach(p => p.ItemsPedido).ChildRules(item =>
        {
            item.RuleFor(i => i.ProdutoNome)
                .NotEmpty()
                .WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

            item.RuleFor(i => i.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero.");

            item.RuleFor(i => i.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("O valor unitário deve ser maior que zero.");
        });
    }
    
}