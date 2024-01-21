using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.IdentityServerAPI.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<IdentityUser>>;
}
