using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using BackEndAutomation.MethodsAndData;

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
            logHelperMethod("started.",1);

            Assert.That(2 + 2, Is.EqualTo(4));

            logHelperMethod("passed.",1);
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

        [Test]
        public void ImproveTestWithReportAndLogFail()
        {
            logHelperMethod("started.", 2);

            Utils.AssertWithReportAndLog(
                (1 + 1),
                3,
                "Error message for failed test",
                _test,
                Logger);


            logHelperMethod("failed.", 2);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _extent.Flush();
            Logger.Info("Reporting completed.");
        }

        private void logHelperMethod(string dynamicData, int number)
        {
            Utils.logSuccessWithReportAndLog("Test"+number+" execution "+dynamicData , _test, Logger);
        }
    }
}
