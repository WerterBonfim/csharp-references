using System;

namespace C6
{
    public class Demo08 : DemoBase
    {
        public override void Execute()
        {
            Console.WriteLine(GetTimeCSharp5());
            Console.WriteLine(GetTimeCSharp6());
        }


        public static string GetTimeCSharp5()
        {
            return "Current time - " + DateTime.Now.ToString("hh:mm:ss");
        }

        public static string GetTimeCSharp6() => "Current time - " + DateTime.Now.ToString("hh:mm:ss");

    }
}
