using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PostAPI_Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserWithPost> UsersWithPosts { get; set; }
    }
}
