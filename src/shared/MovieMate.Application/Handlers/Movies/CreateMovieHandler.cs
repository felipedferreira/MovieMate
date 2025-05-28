using MovieMate.Application.Abstractions.Handlers.Movies;
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
        public async Task HandleAsync(CancellationToken cancellationToken = default)
        {
            _movieRepository.CreateAsync();
            await Task.Delay(5_000, cancellationToken);
        }
    }
}
