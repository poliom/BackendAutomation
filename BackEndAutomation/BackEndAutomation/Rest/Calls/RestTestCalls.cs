using BackEndAutomation.Rest.DataManagement;
using RestSharp;

namespace BackEndAutomation.Rest.Calls
{
    public class RestTestCalls
    {
        public static void RestLoginTestsCalls()
        {
            RestCalls restCalls = new RestCalls();
            ResponseDataExtractors extractResponseData = new ResponseDataExtractors();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            if (userDetailsResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine("User is logged in:");
                Console.WriteLine(userDetailsResponse.Content);
            }
            else
            {
                Console.WriteLine("User is not logged in:");
                Console.WriteLine(userDetailsResponse.Content);
            }
            // -----------------------------------------
            RestResponse userDetailsResponseBadRequest = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "afgawqfdafa");
            if (userDetailsResponseBadRequest.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine("User is logged in:");
                Console.WriteLine(userDetailsResponseBadRequest.Content);
            }
            else
            {
                Console.WriteLine("User is not logged in:");
                Console.WriteLine(userDetailsResponseBadRequest.Content);
            }
            // -----------------------------------------
        }
        public static void RestProfileDetailsTestsCalls()
        {
            RestCalls restCalls = new RestCalls();
            ResponseDataExtractors extractResponseData = new ResponseDataExtractors();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            if (userDetailsResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine("User is logged in:");
                Console.WriteLine(userDetailsResponse.Content);
            }
            else
            {
                Console.WriteLine("User is not logged in:");
                Console.WriteLine(userDetailsResponse.Content);
            }
            // -----------------------------------------
            string token = extractResponseData.ExtractLoggedInUserToken(userDetailsResponse.Content);
            string userId = extractResponseData.ExtractUserId(userDetailsResponse.Content).ToString();

            RestResponse userProfileDetailsResponse = restCalls.GetUserPageInformationCall("http://161.35.202.130:3000", userId, token);
            if (userProfileDetailsResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("User profile details are:");
                Console.WriteLine(userProfileDetailsResponse.Content);
            }
            else
            {
                Console.WriteLine("Problem getting user details");
                Console.WriteLine(userProfileDetailsResponse.Content);
            }
            // -----------------------------------------
        }
        public static void RestFollowUnfollowProfileTestCalls()
        {
            RestCalls restCalls = new RestCalls();
            ResponseDataExtractors extractResponseData = new ResponseDataExtractors();

            RestResponse userDetailsResponse = restCalls.LoginCall("http://161.35.202.130:3000", "dbsdhsh", "sdhshs");
            if (userDetailsResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine("User is logged in:");
                Console.WriteLine(userDetailsResponse.Content);
            }
            else
            {
                Console.WriteLine("User is not logged in:");
                Console.WriteLine(userDetailsResponse.Content);
            }
            // -----------------------------------------
            string token = extractResponseData.ExtractLoggedInUserToken(userDetailsResponse.Content);
            string userId = extractResponseData.ExtractUserId(userDetailsResponse.Content).ToString();

            RestResponse userFollowResponse = restCalls.ToFollowUser("http://161.35.202.130:3000", "8335", token, true);
            if (userFollowResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("User is followed:");
                Console.WriteLine(userFollowResponse.Content);
            }
            else
            {
                Console.WriteLine("Problem following user");
                Console.WriteLine(userFollowResponse.Content);
            }
            // -----------------------------------------
            RestResponse userUnFollowResponse = restCalls.ToFollowUser("http://161.35.202.130:3000", "8335", token, false);
            if (userUnFollowResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("User is unfollowed:");
                Console.WriteLine(userUnFollowResponse.Content);
            }
            else
            {
                Console.WriteLine("Problem unfollowing user");
                Console.WriteLine(userUnFollowResponse.Content);
            }
            // -----------------------------------------
        }
    }
}
