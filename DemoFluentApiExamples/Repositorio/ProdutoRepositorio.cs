using DemoFluentApiExamples.Data;
using DemoFluentApiExamples.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoFluentApiExamples.Repositorio;
public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly DemoFluentApiContext _ctx;
    public ProdutoRepositorio(DemoFluentApiContext ctx)
    {
        _ctx = ctx;

    }

    public async Task<bool> Adicionar(Produto produto)
    {
        _ctx.Set<Produto>().Add(produto);
        return await _ctx.SaveChangesAsync() > 0;
    }

    public async Task<Produto> GetById(Guid id)
    {
        return await _ctx.Set<Produto>().FirstOrDefaultAsync(x => x.Id == id);
    }
}