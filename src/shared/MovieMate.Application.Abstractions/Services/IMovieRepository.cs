using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Domain.Models;

namespace MovieMate.Application.Abstractions.Services
{
    public interface IMovieRepository
    {
        Task CreateAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for a movie by its id.
        /// </summary>
        /// <param name="id">id of the Movie</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <exception cref="NotFoundException">Throws NotFoundException if movie is not found</exception>
        /// <returns>Movie</returns>
        Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Movie> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
