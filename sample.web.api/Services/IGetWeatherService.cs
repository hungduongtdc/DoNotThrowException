public interface IGetWeatherService
{
    Task<IEnumerable<string>> GetWeatherAsync(string search);
    Task<Result<IEnumerable<string>>> GetWeatherReturnResultsAsync(string search);
}