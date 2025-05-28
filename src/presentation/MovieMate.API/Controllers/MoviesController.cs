using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetMoviesAsync()
        {
            _logger.LogInformation("Fetching the list of movies");
            // Here you would typically fetch the movies from a service or database
            return Ok(new List<string> { "Movie 1", "Movie 2", "Movie 3" });
        }
    }
}
