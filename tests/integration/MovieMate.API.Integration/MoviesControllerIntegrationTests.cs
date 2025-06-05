using System.Net;
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
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(movies!);
        }

        /// <summary>
        /// This is the Happy Path testing of a movie - Create, Read, Update, Delete
        /// </summary>
        [Fact]
        public async Task MovieLifeCycleTest()
        {
            // Arrange
            using var factory = new WebApplicationFactory<Program>();
            using var httpClient = factory.CreateDefaultClient();

            // Act I - Adds new movie
            var createRequest = new CreateMovieRequest
            {
                Genres = [Constants.WellKnownGenreIds.Action],// we will fix in update :)
                Title = "Titenic",// we will fix this in update :)
                YearOfRelease = 1998,// we will fix this in update :)
            };
            using var createApiResponse = await httpClient.PostAsJsonAsync(MovieApiEndpoints.Create, createRequest);
            Assert.Equal(HttpStatusCode.Created, createApiResponse.StatusCode);
            var movieFromCreateApiCall = await createApiResponse.Content.ReadFromJsonAsync<MovieResponse>();
            var hasLocationHeaders = createApiResponse.Headers.TryGetValues("Location", out var locationHeaders);
            Assert.True(hasLocationHeaders);
            var actualGetMovieByIdUrl = locationHeaders!.Single();
            var createdMovieId = movieFromCreateApiCall!.Id.ToString();
            var expectedGetMovieByIdUrl = httpClient.BaseAddress!.AbsoluteUri + MovieApiEndpoints.GetById.Replace("{id:guid}", createdMovieId);
            Assert.Equal(expectedGetMovieByIdUrl, actualGetMovieByIdUrl);

            // Act II - Fetching movie by id - based on location headers received from create api call
            using var getMovieByIdApiResult = await httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(actualGetMovieByIdUrl),
            });
            Assert.Equal(HttpStatusCode.OK, getMovieByIdApiResult.StatusCode);
            var movieFromGetMovieByIdApi = await getMovieByIdApiResult.Content.ReadFromJsonAsync<MovieResponse>();
            Assert.Equivalent(movieFromCreateApiCall, movieFromGetMovieByIdApi);

            // Act III - Fetching all movies
            using var getAllMoviesApisResponse = await httpClient.GetAsync(MovieApiEndpoints.GetAll);
            getAllMoviesApisResponse.EnsureSuccessStatusCode();
            var movies = await getAllMoviesApisResponse.Content.ReadFromJsonAsync<IEnumerable<MovieResponse>>();
            Assert.Equal(HttpStatusCode.OK, getAllMoviesApisResponse.StatusCode);
            Assert.NotNull(movies);
            Assert.NotEmpty(movies);
            var foundMovieFromGetAllApiCall = movies!.Single();
            Assert.Equivalent(movieFromCreateApiCall, foundMovieFromGetAllApiCall);

            // Act IV - Updating the movie
            var updateRequest = new UpdateMovieRequest
            {
                Genres = [Constants.WellKnownGenreIds.Romance],
                Title = "Titanic",
                YearOfRelease = 1997
            };
            var movieUpdateUrl = MovieApiEndpoints.Update.Replace("{id:guid}", createdMovieId);
            using var updateMovieByIdApiResponse = await httpClient.PutAsJsonAsync(movieUpdateUrl, updateRequest);
            Assert.Equal(HttpStatusCode.NoContent, updateMovieByIdApiResponse.StatusCode);

            // Act V - Deleting the movie
            var deleteMovieUrl = MovieApiEndpoints.Delete.Replace("{id:guid}", createdMovieId);
            using var deleteMovieByIdApiResponse = await httpClient.DeleteAsync(deleteMovieUrl);
            Assert.Equal(HttpStatusCode.Accepted, updateMovieByIdApiResponse.StatusCode);
        }
    }
}
