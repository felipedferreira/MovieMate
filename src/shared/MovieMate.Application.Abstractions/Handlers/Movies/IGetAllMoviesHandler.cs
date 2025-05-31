using MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Handlers.Movies
{
    public interface IGetAllMoviesHandler
    {
        Task<IEnumerable<Movie>> GetAsync(CancellationToken cancellationToken = default);
    }
}
