﻿using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;

namespace BackEndAutomation.Tests
{
    [TestFixture]
    public class ExtentReportingExample
    {
        private static ExtentReports _extent;
        private ExtentTest _test;

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
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [Test]
        public void SuccessfulTest()
        {
            _test.Log(Status.Info, "This is a successful test.");
            Assert.That(1 + 1, Is.EqualTo(2));
            _test.Log(Status.Pass, "Test passed successfully.");
        }

        [Test]
        public void FailingTest()
        {
            _test.Log(Status.Info, "This is a failing test.");
            if ((1 + 1) != 3)
            {
                _test.Log(Status.Fail, "Test failed.");
            }
            Assert.That(1 + 1, Is.EqualTo(3));
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            _extent.Flush();
        }
    }
}
