using DestifyMovies.Server.Models;
using DestifyMovies.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace DestifyMovies.Server.Controllers.v1;

[ApiController]
[Route("api/v1/Movies")]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;
    private readonly ILogger<MoviesController> _logger;

    public MoviesController(IMovieRepository movieRepository, ILogger<MoviesController> logger)
    {
        _movieRepository = movieRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<Movie[]>> GetAll()
    {
        var movies = await _movieRepository.GetMovies();

        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    public async Task<ActionResult<Movie>> GetMovie(int movieId)
    {
        var movie = await _movieRepository.GetMovie(movieId);

        return Ok(movie);
    }

    [HttpPost("add")]
    public async Task<ActionResult<Movie?>> AddMovie(SecureRequest<Movie.MoviePartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();

        var movie = await _movieRepository.AddMovie(request.Body);

        return Ok(movie);
    }

    [HttpPatch("update")]
    public async Task<ActionResult<object?>> UpdateMovie(SecureRequest<Movie.MoviePartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.Id == null) return BadRequest();

        var updatedMovie = await _movieRepository.UpdateMovie(request.Body);

        return Ok(updatedMovie);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteMovie(SecureRequest<Movie.MoviePartial> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.Id == null) return BadRequest();

        await _movieRepository.RemoveMovie((int)request.Body.Id);

        return Ok();
    }

    [HttpDelete("removeActor")]
    public async Task<ActionResult<object?>> RemoveActor(SecureRequest<Movie.RemoveActorRequest> request)
    {
        if (!request.ValidateKey()) return Unauthorized();
        if (request.Body?.MovieId == null || request.Body?.ActorId == null) return BadRequest();

        var movie = await _movieRepository.RemoveActorFromMovie(request.Body.MovieId, request.Body.ActorId);

        return Ok(movie);
    }
}
