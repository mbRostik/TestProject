using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PostAPI_Models
{
    public class Post_User
    {
        [Key]
        public string Id { get; set; }
        public List<UserWithPost> UsersWithPosts { get; set; }
    }
}
