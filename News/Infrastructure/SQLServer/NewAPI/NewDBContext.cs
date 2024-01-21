using Domain.NewAPI_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer.NewAPI
{
    public class NewDBContext : DbContext
    {
        public NewDBContext() { }
        public NewDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<New> news { get; set; }
    }
}