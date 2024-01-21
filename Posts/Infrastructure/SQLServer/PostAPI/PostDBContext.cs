using Domain.NewAPI_Models;
using Domain.PostAPI_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.PostAPI
{
    public class PostDBContext : DbContext
    {
        public PostDBContext() { }
        public PostDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Post> posts { get; set; }

        public DbSet<Post_User> post_Users { get; set; }

        public DbSet<UserWithPost> userwithposts {  get; set; }
    }
}