using MovieMate.Application.Abstractions.Exceptions;

namespace MovieMate.Application.Abstractions.Handlers.Movies
{
    public interface IDeleteMovieAsync
    {
        /// <summary>
        /// Deletes the movie record from database if found.
        /// </summary>
        /// <exception cref="NotFoundException">When movie is not found.</exception>
        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
