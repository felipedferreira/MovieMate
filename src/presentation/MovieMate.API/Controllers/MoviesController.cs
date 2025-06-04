using Microsoft.AspNetCore.Mvc;
using MovieApiEndpoints = MovieMate.API.ApiEndpoints.MovieApiEndpoints;
using MovieMate.API.Contracts.Requests;
using MovieMate.API.Mapping;
using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Handlers.Movies;

namespace MovieMate.API.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpPost(MovieApiEndpoints.Create)]
        public async Task<IActionResult> CreateMovieAsync(
            [FromServices] ICreateMovieHandler handler,
            [FromBody] CreateMovieRequest request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Creating a new Movie");
                var movie = request.ToApplication();
                _logger.LogInformation(MovieApiEndpoints.GetById, movie.Id);
                await handler.CreateAsync(movie, cancellationToken);
                return CreatedAtAction(nameof(GetMovieByIdAsync), new { id = movie.Id }, movie);
            }
            catch (InvalidGenreException ex)
            {
                return BadRequest(new { Genres = ex.InvalidGenreIds });
            }
        }

        [HttpGet(MovieApiEndpoints.GetAll)]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] IGetAllMoviesHandler handler,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching all movies.");
            var movies = await handler.GetAsync(cancellationToken);
            return Ok(movies.Select(ContractMapping.ToResponse));
        }


        [HttpGet(MovieApiEndpoints.GetById)]
        [ActionName(nameof(GetMovieByIdAsync))]
        public async Task<IActionResult> GetMovieByIdAsync(
            [FromRoute] Guid id,
            [FromServices] IGetMovieByIdHandler handler,
            CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching a movie by id.");
                var movie = await handler.GetAsync(id, cancellationToken);
                return Ok(movie.ToResponse());
            }
            catch (NotFoundException)
            {
                return NotFound($"Unable to find movie by id '{id}'.");
            }
        }

        [HttpPut(MovieApiEndpoints.Update)]
        public async Task<IActionResult> UpdateMovieAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateMovieRequest request,
            [FromServices] IUpdateMovieHandler handler,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var movie = request.ToApplication(id);
                await handler.UpdateAsync(movie, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound($"Unable to find movie by id '{id}'.");
            }
        }

        [HttpDelete(MovieApiEndpoints.Delete)]
        public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid id, [FromServices] IDeleteMovieHandler handler, CancellationToken cancellationToken = default)
        {
            try
            {
                await handler.DeleteByIdAsync(id, cancellationToken);
                return Accepted();
            }
            catch (NotFoundException)
            {
                return NotFound($"Unable to find movie by id '{id}'.");
            }
        }
    }
}
