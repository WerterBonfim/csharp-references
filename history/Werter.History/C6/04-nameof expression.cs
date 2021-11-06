using System;

namespace C6
{
    public class Demo04 : DemoBase
    {

        public override void Execute()
        {
            var pedro = new Funcionario();

            Console.WriteLine("{0} : {1}", nameof(Funcionario.Nome), pedro.Nome);
            Console.WriteLine("{0} : {1}", nameof(Funcionario.Idade), pedro.Idade);
            Console.WriteLine("{0} : {1}", nameof(Funcionario.Salario), pedro.Salario);
            Console.WriteLine("{0} : {1}", nameof(Funcionario.Profissão), pedro.Profissão);
                }
    }
}