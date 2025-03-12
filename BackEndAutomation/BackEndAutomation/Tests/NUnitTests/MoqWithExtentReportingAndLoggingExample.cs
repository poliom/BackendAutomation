using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Moq;
using NLog;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;
using BackEndAutomation.MethodsAndData;

namespace BackEndAutomation.Tests.NUnitTests
{
    [TestFixture]
    public class MoqWithExtentReportingAndLoggingExample
    {
        private static ExtentReports _extent;
        private ExtentTest _test;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void Setup()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var sparkReporter = new ExtentSparkReporter($"MoqReport_{timestamp}.html");
            sparkReporter.Config.DocumentTitle = "Test Execution Report";
            sparkReporter.Config.ReportName = "Extent Report Example";

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
            Logger.Info("Moq reporting setup completed.");
        }

        [SetUp]
        public void BeforeTest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Logger.Info($"Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        [Test]
        public void MockedServiceTest()
        {
            // Arrange
            var mockService = new Mock<IExternalService>();
            mockService.Setup(s => s.GetData()).Returns("Mocked Data");

            _test.Log(Status.Info, "Mocked service setup completed.");
            Logger.Info("Mocked service setup completed.");

            // Act
            string result = mockService.Object.GetData();

            _test.Log(Status.Info, $"Service returned: {result}");
            Logger.Info($"Service returned: {result}");

            // Assert
            Assert.That(result, Is.EqualTo("Mocked Datafsghj"));
            _test.Log(Status.Pass, "Test passed.");
            Logger.Info("Test passed.");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _extent.Flush();
            Logger.Info("Moq reporting completed.");
        }
    }
}
