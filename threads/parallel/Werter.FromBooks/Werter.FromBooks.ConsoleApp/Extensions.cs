using System.Diagnostics;
using Werter.FromBooks.ConsoleApp.HelloParallel;
using static System.Console;

namespace Werter.FromBooks.ConsoleApp;

public static class Extencions
{
    private static readonly Stopwatch _ = new Stopwatch();
    private static readonly List<string> Summary = new();

    public static void PrintStockInConsole(this StockQuote stock) =>
        WriteLine($"Serial processing stock: {stock.Company}. ID: {stock.Id}");

    public static void StartStopWatch(this string text)
    {
        ChangeForeground();
        WriteLine($"{text}. {DateTime.Now}");
        ChangeForeground();
        _.Start();
    }

    public static void PauseStopWatch(this string text)
    {
        _.Stop();

       ChangeForeground();

       var result = $"{text}. Elapsed time: {_.Elapsed:g}"; 
        WriteLine(result);
        Summary.Add(result);
        _.Reset();

        ChangeForeground();
        WriteLine("\n");
    }

    public static void DisplaySummary(this string text)
    {
        WriteLine(text);
        ChangeForeground();
        Summary.ForEach(WriteLine);
    }
    

    private static void ChangeForeground()
    {
        if (ForegroundColor == ConsoleColor.Green)
        {
            ForegroundColor = ConsoleColor.Gray;
            return;
        }
        
        ForegroundColor = ConsoleColor.Green;
        
    }
}