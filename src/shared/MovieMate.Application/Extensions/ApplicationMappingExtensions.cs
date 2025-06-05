using MovieMate.Domain.Models;
using ApplicationModel = MovieMate.Application.Abstractions.Models;

namespace MovieMate.Application.Extensions
{
    public static class ApplicationMappingExtensions
    {
        public static ApplicationModel.Movie ToApplicationModel(this Movie movie)
        {
            return new ApplicationModel.Movie
            {
                Genres = movie.Genres,
                Id = movie.Id,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
        }

        public static Movie ToDomainModel(this ApplicationModel.Movie movie)
        {
            var domain = new Movie
            {
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
                Slug = movie.Slug,
                Id = movie.Id,
            };
            foreach (var genre in movie.Genres)
            {
                domain.AddGenre(genre);
            }
            return domain;
        }

        public static ApplicationModel.Genre ToApplicationModel(this Genre domain)
        {
            return new ApplicationModel.Genre
            {
                Description = domain.Description,
                Id = domain.Id,
                Title = domain.Title,
            };
        }

        public static Genre ToDomainModel(this ApplicationModel.Genre model)
        {
            return new Genre
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description
            };
        }
    }
}
