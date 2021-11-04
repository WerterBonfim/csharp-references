using System;
using static System.Console;
using static C6.UseStatic;

namespace C6
{
    public class Demo01 : DemoBase
    {   
        public override void Execute()
        {
            // 1 - using Static 
            WriteLine("Hello World!");
            MethodtStatic();
        }
    }

    public static class UseStatic
    {
       

        public static void MethodtStatic()
        {
            Console.WriteLine("Not static method");
        }

    }
}
