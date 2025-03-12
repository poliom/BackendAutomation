using AventStack.ExtentReports;
using NUnit.Framework;
using Reqnroll;

namespace BackEndAutomation.Utilities
{
    public class UtilitiesMethods
    {
        public static void AssertEqual<T>(T expected, T actual, string message, ScenarioContext scenarioContext)
        {
            ExtentTest _test = scenarioContext.Get<ExtentTest>("ExtentTest");

            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                Logger.Log.Error(message ?? $"Expected: {expected}, but was: {actual}");
                _test.Log(Status.Fail, message ?? $"Expected: {expected}, but was: {actual}");
                Assert.Fail(message ?? $"Expected: {expected}, but was: {actual}");
            }
        }

        public static void LogInfoMessage(string message, ScenarioContext scenarioContext)
        {
            ExtentTest _test = scenarioContext.Get<ExtentTest>("ExtentTest");
            _test.Log(Status.Info, message);
        }
    }
}
