using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SQLContracts.PostAPI
{
    public interface IPostUOW
    {

        Task SaveChangesAsync();
        IPostRepository postRepository { get; set; }

        IUserWithPostRepository userwithpostRepository { get; set; }

        IPost_UserRepository post_userRepository { get; set; }
    }
}