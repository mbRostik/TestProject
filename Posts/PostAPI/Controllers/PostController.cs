using Application.UseCases.PostAPI.Queries;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostAPI.Policies;
using PostAPI.Services;

namespace PostAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ClientPolicy _clientPolicy;

        public ITokenService TokenService { get; set; }
        public PostController(IMediator mediator, ITokenService rTokenService, ClientPolicy clientPolicy) 
        {
            this.mediator = mediator;
            this.TokenService = rTokenService;
            this._clientPolicy = clientPolicy;
        }

        [HttpGet("GetAllPost_User")]
        public async Task<ActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllUser_PostQuery());

            return Ok(result);
        }

        [HttpGet("GetNews")]
        public async Task<ActionResult> GetNews()
        {
            using var httpClient = new HttpClient();
            var tokenResponse = await TokenService.GetToken("newAPI.read");
            httpClient.SetBearerToken(tokenResponse.AccessToken);
            var result = await httpClient.GetAsync("http://localhost:5155/New/GetAllNews");

            if (result.IsSuccessStatusCode)
            {
                return Ok(await result.Content.ReadAsStringAsync());
            }



            return Ok("Smth went wrong (GetTheLatest)");
        }

        [HttpGet("CheckPolly")]
        [AllowAnonymous]
        public async Task<ActionResult> CheckPolly()
        {
            using var httpClient = new HttpClient();
           


            var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(()
           => httpClient.GetAsync("http://localhost:5155/New/CheckPollyNews"));

            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsStringAsync());
            }



            return Ok("Smth went wrong (CheckPolly)");
        }

    }
}
