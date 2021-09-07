using System;
using System.Runtime.CompilerServices;

namespace Werter.History.Version5
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ExemploCallerInfo().MostrarInformacoesDoChamador();
            
            new LowestLevelThreadExample().Exemplo01();
        }
    }

    public class ExemploCallerInfo
    {
        public ExemploCallerInfo()
        {
            Console.WriteLine("C# 5 - Exemplo Caller");
        }

        public void MostrarInformacoesDoChamador(
            [CallerMemberName] string nome = null,
            [CallerFilePath]string caminho = null,
            [CallerLineNumber] int linha = 0
        )
        {
            Console.WriteLine("CallerMemberName: {0}", nome);
            Console.WriteLine("CallerFilePath: {0}", caminho);
            Console.WriteLine("CallerLineNumber: {0}", linha);
        }
    }
}