using Application.UseCases.NewAPI.Commands;
using Application.UseCases.NewAPI.DTOs;
using Application.UseCases.NewAPI.Queries;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewAPI.Services;

namespace NewAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly IMediator mediator;
        public ITokenService TokenService { get; set; }
        public NewController(IMediator mediator, ITokenService tokenService)
        {
            this.mediator = mediator;
            TokenService = tokenService;
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult> AddNew(CreationNewDTO model)
        {
            var result = await mediator.Send(new AddNewCommand(model));

            return Ok();
        }

        [HttpGet("GetAllNews")]
        public async Task<ActionResult> GetAllNews()
        {
            var result = await mediator.Send(new GetAllNewQuery());

            return Ok(result);
        }

        [HttpGet("CheckPollyNews")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllNewsPolly()
        {
            var result = await mediator.Send(new GetAllNewQuery());

            Random temp = new Random();

            if(temp.Next(1,10) > 5)
            {
                Console.WriteLine("Ooops");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("Okey");

            return Ok(result);
        }

    }
}