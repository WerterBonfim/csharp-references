using System;

namespace Werter.ThreadSafeLearning.QueueProblems
{
    public abstract class ExamplesBase
    {
        public static readonly Random Ran = new();
        

        public void Execute()
        {
            try
            {
                Demo();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception:{ex.Message}");
                Console.ResetColor();
            }
        }

        public abstract void Demo();


        public void WriteHeaderToConsole(string headerText)
        {
            Console.ResetColor();
            Console.WriteLine("-----------------------------");
            Console.WriteLine(headerText);
            Console.WriteLine("-----------------------------");
        }
    }
}
