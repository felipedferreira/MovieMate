using MovieMate.Domain.MovieAggregate.MovieAggregate;

namespace MovieMate.DataAccess.Services
{
    internal class GenreQuery : IGenreQuery
    {
        private readonly DataContext _dataContext;
        public GenreQuery(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Genre>>(_dataContext.Genres);
        }

        public Task<IEnumerable<Genre>> FindByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var genres = _dataContext.Genres
                .Where(g => ids.Contains(g.Id));
            return Task.FromResult(genres);
        }
    }
}
