﻿namespace BackEndAutomation.MethodsAndData.ParallelTesting
{
    public class ParallelTesting
    {
        public static void ParallelTestingMethod()
        {
            Parallel.For(0, 5, i =>
            {
                Console.WriteLine($"Processing item {i} on thread {Task.CurrentId}");
            });

            Console.WriteLine("All tasks completed.");
        }
    }
}
