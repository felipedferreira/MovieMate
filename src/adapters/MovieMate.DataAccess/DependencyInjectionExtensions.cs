using MovieMate.Application.Abstractions.Services;
using MovieMate.DataAccess;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<DataContext>()
                .AddSingleton<IMovieQuery, MovieQuery>()
                .AddSingleton<IMovieRepository, MovieRepository>();
        }
    }
}
