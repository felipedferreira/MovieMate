using MovieMate.Application.Abstractions.Services.DataAccess;
using MovieMate.Domain.Models;

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
    }
}
