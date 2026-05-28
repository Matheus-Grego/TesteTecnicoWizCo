namespace GerenciadorPedidos.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
        IsDeleted = false;
    }
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool IsDeleted { get; set; }

    public void Deletar()
    {
        IsDeleted = true;
        DataAtualizacao = DateTime.Now;
    }
}