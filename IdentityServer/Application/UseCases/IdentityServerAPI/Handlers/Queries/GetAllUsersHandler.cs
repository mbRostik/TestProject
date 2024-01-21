using Application.UseCases.IdentityServerAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.IdentityServerAPI.Handlers.Queries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<IdentityUser>>
    {
        private readonly UserManager<IdentityUser> manager;

        public GetAllUsersHandler(UserManager<IdentityUser> uof)
        {
            manager = uof;
        }

        public async Task<IEnumerable<IdentityUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return manager.Users;
        }
    }
}