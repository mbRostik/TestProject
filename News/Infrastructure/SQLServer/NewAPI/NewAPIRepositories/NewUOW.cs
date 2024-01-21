using Application.SQLContracts.NewAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.NewAPI.NewAPIRepositories
{
    public class NewUOW : INewUOW
    {

        public INewRepository newRepository { get; set; }

        public NewDBContext databaseContext { get; set; }

        public NewUOW(NewDBContext databaseContext, INewRepository userRepository)
        {
            this.databaseContext = databaseContext;

            this.newRepository = userRepository;
        }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
