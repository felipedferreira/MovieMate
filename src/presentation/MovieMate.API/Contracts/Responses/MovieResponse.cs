﻿namespace MovieMate.API.Contracts.Responses
{
    public class MovieResponse
    {
        public Guid Id { get; set; }

        public required string Title { get; init; }

        public required string Slug { get; init; }

        public required int YearOfRelease { get; init; }

        public required IEnumerable<Guid> Genres { get; init; } = Enumerable.Empty<Guid>();
    }
}
