using Application.DTOs;
using Application.UseCases.IdentityServerAPI.Commands;
using Application.UseCases.IdentityServerAPI.Notifications;
using Infrastructure.SQLServer.IdentityServerAPI;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.IdentityServerAPI.Handlers.Creation
{
    public class UserCreatedHandler : IRequestHandler<AddUserCommand, IdentityUser>
    {
        private readonly UserManager<IdentityUser> manager;
        private readonly IMediator _mediator;

        public UserCreatedHandler(UserManager<IdentityUser> _uow, IMediator mediator)
        {
            manager = _uow;
            _mediator = mediator;
        }

        public async Task<IdentityUser> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser temp = new IdentityUser();
            temp.UserName = request.model.Name;
            temp.Email = request.model.Email;

            var result = await manager.CreateAsync(temp, request.model.Password);

            if(!result.Succeeded)
            {
                Console.WriteLine("The user was not created. The problem somewhere in UserCreatedHandler");
            }
            
            IdentityUser t = await manager.FindByEmailAsync(request.model.Email);

            Console.WriteLine("The item was created and the notification was sent");
            await _mediator.Publish(new UserCreatedNotification(t), cancellationToken);

            return t;
        }
    }
}