using MovieMate.Domain.MovieAggregate;

namespace MovieMate.DataAccess
{
    internal class DataContext
    {
        public readonly List<Movie> Movies = new List<Movie>();
        public readonly List<Genre> Genres = new List<Genre>();
        public readonly List<MovieGenre> MovieGenres = new List<MovieGenre>();
    }
}
