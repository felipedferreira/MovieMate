using MovieMate.Application.Abstractions.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services;

namespace MovieMate.Application.Handlers.Movies
{
    internal class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _movieRepository;
        public CreateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task CreateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _movieRepository.CreateAsync(movie.ToDomainModel(), cancellationToken);
        }
    }
}
