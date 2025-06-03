using Microsoft.AspNetCore.Mvc;
using MovieMate.API.Contracts.Requests;
using MovieMate.API.Mapping;
using MovieMate.Application.Abstractions.Handlers.Genres;
using static MovieMate.API.ApiEndpoints;

namespace MovieMate.API.Controllers
{
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        public GenresController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpPost(GenreApiEndpoints.Create)]
        public async Task<IActionResult> CreateAsync(
            [FromServices] ICreateGenreHandler handler,
            [FromBody] CreateGenreRequest request,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating a new Genre");
            var genre = request.ToApplication();
            await handler.CreateAsync(genre, cancellationToken);
            return Created();
        }

        [HttpGet(GenreApiEndpoints.GetAll)]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] IGetAllGenreHandler handler,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching all genres.");
            var genres = await handler.GetAllGenresAsync(cancellationToken);
            return Ok(genres.Select(ContractMapping.ToResponse));
        }
    }
}
