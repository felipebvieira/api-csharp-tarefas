using ApiTarefas.Database;
using ApiTarefas.DTO;
using ApiTarefas.Models;
using ApiTarefas.Models.Erros;
using ApiTarefas.ModelViews;
using ApiTarefas.Servico;
using ApiTarefas.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/tarefas")]
public class TarefasController : ControllerBase
{

    public TarefasController(ITarefaServico servico)
    {
        _servico = servico;
    }

    private ITarefaServico _servico;

    [HttpGet()]
    public IActionResult Index(int page = 1)
    {
        var tarefas = _servico.Lista(page);
        return StatusCode(200, tarefas);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TarefaDTO tarefaDTO)
    {
        try
        {
            var tarefa = _servico.Incluir(tarefaDTO);
            return StatusCode(201, tarefa);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(400, new ErrorView {Mensagem = erro.Message});
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
        try
        {
            var tarefaDb = _servico.BuscaPorId(id);
            return StatusCode(201, tarefaDb);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(404, new ErrorView {Mensagem = erro.Message});
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TarefaDTO tarefaDTO)
    {
        try
        {
            var tarefaDb = _servico.Update(id, tarefaDTO);
            return StatusCode(200, tarefaDb);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(400, new ErrorView {Mensagem = erro.Message});
        }
        
        
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _servico.Delete(id);
            return StatusCode(204);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(400, new ErrorView {Mensagem = erro.Message});
        }
    }
}
