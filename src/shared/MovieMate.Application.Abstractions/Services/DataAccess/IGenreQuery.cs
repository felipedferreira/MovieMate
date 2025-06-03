using MovieMate.Domain.Models;

namespace MovieMate.Application.Abstractions.Services.DataAccess
{
    public interface IGenreQuery
    {
        public Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Genre>> FindByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
