using Application.UseCases.IdentityServerAPI.Notifications;
using MassTransit;
using MediatR;
using MessageBus.Messages.User;

namespace Application.UseCases.IdentityServerAPI.Handlers.Notify
{
    public class UserCreatedNotificationHandler : INotificationHandler<UserCreatedNotification>
    {
        private readonly IPublishEndpoint _publisher;

        public UserCreatedNotificationHandler(
           IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            UserCreatedEvent productCreatedEvent = new UserCreatedEvent();
            productCreatedEvent.UserId = notification.user.Id;
            Console.WriteLine("Publishing User Created Event");
            await _publisher.Publish(productCreatedEvent);
        }
    }
}