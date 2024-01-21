using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PostAPI_Models
{
    public class UserWithPost
    {
        public int Id {  get; set; }
        public Post Post { get; set; }
        public Post_User Post_User { get; set; }
    }
}
