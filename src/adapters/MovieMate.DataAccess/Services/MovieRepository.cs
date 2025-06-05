using MovieMate.Domain.Aggregates.MovieAggregate;

namespace MovieMate.DataAccess
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly DataContext _dataSource;

        public MovieRepository(DataContext dataSource)
        {
            _dataSource = dataSource;
        }

        public Task CreateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _dataSource.Movies.Add(movie);
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var index = _dataSource.Movies.FindIndex(m => m.Id.Equals(id));
            if (index >= 0)
            {
                _dataSource.Movies.RemoveAt(index);
            }

            return Task.CompletedTask;
        }

        public Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = _dataSource.Movies.SingleOrDefault(m => m.Id == id);
            return Task.FromResult(movie);
        }

        public Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            var index = _dataSource.Movies.FindIndex(m => m.Id == movie.Id);
            if (index >= 0)
            {
                _dataSource.Movies[index] = movie;
            }
            return Task.CompletedTask;
        }
    }
}
