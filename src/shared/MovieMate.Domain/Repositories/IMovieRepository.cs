using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Domain.Models;

namespace MovieMate.Application.Abstractions.Services.DataAccess
{
    public interface IMovieRepository
    {
        /// <summary>
        /// Creates a new movie in the repository.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CreateAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for a movie by its id.
        /// </summary>
        /// <param name="id">id of the Movie</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <exception cref="NotFoundException">Throws NotFoundException if movie is not found</exception>
        /// <returns>Movie</returns>
        Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing movie in the repository.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a movie by its id from the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
