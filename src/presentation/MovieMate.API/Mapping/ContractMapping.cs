using MovieMate.API.Contracts.Requests;
using MovieMate.API.Contracts.Responses;
using MovieMate.Application.Abstractions.Models;

namespace MovieMate.API.Mapping
{
    public static class ContractMapping
    {
        /// <summary>
        /// Maps a <see cref="CreateMovieRequest"/> to an <see cref="Movie"/>.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public static Movie ToApplication(this CreateMovieRequest movie)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Genres = movie.Genres,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
        }

        public static Movie ToApplication(this UpdateMovieRequest movie, Guid id)
        {
            return new Movie
            {
                Id = id,
                Genres = movie.Genres,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
        }

        public static Genre ToApplication(this CreateGenreRequest request)
        {
            return new Genre
            {
                Description = request.Description,
                Id = Guid.NewGuid(),
                Title = request.Title,
            };
        }

        public static MovieResponse ToResponse(this Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
                Genres = movie.Genres,
                Slug = movie.Slug,
            };
        }

        public static GenreResponse ToResponse(this Genre domain)
        {
            return new GenreResponse
            {
                Description = domain.Description,
                Id = domain.Id,
                Title = domain.Title,
            };
        }
    }
}
