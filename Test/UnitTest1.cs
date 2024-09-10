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
        public async Task GetData_ReturnsSuccessStatusCode_WhenCalled()
        {
            var response = await _client.GetAsync("/GetData");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetData_ReturnsSuccessStatusCode_ForConcurrentRequests()
        {
            var tasks = new List<Task<HttpResponseMessage>>();
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(_client.GetAsync("/GetData"));
            }

            var responses = await Task.WhenAll(tasks);

            foreach (var response in responses)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task InvalidEndpoint_ReturnsNotFoundStatusCode_WhenCalled()
        {
            var response = await _client.GetAsync("/InvalidEndpoint");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
