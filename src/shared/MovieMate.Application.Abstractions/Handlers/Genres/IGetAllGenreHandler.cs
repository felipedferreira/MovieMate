using MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Handlers.Genres
{
    public interface IGetAllGenreHandler
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken = default);
    }
}
