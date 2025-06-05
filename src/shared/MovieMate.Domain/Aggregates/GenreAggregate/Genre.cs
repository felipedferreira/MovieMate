namespace MovieMate.Domain.Aggregates.MovieAggregate
{
    public class Genre
    {
        public required string Title { get; init; }

        public required string Description { get; init; }

        public Guid Id { get; init; }
    }
}
