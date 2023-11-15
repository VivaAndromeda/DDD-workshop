using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers;

[ApiController]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    [Route("api/hello")]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}
