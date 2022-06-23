new Thread(
        new ParameterizedThreadStart(ExecutedLongRunningOperation)
    )
    .Start(1000);

static void ExecutedLongRunningOperation(object miliseconds)
{
    Thread.Sleep((int)miliseconds);
    Console.WriteLine("Operation completed successfully");
    Parallel.For()
}