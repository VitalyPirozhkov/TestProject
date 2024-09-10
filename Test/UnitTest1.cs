using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;
namespace IntgrationServerTest
{
    public class DataControllerTests : IClassFixture<WebApplicationFactory<TestProjectServer.Program>>
    {
        private readonly HttpClient _client;

        public DataControllerTests(WebApplicationFactory<TestProjectServer.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetData_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/GetData");

            response.EnsureSuccessStatusCode();
        }
    }
}