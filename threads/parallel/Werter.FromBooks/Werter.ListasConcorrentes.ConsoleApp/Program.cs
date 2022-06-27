

using System.Collections.Concurrent;
using Microsoft.Data.SqlClient;
using Werter.ListasConcorrentes.ConsoleApp;

var relatoriosMes = new ConcurrentDictionary<string, Relatorio>();

int GetLastDayOfMonth()
{
    int
        month = DateTime.Now.Month,
        year = DateTime.Now.Year;
    
    var lastDayOfMonth = new DateTime(year, month, 1)
        .AddMonths(1)
        .AddDays(-1);

    return lastDayOfMonth.Day;
}

var lastDay = GetLastDayOfMonth();

using var connection = new SqlConnection("Server=localhost,1433;Database=LojaOnline;User Id=sa;Password=!123Senha;Encrypt=false");
var service = new CargoService(connection);

var cancelation = new CancellationTokenSource();
//cancelation.CancelAfter(TimeSpan.FromSeconds(10));

service.InitCargo(6, 5, 2022, cancelation.Token);