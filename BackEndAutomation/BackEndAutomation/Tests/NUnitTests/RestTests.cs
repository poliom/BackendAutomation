using BackEndAutomation.Rest.Calls;
using BackEndAutomation.Rest.DataManagement;
using NUnit.Framework;
using RestSharp;

namespace BackEndAutomation.Tests.NUnitTests
{
    [TestFixture, Parallelizable(ParallelScope.Children)]
    public class RestTests
    {
        [Test]
        public void LoginRestTest()
        {
            Thread.Sleep(5200);
            RestCalls restCalls = new RestCalls();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            Assert.That(userDetailsResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        }

        [Test]
        public void LoginRestTestFail()
        {
            Thread.Sleep(15200);
            RestCalls restCalls = new RestCalls();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            Assert.That(userDetailsResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
        }

        [Test]
        public void PersonalDetailsRestTest()
        {
            Thread.Sleep(5200);
            RestCalls restCalls = new RestCalls();
            ResponseDataExtractors extractResponseData = new ResponseDataExtractors();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            if (userDetailsResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                Assert.Fail("User is not logged in");
            }

            string token = extractResponseData.ExtractLoggedInUserToken(userDetailsResponse.Content);
            string userId = extractResponseData.ExtractUserId(userDetailsResponse.Content).ToString();

            RestResponse userProfileDetailsResponse = restCalls.GetUserPageInformationCall("http://161.35.202.130:3000", userId, token);
            Assert.That(userProfileDetailsResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public void FollowUserRestTest()
        {
            Thread.Sleep(3200);
            RestCalls restCalls = new RestCalls();
            ResponseDataExtractors extractResponseData = new ResponseDataExtractors();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            if (userDetailsResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                Assert.Fail("User is not logged in");
            }

            string token = extractResponseData.ExtractLoggedInUserToken(userDetailsResponse.Content);
            string userId = extractResponseData.ExtractUserId(userDetailsResponse.Content).ToString();

            RestResponse userFollowResponse = restCalls.ToFollowUser("http://161.35.202.130:3000", "8335", token, true);
            Assert.That(userFollowResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public void UnfollowUserRestTest()
        {
            Thread.Sleep(8700);
            RestCalls restCalls = new RestCalls();
            ResponseDataExtractors extractResponseData = new ResponseDataExtractors();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            if (userDetailsResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                Assert.Fail("User is not logged in");
            }

            string token = extractResponseData.ExtractLoggedInUserToken(userDetailsResponse.Content);
            string userId = extractResponseData.ExtractUserId(userDetailsResponse.Content).ToString();

            RestResponse userFollowResponse = restCalls.ToFollowUser("http://161.35.202.130:3000", "8335", token, false);
            Assert.That(userFollowResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public void randomAPItest()
        {
            Thread.Sleep(8520);
            RestCalls restCalls = new RestCalls();
            RestResponse response = restCalls.generalRestCall("https://restcountries.com/v3.1", "/all?fields=name", Method.Get);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
    }
}
