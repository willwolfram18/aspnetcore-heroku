using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore.Web.Models.Reddit
{
    public class RedditClient : IRedditClient
    {
        private readonly HttpClient _client;

        public RedditClient(HttpClient client, RedditClientOptions options)
        {
            _client = client;
            Console.WriteLine($"Locale is {options.Locale}");
        }

        public async Task<SubReddit> GetSubReddit(string subRedditName)
        {
            var response = await _client.GetAsync($"r/{subRedditName}.json");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<SubReddit>();
        }
    }
}