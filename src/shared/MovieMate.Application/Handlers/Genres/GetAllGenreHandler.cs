using MovieMate.Application.Abstractions.Handlers.Genres;
using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.Application.Extensions;

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
