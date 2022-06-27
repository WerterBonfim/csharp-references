using Dapper;
using Microsoft.Data.SqlClient;

namespace Werter.ListasConcorrentes.ConsoleApp;

public class CargoService
{
    private ParallelLoopResult _loopResult;
    private readonly SqlConnection _connection;

    public CargoService(SqlConnection connection)
    {
        _connection = connection;
    }

    public Task<StatusCargo> InitCargo(int month, int lastDayOfMonth, int year, CancellationToken cancellationToken)
    {
        //ExecuteCargo(index + 1, month, year, cancellationToken);

        var tasks = new Task[lastDayOfMonth];
        for (var index = 0; index < lastDayOfMonth; index++)
            tasks[index] = Task.Factory.StartNew(() =>
            {
                var day = index + 1;
                Console.WriteLine($"Iniciando a carga do dia {day}");
                var query = $@"  begin
                            waitfor delay '{TimeSpan.FromSeconds(2)}'
                            select 1 as qtd, 10 as soma
                        end";

                var command = new CommandDefinition(commandText: query, cancellationToken: cancellationToken);
                //var (qtd, soma) = _connection.QuerySingle<(int, double)>(command);
                var teste = _connection.QuerySingle(query);
                Console.WriteLine($"Terminou a consulta do dia {day}");
                return (0, 1);
            }, cancellationToken);


        
        
        Task.WaitAll(tasks, cancellationToken);

        


        return null;

    }

private Task<(int, double)> ExecuteCargo(
    int day,
    int month,
    int year,
    CancellationToken cancellationToken)
{
    Console.WriteLine($"Iniciando a carga do dia {day}");
    var query = $@"  begin
                            waitfor delay {TimeSpan.FromSeconds(2)}
                            select 1 as qtd, 10 as soma
                        end";

    var command = new CommandDefinition(commandText: query, cancellationToken: cancellationToken);
    var resultado = _connection.QuerySingleAsync<(int, double)>(command);
    Console.WriteLine($"Terminou a consulta do dia {day}");
    return resultado;
}

}