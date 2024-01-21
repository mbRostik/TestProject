using Application.SQLContracts.PostAPI;
using Grpc.Core;
using PostService;

namespace PostAPI.Services.grpcServices
{
    public class grpcPost_UserService: GrpcPost_User.GrpcPost_UserBase
    {
        private IPostUOW uow { get; set; }

        public grpcPost_UserService(IPostUOW uow)
        {
            this.uow = uow;
        }

        public override async Task<Post_UserResponse> GetAllPost_User(GetAllPost_UserRequest request, ServerCallContext context)
        {
            var response = new Post_UserResponse();

            var models = await uow.post_userRepository.GetAllAsync();

            foreach (var model in models)
            {
                GrpcPost_UserModel temp = new GrpcPost_UserModel();
                temp.Id = model.Id;

                response.PostUser.Add(temp);
            }

            return await Task.FromResult(response);
        }
    }
}
