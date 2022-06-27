namespace Werter.ListasConcorrentes.ConsoleApp;

public class Relatorio
{
    public string Nome => ToString();
    public int Mes { get; private set; }
    public int Ano { get; private set; }

    public Relatorio(int mes, int ano)
    {
        Mes = mes;
        Ano = ano;
    }

    public override string ToString()
    {
        return $"{Mes}{Ano}";
    }
}