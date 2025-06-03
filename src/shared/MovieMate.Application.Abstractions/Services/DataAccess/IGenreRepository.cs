using MovieMate.Domain.Models;

namespace MovieMate.Application.Abstractions.Services.DataAccess
{
    public interface IGenreRepository
    {
        Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);
    }
}
