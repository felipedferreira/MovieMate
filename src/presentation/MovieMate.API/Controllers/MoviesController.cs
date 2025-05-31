using System.Threading;
using Microsoft.AspNetCore.Mvc;
using MovieMate.API.Contracts.Requests;
using MovieMate.API.Mapping;
using MovieMate.Application.Abstractions.Exceptions;
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

        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync([FromServices] ICreateMovieHandler handler, [FromBody] CreateMovieRequest request ,CancellationToken cancellationToken = default)
        {
            var id = await handler.CreateAsync(request.ToApplication(), cancellationToken);
            // Here you would typically fetch the movies from a service or database
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromServices] IGetAllMoviesHandler handler, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching the list of movies");
            var movies = await handler.GetAsync(cancellationToken);
            // Here you would typically fetch the movies from a service or database
            return Ok(movies);
        }


        [HttpGet("id:guid")]
        public async Task<IActionResult> GetMovieByIdAsync(Guid id, [FromServices] IGetMovieByIdAsync handler, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching movie by id");
                var movie = await handler.GetAsync(id, cancellationToken);
                return Ok(movie);
            }
            catch (NotFoundException)
            {
                return NotFound($"Movie with ID {id} not found.");
            }
        }
    }
}
