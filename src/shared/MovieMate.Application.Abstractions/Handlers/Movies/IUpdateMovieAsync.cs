using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Handlers.Movies
{
    public interface IUpdateMovieAsync
    {
        /// <summary>
        /// Used to replaces the movie record in database if found.
        /// </summary>
        /// <exception cref="NotFoundException">When movie is not found.</exception>
        Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default);
    }
}
