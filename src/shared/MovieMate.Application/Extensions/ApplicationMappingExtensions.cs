using ApplicationModel = MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Extensions
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
                Id = movie.Id,
            };
        }

        public static ApplicationModel.Genre ToApplicationModel(this Domain.Models.Genre domain)
        {
            return new ApplicationModel.Genre
            {
                Description = domain.Description,
                Id = domain.Id,
                Title = domain.Title,
            };
        }

        public static Domain.Models.Genre ToDomainModel(this ApplicationModel.Genre model)
        {
            return new Domain.Models.Genre
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description
            };
        }
    }
}
