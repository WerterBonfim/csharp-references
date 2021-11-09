using System;

namespace C7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Funcionalidade do C# 7");

            DemoBase demo;

            demo = new Demo06();


            demo.Execute();
        }
    }
}
