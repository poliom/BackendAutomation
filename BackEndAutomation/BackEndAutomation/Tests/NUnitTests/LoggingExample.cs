using NUnit.Framework.Internal;
using NUnit.Framework;
using NLog;
using Assert = NUnit.Framework.Assert;


namespace BackEndAutomation.Tests.NUnitTests
{
    [TestFixture, Parallelizable(ParallelScope.Children)]
    public class LoggingExample
    {
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void ParallelTest1()
        {
            Logger.Debug("zxvzxvzx started.");
            Assert.That(2 + 2, Is.EqualTo(4));
            Logger.Info("zxvzxvzxvxzv passed.");
            Assert.That(1, Is.EqualTo(1));
            Logger.Info("after assert.");
        }

        [Test]
        public void ParallelTest2()
        {
            Logger.Info("zxvzxvzxvzxvxzv started.");
            Assert.That(3 + 3, Is.EqualTo(6));
            Logger.Info("PzxvzxvasvazxvzvzsvarallelTest2 passed.");
        }
    }
}
