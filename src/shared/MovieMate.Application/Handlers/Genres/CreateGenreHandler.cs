using MovieMate.Application.Abstractions.Handlers.Genres;
using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.Application.Extensions;

namespace MovieMate.Application.Handlers.Genres
{
    internal class CreateGenreHandler : ICreateGenreHandler
    {
        private readonly IGenreRepository _genreRepository;
        public CreateGenreHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task CreateAsync(Genre genre, CancellationToken cancellationToken = default)
        {
            await _genreRepository.CreateAsync(genre.ToDomainModel(), cancellationToken);
        }
    }
}
