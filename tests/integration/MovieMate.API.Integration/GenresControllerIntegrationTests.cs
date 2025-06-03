using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using MovieMate.API.Contracts.Responses;
using static MovieMate.API.ApiEndpoints;
using static MovieMate.DataAccess.Constants;

namespace MovieMate.API.Integration
{
    public class GenresControllerIntegrationTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsExpectedGenres_WhenSeedDataExists()
        {
            // Arrange
            var expectedIds = new[]
            {
                WellKnownGenreIds.Action,
                WellKnownGenreIds.Romance,
            };
            using var factory = new WebApplicationFactory<Program>();
            using var httpClient = factory.CreateDefaultClient();

            // Act
            using var response = await httpClient.GetAsync(GenreApiEndpoints.GetAll);
            response.EnsureSuccessStatusCode();
            var genres = await response.Content.ReadFromJsonAsync<IEnumerable<GenreResponse>>();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(genres!);
            Assert.All(genres!, g => expectedIds.Contains(g.Id));
        }
    }
}
