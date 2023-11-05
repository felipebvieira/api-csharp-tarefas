using ApiTarefas.Database;
using ApiTarefas.DTO;
using ApiTarefas.Models;
using ApiTarefas.Models.Erros;

namespace ApiTarefas.Servico.Interfaces;

public interface ITarefaServico
{
    List<Tarefa> Lista(int page);

    Tarefa Incluir(TarefaDTO tarefaDTO);

    Tarefa Update(int id, TarefaDTO tarefaDTO);

    Tarefa BuscaPorId(int id);

    void Delete(int id);
}