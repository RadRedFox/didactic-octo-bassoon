using Microsoft.AspNetCore.Mvc;

namespace DestifyMovies.Server.Controllers.v1;

[ApiController]
[Route("api/v1/Health")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    internal IActionResult HealthResponse()
    {
        return Ok("okay");
    }

    [HttpGet]
    public IActionResult Get()
    {
        return HealthResponse();
    }

    [HttpPost]
    public IActionResult Post()
    {
        return HealthResponse();
    }
}
