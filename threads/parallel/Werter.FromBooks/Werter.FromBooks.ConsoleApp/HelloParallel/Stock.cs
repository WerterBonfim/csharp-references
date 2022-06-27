namespace Werter.FromBooks.ConsoleApp.HelloParallel;

public static class Data
{
    public static List<StockQuote> StockList =>
        new[]
        {
            new StockQuote(1, "Microsoft", 5.34m),
            new StockQuote(2, "IBM", 1.9m),
            new StockQuote(3, "Yahoo", 2.34m),
            new StockQuote(4, "Google", 1.54m),
            new StockQuote(5, "Altavista", 4.74m),
            new StockQuote(6, "Ask", 3.21m),
            new StockQuote(7, "Amazon", 30.8m),
            new StockQuote(8, "HSBC", 45.6m),
            new StockQuote(9, "Barclays", 23.2m),
            new StockQuote(10, "Gilette", 1.84m),
        }.ToList();
}

public class StockQuote
{
    public int Id { get; set; }
    public string Company { get; set; }
    public decimal Price { get; set; }

    public StockQuote(int id, string company, decimal price)
    {
        Id = id;
        Company = company;
        Price = price;
    }

    public override string ToString() => $"{Company} - ID: {Id}";
}


public class StockService
{
    private static readonly Random Random = new();
    
    public static decimal CallService(StockQuote quote)
    {
        Console.WriteLine($"Executing long task for {quote}");
        Thread.Sleep(1000);
        return Convert.ToDecimal(Random.NextDouble());
    }

    public static void ExcuteLongService(TimeSpan time, StockQuote stock)
    {
        Console.WriteLine($"Excuting log task for {stock}");
        Thread.Sleep(time);
        Console.WriteLine($"End task for {stock}");
    }
}