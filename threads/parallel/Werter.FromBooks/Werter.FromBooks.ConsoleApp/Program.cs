using Werter.FromBooks.ConsoleApp;
using Werter.FromBooks.ConsoleApp.HelloParallel;
using static System.Console;


void RunInSerial()
{
    "Example: RunInSerial".StartStopWatch();

    for (var index = 0; index < Data.StockList.Count(); index++)
    {
        var stock = Data.StockList[index];
        stock.PrintStockInConsole();
        StockService.CallService(stock);
        WriteLine();
    }

    "Finish RunInSerial".PauseStopWatch();
}

void RunInParallel()
{
    "Example: RunInParallel".StartStopWatch();

    var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };

    Parallel.For(
        0,
        Data.StockList.Count,
        //options,
        i =>
        {
            var stock = Data.StockList[i];
            stock.PrintStockInConsole();
            StockService.CallService(stock);
            WriteLine();
        });

    "Finish RunInParallel".PauseStopWatch();
}

void RunFistExample()
{
    RunInSerial();
    RunInParallel();
    "Summary:".DisplaySummary();    
}

//RunFistExample();



Parallel.Invoke(
    () => StockService.CallService(Data.StockList[0]),
               () => StockService.CallService(Data.StockList[1]),
               () => StockService.CallService(Data.StockList[2])
);