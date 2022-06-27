

using System.Collections.Concurrent;
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
for (var index = 1; index <= lastDay; index++)
{
    
}