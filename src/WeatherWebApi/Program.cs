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

app.MapGet("/weatherforecast", () => weatherService.Get())
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();
