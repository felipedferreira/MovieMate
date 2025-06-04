using MovieMate.Application.Abstractions.Handlers.Genres;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Handlers.Genres;
using MovieMate.Application.Handlers.Movies;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Adds all services required to run the application.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddDataAccessServices()
                .AddHandlers();
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) => services
            // Movie Handlers
            .AddScoped<ICreateMovieHandler, CreateMovieHandler>()
            .AddScoped<IGetMovieByIdHandler, GetMovieByIdHandler>()
            .AddScoped<IGetAllMoviesHandler, GetAllMoviesHandler>()
            .AddScoped<IUpdateMovieHandler, UpdateMovieHandler>()
            .AddScoped<IDeleteMovieHandler, DeleteMovieHandler>()
            // Genre Handlers
            .AddScoped<ICreateGenreHandler, CreateGenreHandler>()
            .AddScoped<IGetAllGenreHandler, GetAllGenreHandler>();
    }
}
