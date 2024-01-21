using Aggregator.Services.PostServices;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IgrpcPostService postService;

        public MainController(IgrpcPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("GetAllPost_User")]
        public async Task<ActionResult> GetAllPost_User()
        {
            var result = await postService.GetAllPost_User();
            return Ok(result);
        }

        [HttpGet("Posts")]
        public async Task<ActionResult> Posts()
        {
            var result = await postService.GetAllPosts();
            return Ok(result);
        }

        [HttpGet("AAA")]
        public async Task<ActionResult> A()
        {
            Console.WriteLine("ALLALALALLALALALA");
            return Ok("AHAHHAHAHAHAHA");
        }
    }
}
