namespace MovieMate.API.Contracts.Responses
{
    public class GenreResponse
    {
        public Guid Id { get; set; }
        public required string Title { get; init; }
        public required string Description { get; init; }
    }
}
