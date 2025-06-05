using MovieMate.Domain.Aggregates.MovieAggregate;

namespace MovieMate.DataAccess
{
    internal class DataContext
    {
        public readonly List<Movie> Movies = [];
        public readonly List<Genre> Genres = [];
    }
}
