using Microsoft.AspNetCore.Mvc.Testing;
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
            var response = await httpClient.GetAsync(MovieApiEndpoints.GetAll);
            response.EnsureSuccessStatusCode();
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
