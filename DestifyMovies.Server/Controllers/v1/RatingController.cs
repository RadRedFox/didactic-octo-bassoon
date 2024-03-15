using DestifyMovies.Server.Models;
using DestifyMovies.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DestifyMovies.Server.Controllers.v1;

[ApiController]
[Route("api/v1/Ratings")]
public class RatingController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;
    private readonly ILogger<RatingController> _logger;

    public RatingController(IMovieRepository movieRepository, ILogger<RatingController> logger)
    {
        _movieRepository = movieRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>?>> GetAll()
    {
        var ratings = await _movieRepository.GetRatings();

        return Ok(ratings);
    }

    [HttpGet("{actorId}")]
    public async Task<ActionResult<object?>> GetRating(int ratingId)
    {
        var rating = await _movieRepository.GetRating(ratingId);

        return Ok(rating);
    }

    [HttpPost("add")]
    public async Task<ActionResult<object?>> AddRating(SecureRequest<Rating.RatingPartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();

        var rating = await _movieRepository.AddRating(request.Body);

        return Ok(rating);
    }

    [HttpPatch("update")]
    public async Task<ActionResult<object?>> UpdateActor(SecureRequest<Rating.RatingPartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.Id == null) return BadRequest();

        var updatedRating = await _movieRepository.UpdateRating(request.Body);

        return Ok(updatedRating);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteRating(SecureRequest<Rating.RatingPartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.Id == null) return BadRequest();

        await _movieRepository.RemoveRating((int)request.Body.Id);

        return Ok();
    }
}
