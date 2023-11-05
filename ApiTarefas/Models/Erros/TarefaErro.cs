namespace ApiTarefas.Models.Erros;

public class TarefaErro : Exception 
{
    public TarefaErro(string message) : base(message) {}
}