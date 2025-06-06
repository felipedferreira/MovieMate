using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Domain.MovieAggregate;

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
            var movieDomain = movie.ToDomainModel();
            // updating the domain with the ids
            movieDomain.UpdateGenres(movie.Genres);

            // TODO - Validation -> ensure that these genres are valid ids
            // TODO - Validation: ensure movie exists, MOVE THIS OUT TO ITS OWN VALIDATION CLASS
            _ = await _movieRepository.GetByIdAsync(movie.Id, cancellationToken)
                ?? throw new NotFoundException($"Unable to find movie by id: {movie.Id}");

            await _movieRepository.UpdateAsync(movieDomain, cancellationToken);
        }
    }
}
