namespace ApiTarefas.DTO;

public record TarefaDTO
{
    public string Titulo { get;set; } = default!;
    public string Descricao { get;set; } = default!;
    public bool Concluida { get;set; } = default!;
}