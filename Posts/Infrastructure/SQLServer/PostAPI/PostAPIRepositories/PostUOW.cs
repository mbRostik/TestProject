using Application.SQLContracts.PostAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.PostAPI.PostAPIRepositories
{
    public class PostUOW : IPostUOW
    {

        public IPostRepository postRepository { get; set; }

        public PostDBContext databaseContext { get; set; }
        public IUserWithPostRepository userwithpostRepository { get; set; }
        public IPost_UserRepository post_userRepository { get; set; }

        public PostUOW(PostDBContext databaseContext, IPostRepository userRepository, IPost_UserRepository post_userRepository, IUserWithPostRepository userwithpostRepository)
        {
            this.databaseContext = databaseContext;

            this.userwithpostRepository = userwithpostRepository;
            this.post_userRepository = post_userRepository;
            this.postRepository = userRepository;
        }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
