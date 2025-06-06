using MovieMate.Domain.MovieAggregate;

namespace MovieMate.DataAccess.Services
{
    internal class MovieQuery : IMovieQuery
    {
        private readonly DataContext _dataSource;

        public MovieQuery(DataContext dataSource)
        {
            _dataSource = dataSource;
        }

        public Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Movie>>(_dataSource.Movies);
        }

        public Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = _dataSource.Movies.SingleOrDefault(m => m.Id == id);
            return Task.FromResult(movie);
        }

        public Task<Movie> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            var movie = _dataSource.Movies.Single(m => m.Slug.Equals(slug));
            return Task.FromResult(movie);
        }
    }
}
