using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.DataAccess;
using MovieMate.DataAccess.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<DataContext>()
                // Movies
                .AddSingleton<IMovieQuery, MovieQuery>()
                .AddSingleton<IMovieRepository, MovieRepository>()
                // Genre
                .AddSingleton<IGenreRepository, GenreRepository>()
                .AddSingleton<IGenreQuery, GenreQuery>();
        }
    }
}
