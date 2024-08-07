namespace BlazorAPIFirstWeek.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",    // -20 to -1
            "Bracing",     // 0 to 4
            "Chilly",      // 5 to 9
            "Cool",        // 10 to 14
            "Mild",        // 15 to 19
            "Warm",        // 20 to 24
            "Balmy",       // 25 to 29
            "Hot",         // 30 to 34
            "Sweltering",  // 35 to 39
            "Scorching"    // 40 to 55
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index =>
            {
                var temperatureC = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = temperatureC,
                    Summary = GetSummaryBasedOnTemperature(temperatureC)
                };
            }).ToArray());
        }

        private string GetSummaryBasedOnTemperature(int temperatureC)
        {
            return temperatureC switch
            {
                <= -1 => Summaries[0],  // If temperatureC is less than or equal to -1, return "Freezing"
                <= 4 => Summaries[1],   // If temperatureC is between 0 and 4 (inclusive), return "Bracing"
                <= 9 => Summaries[2],   // If temperatureC is between 5 and 9 (inclusive), return "Chilly"
                <= 14 => Summaries[3],  // If temperatureC is between 10 and 14 (inclusive), return "Cool"
                <= 19 => Summaries[4],  // If temperatureC is between 15 and 19 (inclusive), return "Mild"
                <= 24 => Summaries[5],  // If temperatureC is between 20 and 24 (inclusive), return "Warm"
                <= 29 => Summaries[6],  // If temperatureC is between 25 and 29 (inclusive), return "Balmy"
                <= 34 => Summaries[7],  // If temperatureC is between 30 and 34 (inclusive), return "Hot"
                <= 39 => Summaries[8],  // If temperatureC is between 35 and 39 (inclusive), return "Sweltering"
                _ => Summaries[9]       // If temperatureC is 40 or above, return "Scorching"
            };
        }
    }
}
