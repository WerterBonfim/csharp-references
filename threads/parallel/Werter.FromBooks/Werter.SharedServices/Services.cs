namespace Werter.SharedServices;

public class Services
{
    private readonly Random _random = new Random();

    private int LittleInt() => _random.Next(1, 1000);
    private double LittleDouble() => Convert.ToDouble( _random.Next(100, 9999));
    
    public (int, double) LongWork(int seconds = 4)
    {
        Console.WriteLine("Executing long work...");
        Thread.Sleep(TimeSpan.FromSeconds(seconds));

        return (LittleInt(), LittleDouble());
    }
}