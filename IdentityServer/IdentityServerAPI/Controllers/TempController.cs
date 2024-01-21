using Application.DTOs;
using Application.UseCases.IdentityServerAPI.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {

        public ILogger<TempController> Logger { get; set;}
        private readonly IMediator mediator;

        public TempController(ILogger<TempController> logger, UserManager<IdentityUser> UserManager)
        {
            Logger = logger;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(UserCreateDTO model)
        {
            Logger.LogInformation("UserCreation");


            var result = await mediator.Send(new AddUserCommand(model));

            return Ok();
        }
    }
}
