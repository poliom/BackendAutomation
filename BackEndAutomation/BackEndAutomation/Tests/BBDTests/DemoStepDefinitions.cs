using NUnit.Framework;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAutomation.Tests.BBDTests
{
    [Binding]
    public class DemoStepDefinitions
    {
        List<int> numbers = new List<int>();

        [Given("open the calculator")]
        public void GivenOpenTheCalculator()
        {
            Console.WriteLine("Calculator is open");
        }

        [When("click {int} number")]
        public void WhenClickNumber(int number)
        {
            numbers.Add(number);
            Console.WriteLine("Click on number: " + number);
        }

        [When("click + action")]
        public void WhenClickSumAction()
        {
            Console.WriteLine("Click on + action on calculator");
        }

        [When("click = action")]
        public void WhenClickEndAction()
        {
            Console.WriteLine("Click on = action on calculator");
        }

        [Then("the calculator shows \"(.*)\"")]
        public void ThenTheCalculatorShows(string p0)
        {
            int sum = numbers.Sum();
            Assert.That(sum.ToString, Is.EqualTo(p0), "The sum is not as expected, please check the input values");
        }

        [Then("the calculator shows \"(.*)\", or show the \"(.*)\" error message")]
        public void ThenTheCalculatorShows(string number, string errorMessage)
        {
            int sum = numbers.Sum();
            string sumString = sum.ToString();

            Assert.That(sum.ToString, Is.EqualTo(number), errorMessage.Replace("REPLACEWITHACTUALSUM",sumString));
        }

    }
}
