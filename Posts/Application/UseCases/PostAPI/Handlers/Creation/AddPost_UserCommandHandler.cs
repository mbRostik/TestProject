using Application.SQLContracts.PostAPI;
using Application.UseCases.PostAPI.Commands;
using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.PostAPI.Handlers.Creation
{
    public class AddPost_UserCommandHandler : IRequestHandler<AddPost_UserCommand, Post_User>
    {
        private readonly IPostUOW uow;
        private readonly IMediator _mediator;

        public AddPost_UserCommandHandler(IPostUOW _uow, IMediator mediator)
        {
            uow = _uow;
            _mediator = mediator;
        }

        public async Task<Post_User> Handle(AddPost_UserCommand request, CancellationToken cancellationToken)
        {

            await uow.post_userRepository.AddAsync(request.model);
            await uow.SaveChangesAsync();

            return request.model;
        }
    }
}