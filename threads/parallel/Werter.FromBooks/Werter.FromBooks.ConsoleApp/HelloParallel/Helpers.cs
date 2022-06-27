namespace Werter.FromBooks.ConsoleApp.HelloParallel;

public class Helpers
{
    public static void DoSomethingBad() =>
        throw new Exception("Ocorreu um erro de teste");

    public static Task MakeShort(Barrier myBarrier)
        => new (() =>
        {
            Console.WriteLine($"Doing a short task for 5 seconds");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            myBarrier.SignalAndWait();
            Console.WriteLine("Completed task short");
        });
    
    public static Task MakeLong(Barrier myBarrier)
        => new (() =>
        {
            Console.WriteLine($"Doing a long task for 10 seconds");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("Completed task long");
            myBarrier.SignalAndWait();
        });
}