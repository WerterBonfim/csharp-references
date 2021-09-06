using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Werter.Estudos.TenTips.FirstTip
{
    class Program
    {
        static void Main(string[] args)
        {
            var dicionario = new Dictionary<string, int>();
            
            dicionario.Add("dez", 10);
            dicionario.Add("vinte", 20);
            dicionario.Add("trinta", 30);
            
            CodigoRuim(dicionario);
            
            BomCodigo(dicionario);
        }

        private static void BomCodigo(Dictionary<string, int> dicionario)
        {
            int resultado;
            int total;
            // Use esse código
            // Verifica o valor, atribui ao parâmetro out se existir no dicionário.
            if (dicionario.TryGetValue("trinta", out resultado))
            {
                total = resultado * 5;
                Console.WriteLine($"$Resultado: {resultado}");
            }
        }

        private static void CodigoRuim(Dictionary<string, int> dicionario)
        {
            int resultado;
            int total;
            // Evite race coditions ao verificar se um item existe em um dicionário.

            // Não escreve um código assim
            if (dicionario.ContainsKey("trinta"))
            {
                // Outra thread pode ter removido o item antes
                // desse código ser executado

                resultado = dicionario["trinta"];

                total = resultado * 5;
            }
        }
    }
}