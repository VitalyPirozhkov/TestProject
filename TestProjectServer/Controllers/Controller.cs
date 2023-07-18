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
            double pipeDistance = parameters.PipeDistance % ((parameters.KitchenLength+parameters.KitchenWidth) * 2);
            if(parameters.KitchenLength >= pipeDistance)
            {
                pipeX=pipeDistance;
                pipeY=0;
            }
            else if(parameters.KitchenLength+parameters.KitchenWidth>=pipeDistance)
            {
                pipeX = parameters.KitchenLength;
                pipeY = pipeDistance - parameters.KitchenLength;
            }
            else if((2*parameters.KitchenLength) + parameters.KitchenWidth >= pipeDistance)
            {
                pipeY = parameters.KitchenWidth;
                pipeX = (2 * parameters.KitchenLength) + parameters.KitchenWidth - pipeDistance;
            }
            else if(2 * (parameters.KitchenLength + parameters.KitchenWidth)>= pipeDistance)
            {
                pipeX = 0;
                pipeY = (2 * (parameters.KitchenLength + parameters.KitchenWidth))-pipeDistance;
            }

            return results;
        }
    }
}
