using BackEndAutomation.MethodsAndData;
using NUnit.Framework;
using System.Diagnostics;

namespace BackEndAutomation.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Children)]
    public class ParallelDataProcessorTests
    {
        Stopwatch sw = Stopwatch.StartNew();

        [Test]
        public void ProcessData_ShouldDoubleTheInput()
        {
            Time("Create test");
            var processor = new DataProcessorParallelTests();
            int result = processor.ProcessData(5);
            Thread.Sleep(5200);
            Time("After work");
            Assert.That(result, Is.EqualTo(10));
            Time("Test end");
        }

        [Test]
        public void ProcessData_ShouldHandleZero()
        {
            Time("Create test");
            var processor = new DataProcessorParallelTests();
            int result = processor.ProcessData(0);
            Thread.Sleep(7500);
            Time("After work");
            Assert.That(result, Is.EqualTo(0));
            Time("Test end");
        }

        [Test]
        public void ProcessData_ShouldHandleNegativeNumbers()
        {
            Time("Create test");
            var processor = new DataProcessorParallelTests();
            int result = processor.ProcessData(-3);
            Thread.Sleep(20000);
            Time("After work");
            Assert.That(result, Is.EqualTo(-6));
            Time("Test end");
        }

        private void Time(string eventName)
        {
            Console.WriteLine($"Time from {eventName}: " + sw.Elapsed);
        }
    }
}
