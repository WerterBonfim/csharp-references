namespace Werter.ListasConcorrentes.ConsoleApp;

public class StatusCargo
{
    public bool IsCompleted { get; private set; } = false;
    public string StatusMessage { get; private set; }
    public readonly Relatorio Result;


    public StatusCargo(Relatorio relatorio)
    {
        Result = relatorio;
    }

    public void UpdateMessage(string message) => StatusMessage = message;
}