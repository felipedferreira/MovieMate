using MovieMate.Domain.Models;

namespace MovieMate.Application.Abstractions.Services
{
    public interface IMovieRepository
    {
        Task CreateAsync(Movie movie, CancellationToken cancellationToken = default);

        Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Movie> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
