namespace Werter.ListasConcorrentes.ConsoleApp;

public class CargoService
{
    private ParallelLoopResult _loopResult;
    
    public StatusCargo InitCargo(int month, int lastDayOfMonth, int year)
    {
        _loopResult = Parallel
            .For(
                1, 
                lastDayOfMonth, 
                new ParallelOptions { MaxDegreeOfParallelism = 2},
                i =>ExecuteCargo(i, month, year)
                );

        return null;
    }


    private void ExecuteCargo(int day, int month, int year)
    {
        
    }
}