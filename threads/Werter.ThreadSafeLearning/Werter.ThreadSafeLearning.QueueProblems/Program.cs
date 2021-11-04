namespace Werter.ThreadSafeLearning.QueueProblems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExamplesBase cenario;

            //cenario = new WrongScenario();
            //cenario = new UseLockAndMutex();
            //cenario = new UseConcurrentDictionary();
            cenario = new UpdatingDataInConcurrentDictionary();

            cenario.Execute();
        }
    }
}
