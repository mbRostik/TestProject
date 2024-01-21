using Application.SQLContracts.NewAPI;
using Domain.NewAPI_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.NewAPI.NewAPIRepositories
{
    public class NewRepository : GenericRepository<New>, INewRepository
    {
        public NewRepository(NewDBContext databaseContext)
          : base(databaseContext)
        {
        }
    }
}
