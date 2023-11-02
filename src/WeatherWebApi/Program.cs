using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFeatureManagement(/*builder.Configuration.GetSection("FeatureFlags")*/)
    .AddFeatureFilter<PercentageFilter>()
    .AddFeatureFilter<TimeWindowFilter>()
    /*.AddFeatureFilter<TargetingFilter>()*/
    .AddFeatureFilter<MyCustomFilter>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var weatherService = new WeatherService();

app.MapGet("/weatherforecast", () => weatherService.Get())
    .AddEndpointFilter<WeatherForecastFeatureFilter>()
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();