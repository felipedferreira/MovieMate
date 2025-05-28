namespace MovieMate.Application.Abstractions.Handlers.Movies
{
    public interface ICreateMovieHandler
    {
        Task HandleAsync(CancellationToken cancellationToken);
    }
}
