using Microsoft.Extensions.Hosting;
using MovieMate.Domain.MovieAggregate.MovieAggregate;

namespace MovieMate.DataAccess.Bootstrap
{
    internal class SeedDataService : IHostedService
    {
        private readonly IGenreRepository _genreRepository;
        public SeedDataService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Genre> seedData = [
                new Genre
                {
                    Id = Constants.WellKnownGenreIds.Action,
                    Title = "Action",
                    Description = "Action movies are characterized by a focus on physical feats, including fights, chases, explosions, and stunts."
                },
                new Genre
                {
                    Id = Constants.WellKnownGenreIds.Romance,
                    Title = "Romance",
                    Description = "Romance movies focus on the romantic relationships between characters, often exploring themes of love, passion, and emotional connection.",
                }
            ];
            await _genreRepository.CreateAsync(seedData, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
