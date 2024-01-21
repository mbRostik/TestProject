using Domain.NewAPI_Models;
using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.NewAPI.Queries
{
    public record GetAllNewQuery() : IRequest<IEnumerable<New>>;
}
