using MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Handlers.Genres
{
    public interface ICreateGenreHandler
    {
        Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);
    }
}
