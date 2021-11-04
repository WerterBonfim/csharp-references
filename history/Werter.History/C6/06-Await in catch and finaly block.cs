using System;
using System.Threading.Tasks;
using static System.Console;

namespace C6
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class MyMath
    {
        public async void Div(int valueA, int valueB)
        {

            try
            {
                int result = valueA / valueB;
            }
            catch (Exception ex)
            {
                await MethodForCatchAsync();
            }
            finally
            {
                await MethodForFinalyAsync();
            }
        }

        private async Task MethodForFinalyAsync()
        {
            WriteLine("Metodo assíncrono para o Finaly");
        }


        private async Task MethodForCatchAsync()
        {
            WriteLine("Metodo assíncrono para o Catch");
        }

    }
}
