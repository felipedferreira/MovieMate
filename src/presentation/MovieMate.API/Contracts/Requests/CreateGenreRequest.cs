namespace MovieMate.API.Contracts.Requests
{
    public sealed class CreateGenreRequest
    {
        public required string Title { get; init; }

        public required string Description { get; init; }
    }
}
