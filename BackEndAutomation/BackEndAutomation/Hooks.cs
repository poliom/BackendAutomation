using BackEndAutomation.Utilities;
using Reqnroll;
using System.Collections;

namespace BackEndAutomation
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Do something only when scenario is tagged with '@tag1'");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            Console.WriteLine("Do something before every scenario, the lowest order is executed first");
        }

        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            ExtentManager.InitReport();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var еxtentTest = ExtentManager.CreateTest("Scenario: " + GetScenarioName(_scenarioContext));
            _scenarioContext["ExtentTest"] = еxtentTest;
            UtilitiesMethods.LogInfoMessage("Starting scenario", _scenarioContext);
            Logger.Log.Info("Starting scenario...");
        }

        [BeforeStep]
        public void BeforeStep()
        {
            UtilitiesMethods.LogInfoMessage("Start executing Step: " + _scenarioContext.StepContext.StepInfo.Text, _scenarioContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Logger.Log.Info("Scenario finished.");
        }

        [AfterTestRun]
        public static void FlushReport()
        {
            ExtentManager.FlushReport();
        }

        private static string GetScenarioName(ScenarioContext context)
        {
            string scenarioParameters = string.Empty;

            foreach (DictionaryEntry entry in context.ScenarioInfo.Arguments)
            {
                scenarioParameters += @"""" + entry.Value.ToString() + @"""" + ", ";
            }

            if (!string.IsNullOrEmpty(scenarioParameters))
            {
                scenarioParameters = "(" + scenarioParameters + "null)";
            }

            string scenarioName = context.ScenarioInfo.Title + scenarioParameters;

            return scenarioName;
        }
    }
}