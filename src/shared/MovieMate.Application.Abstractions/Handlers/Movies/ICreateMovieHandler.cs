using MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Handlers.Movies
{
    public interface ICreateMovieHandler
    {
        Task<Guid> HandleAsync(Movie movie, CancellationToken cancellationToken);
    }
}
