using MovieMate.API.Contracts.Requests;
using MovieMate.API.Contracts.Responses;
using ApplicationModel = MovieMate.Application.Abstractions.Models;

namespace MovieMate.API.Mapping
{
    public static class ContractMapping
    {
        /// <summary>
        /// Maps a <see cref="CreateMovieRequest"/> to an <see cref="ApplicationModel.Movie"/>.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public static ApplicationModel.Movie ToApplication(this CreateMovieRequest movie)
        {
            return new ApplicationModel.Movie
            {
                Id = Guid.NewGuid(),
                Genres = movie.Genres,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
        }

        public static ApplicationModel.Movie ToApplication(this UpdateMovieRequest movie, Guid id)
        {
            // id, movie.Title, movie.YearOfRelease, movie.Genres
            return new ApplicationModel.Movie
            {
                Id = id,
                Genres = movie.Genres,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
        }

        public static MovieResponse ToResponse(this ApplicationModel.Movie movie)
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
    }
}
