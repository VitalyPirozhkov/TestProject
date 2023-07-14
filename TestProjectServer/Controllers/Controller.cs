using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [Route("/GetPlan")]
        [HttpPost]
        public List<KitchenFixture> GetPlan([FromBody] KitchenParameters parameters)
        {
            List<KitchenFixture> results= new List<KitchenFixture>();
            double pipeX=0, pipeY=0;
            if(parameters.KitchenLength > parameters.PipeDistance)
            {
                pipeX=parameters.PipeDistance;
                pipeY=0;
            }
            else if(parameters.KitchenLength+parameters.KitchenWidth>parameters.PipeDistance)
            {
                pipeX = parameters.KitchenLength;
                pipeY = parameters.PipeDistance - parameters.KitchenLength;
            }
            else if((2*parameters.KitchenLength) + parameters.KitchenWidth > parameters.PipeDistance)
            {
                pipeY = parameters.KitchenWidth;
                pipeX = (2 * parameters.KitchenLength) + parameters.KitchenWidth - parameters.PipeDistance;
            }
            else
            {
                pipeX = 0;
                pipeY = (2 * (parameters.KitchenLength + parameters.KitchenWidth))-parameters.PipeDistance;
            }
            return results;
        }
    }
}
