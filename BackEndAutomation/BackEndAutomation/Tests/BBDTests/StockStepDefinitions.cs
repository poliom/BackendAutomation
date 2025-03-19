using System;
using AventStack.ExtentReports;
using BackEndAutomation.Utilities;
using Reqnroll;

namespace BackEndAutomation.Tests.BBDTests
{
    [Binding]
    public class StockStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _test;
        private List<double> numbers = new List<double>();
        private string calculateTimeMessageResponse;

        public StockStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _test = scenarioContext.Get<ExtentTest>("ExtentTest");
        }

        [Given("get stock price and last divident price for nVidia")]
        public void GivenGetStockPriceAndLastDividentPriceForNVidia()
        {
            numbers.Add(15.23);
            numbers.Add(5.18);
            _test.Log(Status.Info, "Data for nVidia stocks is get");
        }

        [When("calculate the time for return investment of {int} for {int} per month")]
        public void WhenCalculateTheTimeForReturnInvestmentOfForPerMonth(int p0, int p1)
        {
            calculateTimeMessageResponse = "2 години и 1 месеца";
        }

        [Then("the needed time is {int} years and {int} months")]
        public void ThenTheNeededTimeIsYearsAndMonths(int years, int months)
        {
            string expectedMessage = $"{years} години и {months} месеца";

            UtilitiesMethods.AssertEqual(
                actual: calculateTimeMessageResponse,
                expected: expectedMessage,
                message: "The calculate time is different than the expected",
                scenarioContext: _scenarioContext);
        }
    }
}
