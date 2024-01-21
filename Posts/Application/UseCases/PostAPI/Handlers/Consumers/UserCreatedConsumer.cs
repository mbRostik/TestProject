using Application.UseCases.PostAPI.Commands;
using Domain.PostAPI_Models;
using MassTransit;
using MediatR;
using MessageBus.Messages.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.PostAPI.Handlers.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
    {
        private readonly IMediator mediator;
        public UserCreatedConsumer(IMediator _mediator)
        {
            mediator = _mediator;

        }
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            Post_User temp = new Post_User();
            temp.Id=context.Message.UserId;

            await mediator.Send(new AddPost_UserCommand(temp));
            Console.WriteLine("We have passed the UserCreatedConsumer");
            await Task.CompletedTask;
        }
    }
}