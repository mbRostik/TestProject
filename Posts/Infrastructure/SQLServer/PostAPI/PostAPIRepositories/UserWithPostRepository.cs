using Application.SQLContracts.PostAPI;
using Domain.PostAPI_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.PostAPI.PostAPIRepositories
{
    public class UserWithPostRepository : GenericRepository<UserWithPost>, IUserWithPostRepository
    {
        public UserWithPostRepository(PostDBContext databaseContext)
          : base(databaseContext)
        {
        }
    }
}