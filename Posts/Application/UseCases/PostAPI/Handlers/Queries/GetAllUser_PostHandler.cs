using Application.SQLContracts.PostAPI;
using Application.UseCases.PostAPI.Queries;
using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.PostAPI.Handlers.Queries
{
    public class GetAllUser_PostHandler : IRequestHandler<GetAllUser_PostQuery, IEnumerable<Post_User>>
    {
        private readonly IPostUOW UnitOfWork;

        public GetAllUser_PostHandler(IPostUOW uof)
        {
            UnitOfWork = uof;
        }

        public async Task<IEnumerable<Post_User>> Handle(GetAllUser_PostQuery request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.post_userRepository.GetAllAsync();
        }
    }
}