using DemoFluentApiExamples.Model;

namespace DemoFluentApiExamples.Repositorio;
public interface IProdutoRepositorio
{
    Task<bool> Adicionar(Produto produto);
    Task<Produto> GetById(Guid id);
}