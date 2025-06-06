using MovieMate.Application.Abstractions.Handlers.Genres;
using MovieMate.Domain.MovieAggregate;
using MovieMate.Application.Extensions;
using Genre = MovieMate.Application.Abstractions.Models.Genre;

namespace MovieMate.Application.Handlers.Genres
{
    internal class GetAllGenreHandler : IGetAllGenreHandler
    {
        private readonly IGenreQuery _genreQuery;
        public GetAllGenreHandler(IGenreQuery genreQuery)
        {
            _genreQuery = genreQuery;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken)
        {
            var genres = await _genreQuery.GetAllGenresAsync(cancellationToken);
            return genres.Select(ApplicationMappingExtensions.ToApplicationModel);
        }
    }
}
