using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Domain.MovieAggregate;

namespace MovieMate.Application.Handlers.Movies
{
    internal class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _movieRepository;
        public CreateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task CreateAsync(Abstractions.Models.Movie movie, CancellationToken cancellationToken = default)
        {
            var movieDomain = movie.ToDomainModel();
            // TODO - validate that movie year of release is valid - only add movies after certain year.
            // TODO - validate that we have not added this movie before - checking the slug

            // ensure that movie.Genres are valid
            await _movieRepository.CreateAsync(movieDomain, cancellationToken);
        }
    }
}
