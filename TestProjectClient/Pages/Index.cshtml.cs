using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using TestProjectClient.Entity;

namespace TestProjectClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        private readonly ApiSettings _apiSettings;

        public string? Message { get; set; }

        public IndexModel(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }

        public async Task OnGetAsync()
        {
            Message = await GetMessageFromServer();
        }

        public async Task<IActionResult> OnGetMessageAsync()
        {
            var message = await GetMessageFromServer();
            return Content(message);
        }


        private async Task<string> GetMessageFromServer()
        {
            try
            {
                return await _httpClient.GetStringAsync(_apiSettings.ApiUrl);
            }
            catch (HttpRequestException ex)
            {
                return $"Ошибка запроса: {ex.Message}";
            }
        }
    }
}
