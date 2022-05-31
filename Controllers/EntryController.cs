using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [TypeFilter(typeof(MyAsyncFilter))]
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;

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
            await Task.Delay(5000);

            String? count = this.Request.Headers["onx-count"].FirstOrDefault();

            return Ok($"'{count}' (post)");
        }
    }
}