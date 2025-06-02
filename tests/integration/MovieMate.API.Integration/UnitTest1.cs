using Microsoft.AspNetCore.Mvc.Testing;
using static MovieMate.API.ApiEndpoints;

namespace MovieMate.API.Integration
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllAsync()
        {
            using var factory = new WebApplicationFactory<Program>();
            using var httpClient = factory.CreateDefaultClient();
            var response = await httpClient.GetAsync(MovieApiEndpoints.GetAll);
            response.EnsureSuccessStatusCode();
        }
    }
}
