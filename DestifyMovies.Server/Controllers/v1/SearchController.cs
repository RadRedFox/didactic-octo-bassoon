using DestifyMovies.Server.Models;
using DestifyMovies.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DestifyMovies.Server.Controllers.v1;

[ApiController]
[Route("api/v1/Search")]
public class SearchController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;
    private readonly ILogger<SearchController> _logger;

    public SearchController(IMovieRepository movieRepository, ILogger<SearchController> logger)
    {
        _movieRepository = movieRepository;
        _logger = logger;
    }

    [HttpGet("{searchTerm}")]
    public async Task<ActionResult<SearchResults>> Search(string searchTerm)
    {
        var searchResult = await _movieRepository.Search(searchTerm);

        return Ok(searchResult);
    }
}
