using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;

        private static uint _count = 0;

        public EntryController(ILogger<EntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult
        Get()
        {
            String? count = this.Request.Headers["onx-count"].FirstOrDefault();

            return Ok($"'{count}' (get)");
        }

        [HttpPost]
        public async Task<IActionResult>
        Post([FromForm] String otherField, [FromForm] IFormFile fileContent)
        {
            await Task.Delay(500);

            String? count = this.Request.Headers["onx-count"].FirstOrDefault();

            return Ok($"'{count}' (post)");
        }
    }
}