namespace BackEndAutomation.MethodsAndData.ParallelTesting
{
    public class RaceCondition
    {
        private static int sharedCounter = 0;

        public static void RaceConditionMethod()
        {
            Parallel.For(0, 1000, _ =>
            {
                sharedCounter++;
            });

            Console.WriteLine($"Final value of shared counter: {sharedCounter}");
        }
    }
}
