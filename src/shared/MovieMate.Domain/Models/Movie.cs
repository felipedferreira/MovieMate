namespace MovieMate.Domain.Models
{
    public class Movie
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public required int YearOfRelease { get; init; }
        public required IEnumerable<Guid> Genres { get; init; } = Enumerable.Empty<Guid>();
        public required string Slug { get; set; }
    }
}
