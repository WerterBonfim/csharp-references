using System.Diagnostics;
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

//RunInSerial();

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


//RunInParallel();

void RunFistExample()
{
    RunInSerial();
    RunInParallel();
    "Summary:".DisplaySummary();
}

//RunFistExample();


void ExampleParallelIvoke()
{
    Parallel.Invoke(
        () => StockService.CallService(Data.StockList[0]),
        () => StockService.CallService(Data.StockList[1]),
        () => StockService.CallService(Data.StockList[2])
    );
}

//ExampleParallelIvoke();


void ExampleContinueWith()
{
    Trace.Listeners.Add(new TextWriterTraceListener(Out));

    Task.Factory
        .StartNew(() => WriteLine("Hello task 1"))
        .ContinueWith((t) => WriteLine("Hello task 2"))
        .ContinueWith((t) => WriteLine("Hello task 3"))
        .ContinueWith((t) => WriteLine("Hello task 4"))
        ;

    var task3 = Task.Factory.StartNew(() => Helpers.DoSomethingBad())
        .ContinueWith(t
            => System.Diagnostics.Trace.Write("I will be run"), TaskContinuationOptions.OnlyOnFaulted);
}

//ExampleContinueWith();


void ExampleLongRunningToViewParallelTask()
{
    Parallel.Invoke(
        () => StockService.ExcuteLongService(TimeSpan.FromSeconds(10), Data.StockList[0]),
        () => StockService.ExcuteLongService(TimeSpan.FromSeconds(5), Data.StockList[1]),
        () => StockService.ExcuteLongService(TimeSpan.FromSeconds(7), Data.StockList[2])
    );
}

//ExampleLongRunningToViewParallelTask();


void ExampleBarrier()
{
    var myBarrier = new Barrier(2);

    var task1 = Helpers.MakeShort(myBarrier);
    var task2 = Helpers.MakeLong(myBarrier);

    task1.Start();
    task2.Start();
}

//ExampleBarrier();


void ExampleCancellationToken()
{
    var cts = new CancellationTokenSource();

    var task = Task.Factory.StartNew(DoSomething, cts.Token);
    Thread.Sleep(2000);
    cts.Cancel();

    void DoSomething()
    {
        try
        {
            while (true)
            {
                WriteLine("doing stuff");


                if (cts.Token.IsCancellationRequested != true) continue;

                WriteLine("Cancelado");
                throw new OperationCanceledException(cts.Token);
            }
        }
        catch (OperationCanceledException e)
        {
            WriteLine("Operação cancelada");
            WriteLine(e);
        }
    }
}

//ExampleCancellationToken();

void ExampleCountDownEvent()
{
    var countDown = new CountdownEvent(2);

    ThreadPool.QueueUserWorkItem(new WaitCallback(CountDownDeduct));
    ThreadPool.QueueUserWorkItem(new WaitCallback(CountDownDeduct));
    
    // Espere até que a contagem seja descrementado pelo método DecrementCountDown
    countDown.Wait();
    WriteLine("Completed");
    ReadKey();

    void CountDownDeduct(object stateInfo)
    {
        Thread.Sleep(5000);
        WriteLine("Deducting 1 from countdown");
        countDown.Signal();
    }
}


//ExampleCountDownEvent();





void PrintMessage(object message) => Console.WriteLine(message);

Task task2 = new Task((x) => PrintMessage(x), "Second Task");
task2.Start();



ReadKey();
