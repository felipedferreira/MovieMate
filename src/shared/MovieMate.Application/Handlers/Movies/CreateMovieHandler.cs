using MovieMate.Application.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.Domain.Models;

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
            var movieDomain = movie.ToDomainModel();
            var movieGenres = await _genreQuery.FindByIds(movie.Genres, cancellationToken);

            foreach (var genre in movieGenres)
            {
                var movieGenre = new MovieGenre
                {
                    GenreId = genre.Id,
                    Id = Guid.NewGuid(),
                    MovieId = movieDomain.Id,
                };
                movieDomain.AddGenre(movieGenre);
            }

            // TODO - validate that movie year of release is valid
            // TODO - validate that we have not added this movie before

            // ensure that movie.Genres are valid
            await _movieRepository.CreateAsync(movieDomain, cancellationToken);
        }
    }
}
