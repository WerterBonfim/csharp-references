using C6;
using System;

public class Demo05 : DemoBase
{
    public override void Execute()
    {
        int
            valorA = 7,
            valorB = 0;
        try
        {

            var resultado = valorA / valorB;
        }
        catch (Exception ex) when (valorB == 0)
        {
            Console.WriteLine("Não pode dividir um valor por 0");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}