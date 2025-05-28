using Microsoft.AspNetCore.Mvc;
using MovieMate.Application.Abstractions.Handlers.Movies;

namespace MovieMate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync([FromServices] ICreateMovieHandler handler, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching the list of movies");
            await handler.HandleAsync(cancellationToken);
            // Here you would typically fetch the movies from a service or database
            return Ok(new List<string> { "Movie 1", "Movie 2", "Movie 3" });
        }
    }
}
