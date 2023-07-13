using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpPost]
        public double GetPlan([FromBody] KitchenParameters parameters)
        {
            return 1;
        }
    }
}
