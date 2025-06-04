using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using MovieMate.API.Contracts.Requests;
using MovieMate.API.Contracts.Responses;
using MovieMate.DataAccess;
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

        [Fact]
        public async Task GetAllAsync_ReturnsOk_WhenMovieExists()
        {
            // Arrange
            using var factory = new WebApplicationFactory<Program>();
            using var httpClient = factory.CreateDefaultClient();

            // Act I - Adds new movie
            var createRequest = new CreateMovieRequest
            {
                Genres = [Constants.WellKnownGenreIds.Romance],
                Title = "Titanic",
                YearOfRelease = 1997,
            };
            using var createApiResponse = await httpClient.PostAsJsonAsync(MovieApiEndpoints.Create, createRequest);
            Assert.Equal(System.Net.HttpStatusCode.Created, createApiResponse.StatusCode);

            // Act II - Fetching movie
            using var response = await httpClient.GetAsync(MovieApiEndpoints.GetAll);
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<IEnumerable<MovieResponse>>();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(movies!);
        }
    }
}
