using System.Collections.Generic;


namespace C6
{

    public class Demo03 : DemoBase
    {
        public override void Execute()
        {
            Form1();
            Form2();
        }

        public void Form1()
        {
            // Form 1

            Dictionary<string, string> version05Form1 = new Dictionary<string, string>()
            {
                {"Guitarra","Fender Stratocaster Eric Johnson Signature"},
                {"Violão","Yamaha Silent SLG200s"},
                {"Semi-Acutica","Ibanez GB10 George Benson"},
            };
            version05Form1["Guitarra"] = "1964 Gibson ES-335";


            Dictionary<string, string> version06Form1 = new Dictionary<string, string>()
            {
                ["Guitarra"] = "Fender Stratocaster Eric Johnson Signature",
                ["Violão"] = "Yamaha Silent SLG200s",
                ["Semi-Acutica"] = "Ibanez GB10 George Benson",
            };

            version06Form1["Guitarra"] = "1964 Gibson ES-335";
        }

        public void Form2()
        {
            // Form 2


            Dictionary<int, string> version05Form2 = new Dictionary<int, string>()
            {
              {1,"C#"},
              {2,"Sql"},
              {3,"F#"},
            };
            version05Form2[4] = "Redis";


            Dictionary<int, string> version06Form2 = new Dictionary<int, string>()
            {
                [1] = "C#",
                [2] = "Sql",
                [3] = "F#"
            };
            version06Form2[4] = "Redis";

        }
    }
}








