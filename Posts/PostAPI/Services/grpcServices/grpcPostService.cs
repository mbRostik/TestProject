using PostService;
using Grpc.Core;
using PostService;
using Application.SQLContracts.PostAPI;
namespace PostAPI.Services.grpcServices
{
    public class grpcPostService : GrpcPost.GrpcPostBase
    {
        private IPostUOW uow {  get; set; }

        public grpcPostService(IPostUOW uow)
        {
            this.uow = uow;
        }

        public override async Task<PostResponse> GetAllPost(GetAllPostsRequest request, ServerCallContext context)
        {
            var response = new PostResponse();

            var models = await uow.postRepository.GetAllAsync();

            foreach (var model in models)
            {
                GrpcPostModel temp = new GrpcPostModel();
                temp.Description= model.Description;
                temp.Id = model.Id;
                temp.Name = model.Name;

                response.Post.Add(temp);
            }

            return await Task.FromResult(response);
        }
    }
}
