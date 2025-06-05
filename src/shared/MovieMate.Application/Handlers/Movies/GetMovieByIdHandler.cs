using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Domain.MovieAggregate.MovieAggregate;
using Movie = MovieMate.Application.Abstractions.Models.Movie;

namespace MovieMate.Application.Handlers.Movies
{
    internal class GetMovieByIdHandler : IGetMovieByIdHandler
    {
        private readonly IMovieQuery _movieQuery;
        public GetMovieByIdHandler(IMovieQuery movieQuery)
        {
            _movieQuery = movieQuery;
        }

        public async Task<Movie> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = await _movieQuery.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Movie with ID {id} not found.");
            return movie.ToApplicationModel();
        }
    }
}
