using System;
using System.Threading;

namespace Werter.History.Version5
{
    /*
     *Thread: Fio de execução, linha ou encadeamento de execução
     * 
     */
    
    public class LowestLevelThreadExample
    {
        public void Exemplo01()
        {
            
            var fluxo = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Olá, estou dentro de uma thread (fio de execução) ");
            }));
            fluxo.Start();


            Console.WriteLine("Olá, estou dentro de thread principal");

            fluxo.Join();
        }
    }
}