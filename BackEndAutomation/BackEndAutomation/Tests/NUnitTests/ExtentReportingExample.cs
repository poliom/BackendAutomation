using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;
using BackEndAutomation.Utilities;

namespace BackEndAutomation.Tests.NUnitTests
{
    [TestFixture]
    public class ExtentReportingExample
    {
        private static ExtentReports _extent;
        private ExtentTest testReportObject;

        [OneTimeSetUp]
        public void SetupReport()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var sparkReporter = new ExtentSparkReporter($"TestReport_{timestamp}.html");
            sparkReporter.Config.DocumentTitle = "Test Execution Report";
            sparkReporter.Config.ReportName = "Extent Report Example";

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [SetUp]
        public void BeforeTest()
        {
            testReportObject = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [Test]
        public void SuccessfulTest()
        {
            testReportObject.Log(Status.Info, "This is a successful test.");
            Assert.That(1 + 1, Is.EqualTo(2));
            testReportObject.Log(Status.Pass, "Test passed successfully.");
        }

        [Test]
        public void FailingTest()
        {
            testReportObject.Log(Status.Info, "This is a failing test.");
            if (1 + 1 != 3)
            {
                testReportObject.Log(Status.Fail, "Test failed.");
            }
            Assert.That(1 + 1, Is.EqualTo(3));
            Console.WriteLine("asdasd");
        }

        [Test]
        public void TestToFailWithRappValidation()
        {
            testReportObject.Log(Status.Info, "This is a failing test.");

            Utils.AssertMethodWithReport(
                1 + 1,
                3,
                "Error message for failed test",
                testReportObject);

            Console.WriteLine("asdasd");
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            _extent.Flush();
        }
    }
}
