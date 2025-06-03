using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.Application.Abstractions.Exceptions;

namespace MovieMate.Application.Handlers.Movies
{
    internal class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreQuery _genreQuery;
        public CreateMovieHandler(
            IMovieRepository movieRepository,
            IGenreQuery genreQuery)
        {
            _movieRepository = movieRepository;
            _genreQuery = genreQuery;
        }

        public async Task CreateAsync(Abstractions.Models.Movie movie, CancellationToken cancellationToken = default)
        {
            // validates that the genre is valid
            var genres = await _genreQuery.FindByIds(movie.Genres, cancellationToken);
            var invalidGenreIds = movie.Genres.Except(genres.Select(g => g.Id));
            if (invalidGenreIds.Any())
            {
                throw new InvalidGenreException(invalidGenreIds.ToArray());
            }
            // TODO - validate that movie year of release is valid
            // TODO - validate that we have not added this movie before

            // ensure that movie.Genres are valid
            await _movieRepository.CreateAsync(movie.ToDomainModel(), cancellationToken);
        }
    }
}
