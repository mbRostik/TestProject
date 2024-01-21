using Microsoft.AspNetCore.Identity;
using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.UseCases.IdentityServerAPI.Commands
{
    public record AddUserCommand(UserCreateDTO model) : IRequest<IdentityUser>;
}
