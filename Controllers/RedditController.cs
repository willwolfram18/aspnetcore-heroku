using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Web.Models.Reddit;

namespace NetCore.Web.Controllers
{
    [ApiController]
    [Route("reddit")]
    public class RedditController : Controller
    {
        private readonly IRedditClient _client;

        public RedditController(IRedditClient client)
        {
            _client = client;
        }

        [Route("r/{subReddit}")]
        public async Task<IActionResult> Get(string subReddit)
        {
            return Ok(await _client.GetSubReddit(subReddit));
        }
    }
}