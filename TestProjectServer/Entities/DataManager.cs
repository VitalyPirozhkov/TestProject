namespace TestProjectServer.Entities
{
    public class DataManager
    {
        public async Task<string> GetDataAsync()
        {
            DateTime currentTime = DateTime.Now;
            string dateNumbers = $"{currentTime:ddMMyyyyHHmmss}";

            int evenCount = 0;
            int oddCount = 0;

            foreach (char c in dateNumbers)
            {
                int digit = (int)char.GetNumericValue(c);

                if (digit % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            string result;
            if (evenCount > oddCount)
            {
                result = "чет!";
            }
            else if (oddCount > evenCount)
            {
                result = "нечет!";
            }
            else
            {
                result = "равно!";
            }

            return await Task.FromResult(result);
        }
    }
}
