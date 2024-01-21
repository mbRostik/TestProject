using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus.Messages.User
{
    public class UserCreatedEvent: IntegrationBaseEvent
    {
        public string UserId {  get; set; }
    }
}
