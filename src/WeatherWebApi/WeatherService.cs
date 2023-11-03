public class WeatherService
{
    private readonly string[] _summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public WeatherService()
    {
    }

    public WeatherForecast[] Get()
    {
        return Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateTimeOffset.Now.AddDays(index),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                ))
            .ToArray();
    }
}