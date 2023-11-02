using Microsoft.FeatureManagement;

public class WeatherForecastFeatureFilter : FeatureFilter<MyCustomFilterContext>
{
    protected override string FeatureFlag => "WeatherForecast";

    public WeatherForecastFeatureFilter(IFeatureManager featureManager) : base(featureManager)
    {
    }

    protected override MyCustomFilterContext GetFeatureContext(EndpointFilterInvocationContext context)
    {
        return new MyCustomFilterContext
        {
            InputNumber = context.HttpContext.Request.Headers["X-Lucky-Number"]
                .Select(x => Convert.ToInt32(x))
                .FirstOrDefault(0)
        };
    }
}