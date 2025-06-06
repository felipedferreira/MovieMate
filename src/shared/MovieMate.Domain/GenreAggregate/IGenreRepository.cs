namespace MovieMate.Domain.MovieAggregate
{
    public interface IGenreRepository
    {
        Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);

        Task CreateAsync(IEnumerable<Genre> genres, CancellationToken cancellationToken = default);
    }
}
