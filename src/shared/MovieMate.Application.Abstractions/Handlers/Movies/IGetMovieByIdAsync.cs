using MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Handlers.Movies
{
    public interface IGetMovieByIdAsync
    {
        Task<Movie> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
