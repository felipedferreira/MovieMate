using MovieMate.Application.Abstractions.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services;

namespace MovieMate.Application.Handlers.Movies
{
    internal class GetAllMoviesHandler : IGetAllMoviesHandler
    {
        private readonly IMovieRepository _movieRepository;
        public GetAllMoviesHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var movies = await _movieRepository.GetAllAsync(cancellationToken);
            return movies.Select(ApplicationMappingExtensions.ToApplicationModel);
        }
    }
}
