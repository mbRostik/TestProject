using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SQLContracts.NewAPI
{
    public interface INewUOW
    {
        Task SaveChangesAsync();
        INewRepository newRepository { get; set; }
    }
}
