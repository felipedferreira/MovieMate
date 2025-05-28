using MovieMate.Application.Abstractions.Services;
using MovieMate.Domain.Models;

namespace MovieMate.DataAccess
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public Task CreateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _movies.Add(movie);
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var index = _movies.FindIndex(m => m.Id.Equals(id));
            if (index >= 0)
            {
                _movies.RemoveAt(index);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Movie>>(_movies);
        }

        public Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = _movies.Single(m => m.Id == id);
            return Task.FromResult(movie);
        }

        public Task<Movie> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            var movie = _movies.Single(m => m.Slug.Equals(slug));
            return Task.FromResult(movie);
        }

        public Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
