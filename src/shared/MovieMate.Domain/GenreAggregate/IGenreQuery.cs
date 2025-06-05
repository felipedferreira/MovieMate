namespace MovieMate.Domain.MovieAggregate.MovieAggregate
{
    public interface IGenreQuery
    {
        public Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Genre>> FindByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
