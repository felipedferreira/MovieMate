namespace MovieMate.Domain.Models
{
    public class Movie
    {
        private readonly List<MovieGenre> _genres = [];
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public required int YearOfRelease { get; init; }
        public IReadOnlyList<MovieGenre> Genres => _genres;
        public required string Slug { get; set; }

        public void UpdateGenres(IEnumerable<MovieGenre> genres)
        {
            _genres.Clear();
            foreach (var genre in genres)
            {
                AddGenre(genre);
            }
        }

        public void AddGenre(MovieGenre movieGenre)
        {
            if (movieGenre is null)
            {
                throw new ArgumentNullException(nameof(movieGenre), "Movie genre cannot be null.");
            }
            if (_genres.Any(g => g.GenreId == movieGenre.GenreId))
            {
                throw new InvalidOperationException("This movie already has this genre.");
            }
            _genres.Add(movieGenre);
        }
    }
}
