using Application.UseCases.NewAPI.DTOs;
using Domain.NewAPI_Models;
using Domain.PostAPI_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.NewAPI.Commands
{
    public record AddNewCommand(CreationNewDTO model) : IRequest<New>;
}
