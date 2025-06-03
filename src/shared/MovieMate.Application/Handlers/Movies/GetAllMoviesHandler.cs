using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services.DataAccess;

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
