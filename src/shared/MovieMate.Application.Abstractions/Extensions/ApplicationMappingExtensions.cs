using ApplicationModel = MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Abstractions.Extensions
{
    public static class ApplicationMappingExtensions
    {
        public static ApplicationModel.Movie ToApplicationModel(this Domain.Models.Movie movie)
        {
            return new ApplicationModel.Movie
            {
                Genres = movie.Genres,
                Id = movie.Id,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
        }

        public static Domain.Models.Movie ToDomainModel(this ApplicationModel.Movie movie)
        {
            return new Domain.Models.Movie
            {
                Genres = movie.Genres,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
                Slug = movie.Slug,
                Id = movie.Id.Equals(Guid.Empty) ? Guid.NewGuid() : movie.Id,
            };
        }
    }
}
