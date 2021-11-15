using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace C7
{
    public class Demo01 : DemoBase
    {
        public override void Execute()
        {
            Console.WriteLine("C# 01 - Local Function\n");
            //new WebReaderBefore().ShowText("");
            new WebReaderAfter().ShowText("https://www.packtpub.com/tech/C-Sharp");
        }

        public class WebReaderBefore
        {
            public void ShowText(string url)
            {
                var lines = ReadPage(url).Result;
                var n = 0;
                foreach (var line in lines)
                {
                    n++;
                    Console.WriteLine($"{n}: {lines}");
                }
            }

            private async Task<string[]> ReadPage(string url)
            {
                if (string.IsNullOrEmpty(url))
                    throw new ArgumentNullException(nameof(url));

                var client = new HttpClient();
                var contents = await client.GetStringAsync(url);
                return contents
                    .Split(new[] { "<", "/>" }, StringSplitOptions.None)
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Take(7)
                    .ToArray();
            }

            public int AnotherFunction(int a, int b)
            {
                // Essa função tem acesso a ReadPages, e ela não precisa
                var resultado = ReadPage("");
                return a + b;
            }
        }

        public class WebReaderAfter
        {
            public void ShowText(string url)
            {
                var lines = ReadPage(url).Result;
                var n = 0;
                foreach (var line in lines)
                {
                    n++;
                    Console.WriteLine($"{n}: {line}");
                }

                // Local Function, posso colocar em qualquer lugar dentro metodo
                static async Task<string[]> ReadPage(string url)
                {
                    if (string.IsNullOrEmpty(url))
                        throw new ArgumentNullException(nameof(url));

                    var client = new HttpClient();
                    var contents = await client.GetStringAsync(url);
                    return contents
                        .Split(new[] { "<", "/>", ">"}, StringSplitOptions.None)
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Take(7)
                        .ToArray();
                }
            }


            public int AnotherFunction(int a, int b)
            {
                // Não posso ver mais a função ReadPage
                // var resultado = ReadPage("");
                return a + b;
            }
        }
    }
}
