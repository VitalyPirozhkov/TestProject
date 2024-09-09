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
        public List<string> Messages { get; set; }

        public DataControllerTests(WebApplicationFactory<TestProjectServer.Program> factory)
        {
            _client = factory.CreateClient();
            Messages = new List<string> { "нечет!", "чет!", "равно!" };
        }

        [Fact]
        public async Task GetData_ReturnsEvenMessage()
        {
            var response = await _client.GetAsync("/GetData");

            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();

            Assert.Contains(message, Messages);
        }
    }
}