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
            var movieDomain = await _movieRepository.GetByIdAsync(movie.Id, cancellationToken)
                ?? throw new NotFoundException($"Unable to find movie by id: {movie.Id}");

            var movieGenres = (await _genreQuery.FindByIds(movie.Genres, cancellationToken))
                .Select(genre => new MovieGenre
                {
                    GenreId = genre.Id,
                    Id = genre.Id,
                    MovieId = movieDomain.Id,
                });
            movieDomain.UpdateGenres(movieGenres);
            await _movieRepository.UpdateAsync(movie.ToDomainModel(), cancellationToken);
        }
    }
}
