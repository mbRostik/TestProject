using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.PostAPI.Queries
{
    public record GetAllUser_PostQuery() : IRequest<IEnumerable<Post_User>>;
}
