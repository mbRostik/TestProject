using Domain.PostAPI_Models;

namespace Aggregator.Services.PostServices
{
    public interface IgrpcPostService
    {

        Task<List<Post>> GetAllPosts();

        Task<List<Post_User>> GetAllPost_User();
    }
}
