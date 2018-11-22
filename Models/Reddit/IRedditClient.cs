using System.Threading.Tasks;

namespace NetCore.Web.Models.Reddit
{
    public interface IRedditClient
    {
        Task<SubReddit> GetSubReddit(string subRedditName);
    }
}