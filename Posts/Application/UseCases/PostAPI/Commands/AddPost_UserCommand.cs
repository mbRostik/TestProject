using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.PostAPI.Commands
{
    public record AddPost_UserCommand(Post_User model) : IRequest<Post_User>;
}
