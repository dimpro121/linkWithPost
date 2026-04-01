using linqWithPost.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace linqWithPost.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IActionResult TestClick([FromBody] TestRequest request)
        {
            return Ok(new {Message = "Успешный клик"});
        }
    }
}
