using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Domain.MovieAggregate.MovieAggregate;
using Movie = MovieMate.Application.Abstractions.Models.Movie;

namespace MovieMate.Application.Handlers.Movies
{
    internal class GetAllMoviesHandler : IGetAllMoviesHandler
    {
        private readonly IMovieQuery _movieQuery;
        public GetAllMoviesHandler(IMovieQuery movieQuery)
        {
            _movieQuery = movieQuery;
        }

        public async Task<IEnumerable<Movie>> GetAsync(CancellationToken cancellationToken = default)
        {
            var movies = await _movieQuery.GetAllAsync(cancellationToken);
            return movies.Select(ApplicationMappingExtensions.ToApplicationModel);
        }
    }
}
