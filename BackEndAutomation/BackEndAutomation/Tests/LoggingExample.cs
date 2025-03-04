using NUnit.Framework.Internal;
using NUnit.Framework;
using NLog;
using Assert = NUnit.Framework.Assert;


namespace BackEndAutomation.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Children)]
    public class LoggingExample
    {
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void ParallelTest1()
        {
            Logger.Info("ParallelTest1 started.");
            Assert.That(2 + 2, Is.EqualTo(4));
            Logger.Info("ParallelTest1 passed.");
        }

        [Test]
        public void ParallelTest2()
        {
            Logger.Info("ParallelTest2 started.");
            Assert.That(3 + 3, Is.EqualTo(6));
            Logger.Info("ParallelTest2 passed.");
        }
    }
}
