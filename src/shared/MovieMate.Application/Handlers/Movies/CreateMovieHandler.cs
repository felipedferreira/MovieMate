using MovieMate.Application.Abstractions.Handlers.Movies;

namespace MovieMate.Application.Handlers.Movies
{
    internal class CreateMovieHandler : ICreateMovieHandler
    {
        public async Task HandleAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(5_000, cancellationToken);
        }
    }
}
