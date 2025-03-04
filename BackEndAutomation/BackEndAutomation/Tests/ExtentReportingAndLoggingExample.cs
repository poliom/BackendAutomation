using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;

namespace BackEndAutomation.Tests
{

    [TestFixture]
    public class ExtentReportingAndLoggingExample
    {
        private static ExtentReports _extent;
        private ExtentTest _test;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void Setup()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var sparkReporter = new ExtentSparkReporter($"Combined_{timestamp}.html");
            sparkReporter.Config.DocumentTitle = "Test Execution Report";
            sparkReporter.Config.ReportName = "Extent Report Example";

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
            Logger.Info("Reporting setup completed.");
        }

        [SetUp]
        public void BeforeTest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Logger.Info($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        [Test]
        public void TestWithReportAndLog()
        {
            _test.Log(Status.Info, "Test1 is running.");
            Logger.Info("Test1 execution started.");
            Assert.That(2 + 2, Is.EqualTo(4));
            _test.Log(Status.Pass, "Test1 passed.");
            Logger.Info("Test1 execution passed.");
        }

        [Test]
        public void TestWithReportAndLogFail()
        {
            _test.Log(Status.Info, "Test2 is running.");
            Logger.Info("Test2 execution started.");
            if ((1 + 1) != 3)
            {
                _test.Log(Status.Fail, "Test2 failed.");
            }
            Assert.That(1 + 1, Is.EqualTo(3));
            Logger.Info("Test2 execution failed.");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _extent.Flush();
            Logger.Info("Reporting completed.");
        }
    }
}
