namespace MovieMate.API.Contracts.Responses
{
    public class MoviesResponse
    {
        public IEnumerable<MovieResponse> Data { get; set; } = Enumerable.Empty<MovieResponse>();
    }
}
