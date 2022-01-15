using DemoFluentApiExamples.Controllers.Models;
using DemoFluentApiExamples.Model;
using DemoFluentApiExamples.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace DemoFluentApiExamples.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ILogger<Produto> _logger;
    private readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoController(ILogger<Produto> logger,
                             IProdutoRepositorio produtoRepositorio)
    {
        _logger = logger;
        _produtoRepositorio = produtoRepositorio;
    }

    [HttpGet()]
    [Route("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        return Ok(await _produtoRepositorio.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult> Post(CadastrarProdutoImputModel imputModel)
    {
        var validacao = imputModel.EstaValido();
        if (!validacao.IsValid)
        {
            return BadRequest(validacao.Errors.Select(x => x.ErrorMessage));
        }
        var produto = new Produto(imputModel.Nome, imputModel.Departamento, imputModel.Preco);
        var sucesso = await _produtoRepositorio.Adicionar(produto);        
        return sucesso ? Created(nameof(Get), produto.Id ) : BadRequest(imputModel);        
    }
}
