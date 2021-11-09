using System;
using System.Collections.Generic;
using System.Linq;

namespace C7
{
    public class Demo06 : DemoBase
    {
        public override void Execute()
        {
            Console.WriteLine("Recurso Tuplas");

            var oldTuples = OldTuples();
            var newTuples = NewWayTuplas();

            Console.WriteLine($"{oldTuples.Item1} - {oldTuples.Item2}");
            Console.WriteLine($"{newTuples.Item1} - {newTuples.Item2}");

            (int minimo, int maximo) = EncontrarMinimoMaximo(GerarNumerosAleatorios());
            (int, int) minMax = EncontrarMinimoMaximo(GerarNumerosAleatorios());
            //minMax.Item1	

            (int minimo2, int maximo2) = EncontrarMinimoMaximo2(GerarNumerosAleatorios());
            (int, int) minMax2 = EncontrarMinimoMaximo2(GerarNumerosAleatorios());
            //minMax2.Item1

            var minMax3 = EncontrarMinimoMaximo2(GerarNumerosAleatorios());
            //minMax3.Minimo

            var werter = ("Werter", 120);
            //werter.Item1
            (string, int) liz = ("liz", 110);
            //liz.Item1

            var tuple = (Name: "Werter", Age: 120);
            //tuple.Name
            //tuple.Age

            ValueTuple<string, int> allan = ValueTuple.Create("Joaquin", 22);
            //allan.Item1
            (string, int) joaquin = ValueTuple.Create("Allan", 23);
            //joaquin.Item1

            //Deconstruction Tuples
            (string name, int age) = joaquin;
            Console.WriteLine(name);
            var (nome, idade, sexo) = ObterPessoa();
            Console.WriteLine(nome);

            var tuples = new[]
            {
                ("B", 50),
                ("B", 40),
                ("A", 30),
                ("A", 20)
            };

            //tuples.OrderBy(x => x).Dump("They're all now in order!");

        }

        static (string, int, char) ObterPessoa() => ("Fulano", 23, 'M');

        public Tuple<int, int> OldTuples() => Tuple.Create(0, 0);
        public (int, int) NewWayTuplas() => (1, 2);

        public List<int> GerarNumerosAleatorios() => Enumerable
            .Range(0, 10)
            .OrderBy(x => Guid.NewGuid())
            .Take(10)
            .ToList();

        public (int, int) EncontrarMinimoMaximo(List<int> numeros)
        {
            int
                minimo = int.MaxValue,
                maximo = int.MinValue;

            numeros.ForEach(x =>
            {
                minimo = x < minimo ? minimo : x;
                maximo = x > maximo ? maximo : x;
            });

            return (minimo, maximo);
        }

        public (int Minimo, int Maximo) EncontrarMinimoMaximo2(List<int> numeros)
        {
            int
                minimo = int.MaxValue,
                maximo = int.MinValue;

            numeros.ForEach(x =>
            {
                minimo = x < minimo ? minimo : x;
                maximo = x > maximo ? maximo : x;
            });

            return (minimo, maximo);
        }
    }
}
