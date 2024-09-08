using Microsoft.AspNetCore.Mvc;
using TestProjectServer.Entities;

namespace TestProjectServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly DataManager _dataManager;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
            _dataManager = new DataManager();
        }

        [HttpGet]
        [Route("/GetData")]
        public async Task<IActionResult> GetData()
        {
            try
            {
                _logger.LogInformation("��������� ������ � �������");
                var data = await _dataManager.GetDataAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "��������� ������ ��� ��������� ������");
                return StatusCode(500, "��������� ������ �� �������");
            }
        }
    }
}
