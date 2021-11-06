using System;

namespace C6
{
    public class Demo09 : DemoBase
    {
        public override void Execute()
        {
            string 
                firstName = "Werter",
                lastName = "Bonfim";

            // C#5
            var output = string.Format("{0} - {1}", firstName, lastName);
            Console.WriteLine(output);

            // C#6
            Console.WriteLine($"{firstName} - {lastName}");


        }
    }
}
