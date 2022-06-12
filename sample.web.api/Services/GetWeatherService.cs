public class GetWeatherService : IGetWeatherService
{
    private static readonly string[] Summaries = new[]
   {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    public async Task<IEnumerable<string>> GetWeatherAsync(string search)
    {
        var results = SearchWeather(search);
        if (results.Any())
        {
            return results;
        }
        throw new Exception("No weather found with this pattern");
    }

    private static string[] SearchWeather(string search)
    {
        return Summaries.Where(c => c.StartsWith(search)).ToArray();
    }

    public async Task<Result<IEnumerable<string>>> GetWeatherReturnResultsAsync(string search)
    {
        var results = SearchWeather(search);
        if (results.Any())
        {
            return results;
        }
        return new Result<IEnumerable<string>>(new Exception("No weather found with this pattern"));
    }
}