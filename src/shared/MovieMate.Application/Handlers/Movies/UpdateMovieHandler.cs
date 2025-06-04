using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.Domain.Models;

namespace MovieMate.Application.Handlers.Movies
{
    public class UpdateMovieHandler : IUpdateMovieHandler
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreQuery _genreQuery;

        public UpdateMovieHandler(
            IMovieRepository movieRepository, IGenreQuery genreQuery)
        {
            _movieRepository = movieRepository;
            _genreQuery = genreQuery;
        }

        public async Task UpdateAsync(Abstractions.Models.Movie movie, CancellationToken cancellationToken = default)
        {
            // ensuring that movie exists
            _ = await _movieRepository.GetByIdAsync(movie.Id, cancellationToken)
                ?? throw new NotFoundException($"Unable to find movie by id: {movie.Id}");

            // TODO - ensure that these genres are valid ids
            var movieDomain = movie.ToDomainModel();
            var movieGenres = await _genreQuery.FindByIds(movie.Genres, cancellationToken);
            // 1. Update Movie table - movie repository
            movieDomain.UpdateGenres(movieGenres.Select(g => g.Id).ToArray());
            await _movieRepository.UpdateAsync(movieDomain, cancellationToken);

            // 2. TODO - Delete All MovieGenres where movieId - movieGenre repository
            // 3. TODO - Add new MovieGenres - movieGenre repository
        }
    }
}
