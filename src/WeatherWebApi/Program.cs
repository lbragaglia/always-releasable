var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var weatherService = new WeatherService();

var forecastEnabled = true;

app.MapGet("/weatherforecast", () => forecastEnabled
        ? Results.Ok(weatherService.Get())
        : Results.NotFound())
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();