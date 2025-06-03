using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using MovieMate.API.Contracts.Responses;
using static MovieMate.API.ApiEndpoints;

namespace MovieMate.API.Integration
{
    public class MoviesControllerIntegrationTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsOk_WhenNoRecordsExist()
        {
            // Arrange
            using var factory = new WebApplicationFactory<Program>();
            using var httpClient = factory.CreateDefaultClient();

            // Act
            using var response = await httpClient.GetAsync(MovieApiEndpoints.GetAll);
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<IEnumerable<MovieResponse>>();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(movies!);
        }
    }
}
