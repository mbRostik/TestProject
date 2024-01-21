using Domain.PostAPI_Models;
using Grpc.Net.Client;
using PostService;

namespace Aggregator.Services.PostServices
{
    public class grpcPostService : IgrpcPostService
    {
        public async Task<List<Post>> GetAllPosts()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7225");
            var client = new GrpcPost.GrpcPostClient(channel);
            var request = new GetAllPostsRequest();

            var reply = client.GetAllPost(request);

            List<Post> users = new List<Post>();

            foreach (var user in reply.Post)
            {
                Post temp = new Post();
                temp.Id = user.Id;
                temp.Name = user.Name;
                temp.Description=user.Description;
                users.Add(temp);
            }
            return users;
        }

        public async Task<List<Post_User>> GetAllPost_User()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7225");
            var client = new GrpcPost_User.GrpcPost_UserClient(channel);
            var request = new GetAllPost_UserRequest();

            var reply = client.GetAllPost_User(request);

            List<Post_User> users = new List<Post_User>();

            foreach (var user in reply.PostUser)
            {
                Post_User temp = new Post_User();
                temp.Id = user.Id;
                users.Add(temp);
            }
            return users;
        }
    }
}
