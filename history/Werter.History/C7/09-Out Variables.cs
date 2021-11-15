using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7
{
    public class Demo09 : DemoBase
    {
        public override void Execute()
        {
            // antes
            int resposta;
            int.TryParse("123", out resposta);
            Console.WriteLine(resposta);

            // depois
            int.TryParse("456", out var novaResposta);
            Console.WriteLine(novaResposta);

            MultiplosParametros();
        }


        private static void MultiplosParametros()
        {
            // antes
            string primeiroNome;
            string sobreNome;
            int loginContador;
            int historiaContador;

            if (EncontrarUsuario(123, out primeiroNome, out sobreNome, out loginContador, out historiaContador))
                Console.WriteLine($"{primeiroNome} {sobreNome} login count: {loginContador} stories {historiaContador}");

            // depois
            if (EncontrarUsuario(123, out var primeiroNome1, out var sobreNome1, out var loginContador1, out var  historiaContador1))
                Console.WriteLine($"{primeiroNome1} {sobreNome1} login count: {loginContador1} stories {historiaContador1}");

        }

        static bool EncontrarUsuario(int usuarioId, out string primeiroNome, out string sobrenome, out int loginContador, out int historiaContador)
        {
            if (usuarioId == 0)
            {
                primeiroNome = string.Empty;
                sobrenome = string.Empty;
                loginContador = 0;
                historiaContador = 0;
                return false;
            }

            primeiroNome = "Sherlock";
            sobrenome = "Holmes";
            loginContador = 42;
            historiaContador = 52;

            return true;
        }
    }
}
