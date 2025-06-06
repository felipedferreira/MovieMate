using MovieMate.Domain.MovieAggregate;

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

            foreach (var genreId in movie.Genres)
            {
                _dataSource.MovieGenres.Add(new MovieGenre
                {
                    GenreId = genreId,
                    Id = Guid.NewGuid(),
                    MovieId = movie.Id,
                });
            }

            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = _dataSource.Movies.SingleOrDefault(m => m.Id.Equals(id));
            if (movie is not null)
            {
                var movieGenres = _dataSource.MovieGenres
                    .Where(m => m.MovieId.Equals(movie.Id))
                    .ToArray();
                foreach (var movieGenre in movieGenres)
                {
                    _dataSource.MovieGenres.Remove(movieGenre);
                }
                _dataSource.Movies.Remove(movie);
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
                var movieGenres = _dataSource.MovieGenres
                    .Where(m => m.MovieId.Equals(movie.Id))
                    .ToArray();

                // removes old movie genre mappings
                foreach (var movieGenre in movieGenres)
                {
                    _dataSource.MovieGenres.Remove(movieGenre);
                }

                // updates with new movie genre mappings
                foreach (var movieGenre in movie.Genres)
                {
                    _dataSource.MovieGenres.Add(new MovieGenre
                    {
                        Id = Guid.NewGuid(),
                        GenreId = movieGenre,
                        MovieId = movie.Id,
                    });
                }
            }
            return Task.CompletedTask;
        }
    }
}
