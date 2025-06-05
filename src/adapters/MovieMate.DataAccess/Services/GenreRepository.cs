using MovieMate.Domain.Aggregates.MovieAggregate;

namespace MovieMate.DataAccess.Services
{
    internal class GenreRepository : IGenreRepository
    {
        private readonly DataContext _dataContext;
        public GenreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task CreateAsync(Genre genre, CancellationToken cancellationToken = default)
        {
            _dataContext.Genres.Add(genre);
            return Task.CompletedTask;
        }

        public Task CreateAsync(IEnumerable<Genre> genres, CancellationToken cancellationToken = default)
        {
            _dataContext.Genres.AddRange(genres);
            return Task.CompletedTask;
        }
    }
}
