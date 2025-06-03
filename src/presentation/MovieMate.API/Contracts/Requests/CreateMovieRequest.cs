namespace MovieMate.API.Contracts.Requests
{
    public sealed class CreateMovieRequest
    {
        public required string Title { get; init; }

        public required int YearOfRelease { get; init; }

        public required IEnumerable<Guid> Genres { get; init; } = Enumerable.Empty<Guid>();
    }
}
