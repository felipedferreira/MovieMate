using MovieMate.Application.Abstractions.Handlers.Genres;
using MovieMate.Application.Extensions;
using MovieMate.Domain.MovieAggregate;
using Genre = MovieMate.Application.Abstractions.Models.Genre;

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
            // TODO - validate we have NOT added this genre before.
            await _genreRepository.CreateAsync(genre.ToDomainModel(), cancellationToken);
        }
    }
}
