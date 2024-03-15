using DestifyMovies.Server.Models;
using DestifyMovies.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DestifyMovies.Server.Controllers.v1;

[ApiController]
[Route("api/v1/Actors")]
public class ActorsController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;
    private readonly ILogger<ActorsController> _logger;

    public ActorsController(IMovieRepository movieRepository, ILogger<ActorsController> logger)
    {
        _movieRepository = movieRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>?>> GetAll()
    {
        var actors = await _movieRepository.GetActors();

        return Ok(actors);
    }

    [HttpGet("{actorId}")]
    public async Task<ActionResult<object?>> GetActor(int actorId)
    {
        var actor = await _movieRepository.GetActor(actorId);

        return Ok(actor);
    }

    [HttpPost("add")]
    public async Task<ActionResult<object?>> AddActor(SecureRequest<Actor.ActorPartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();

        var actor = await _movieRepository.AddActor(request.Body);

        return Ok(actor);
    }

    [HttpPatch("update")]
    public async Task<ActionResult<object?>> UpdateActor(SecureRequest<Actor.ActorPartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.Id == null) return BadRequest();

        var updatedActor = await _movieRepository.UpdateActor(request.Body);

        return Ok(updatedActor);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteActor(SecureRequest<Actor.ActorPartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.Id == null) return BadRequest();

        await _movieRepository.RemoveActor((int)request.Body.Id);

        return Ok();
    }
}
