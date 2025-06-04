namespace MovieMate.Domain.Models
{
    public class Movie
    {
        private readonly List<MovieGenre> _genres = [];
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public required int YearOfRelease { get; init; }
        public IReadOnlyList<MovieGenre> Genres => _genres;
        public required string Slug { get; init; }

        public void UpdateGenres(IEnumerable<Guid> genresIds)
        {
            _genres.Clear();
            foreach (var genresId in genresIds)
            {
                AddGenre(genresId);
            }
        }

        public void AddGenre(Guid genresId)
        {
            if (_genres.Any(g => g.GenreId == genresId))
            {
                throw new InvalidOperationException("This movie already has this genre.");
            }
            var genre = new MovieGenre { Id = Guid.NewGuid(), GenreId = genresId, MovieId = Id, };
            _genres.Add(genre);
        }
    }
}
