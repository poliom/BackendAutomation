using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAutomation.Rest.Calls
{
    public class RestCalls
    {
        public RestResponse LoginCall(string url, string username, string password, bool rememberMe = false)
        {
            RestClientOptions options = new RestClientOptions(url)
            {
                Timeout = TimeSpan.FromSeconds(120),
            };

            RestClient client = new RestClient(options);

            RestRequest request = new RestRequest("/users/login", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            string body = @"{""usernameOrEmail"":""" + username + @""",""password"":""" + password + @""",""rememberMe"":""" + rememberMe.ToString().ToLower() + @"""}";

            request.AddStringBody(body, DataFormat.Json);

            RestResponse response = client.Execute(request);

            return response;
        }

        public RestResponse GetUserPageInformationCall(string url, string userId, string token)
        {
            RestClientOptions options = new RestClientOptions(url)
            {
                Timeout = TimeSpan.FromSeconds(120),
            };
            RestClient client = new RestClient(options);

            RestRequest request = new RestRequest($"/users/{userId}", Method.Get);

            request.AddHeader("Authorization", $"Bearer {token}");

            RestResponse response = client.Execute(request);

            return response;
        }

        public RestResponse ToFollowUser(string url, string userIdToFollow, string token, bool isFollowed)
        {
            string toFollowCommand = isFollowed ? "followUser" : "unfollowUser";

            RestClientOptions options = new RestClientOptions(url)
            {
                Timeout = TimeSpan.FromSeconds(120),
            };

            RestClient client = new RestClient(options);

            RestRequest request = new RestRequest($"/users/{userIdToFollow}", Method.Patch);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");

            string body = @"{""action"":""" + toFollowCommand + @"""}";

            request.AddStringBody(body, DataFormat.Json);

            RestResponse response = client.Execute(request);

            return response;
        }

        public void restPostman()
        {

            RestClientOptions options = new RestClientOptions("http://161.35.202.130:3000")
            {
                Timeout = TimeSpan.FromSeconds(120),
            };
            var client = new RestClient(options);
            var request = new RestRequest("/users/login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{""usernameOrEmail"":""vidko.v"",""password"":""123abc"",""rememberMe"":false}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        public RestResponse generalRestCall(string baseUrl, string endpoint, Method method)
        {

            RestClientOptions options = new RestClientOptions(baseUrl)
            {
                Timeout = TimeSpan.FromSeconds(120),
            };
            RestClient client = new RestClient(options);
            RestRequest request = new RestRequest(endpoint, method);
            RestResponse response = client.Execute(request);

            return response;
        }
    }
}
