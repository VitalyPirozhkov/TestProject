using System.IO.Pipelines;

namespace TestProject.Models
{
    public class KitchenFixture
    {
        public double StoveX { get; set; }
        public double StoveY { get; set; }
        public double SinkX { get; set; }
        public double SinkY { get; set; }
        public double PipeX { get; set; }
        public double PipeY { get; set; }
        public string StoveDescription { get; set; }
        public string SinkDescription { get; set; }
        public string Status { get; set; }

        public KitchenFixture(double stoveX, double stoveY, double sinkX, double sinkY, double pipeX, double pipeY,
            string stoveDesription, string sinkDesription, string status)
        {
            StoveX= stoveX;
            StoveY= stoveY;
            SinkX= sinkX;
            SinkY= sinkY;
            PipeX= pipeX;
            PipeY= pipeY;
            StoveDescription= stoveDesription;
            SinkDescription= sinkDesription;
            Status= status;
        }
    }
}
