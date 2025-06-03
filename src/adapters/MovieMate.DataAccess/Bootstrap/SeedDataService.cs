using Microsoft.Extensions.Hosting;
using MovieMate.Application.Abstractions.Services.DataAccess;

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
            IEnumerable<Domain.Models.Genre> seedData = [
                new Domain.Models.Genre
                {
                    Id = Guid.Parse("0cd77e07-7905-45ec-a8be-76e7d7addfa5"),
                    Title = "Action",
                    Description = "Action movies are characterized by a focus on physical feats, including fights, chases, explosions, and stunts."
                },
                new Domain.Models.Genre
                {
                    Id = Guid.Parse("E7F352FC-F802-46B2-8757-5C8E76A52C0C"),
                    Title = "Romance",
                    Description = "Romance movies focus on the romantic relationships between characters, often exploring themes of love, passion, and emotional connection.",
                }
            ];
            await _genreRepository.CreateAsync(seedData, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
