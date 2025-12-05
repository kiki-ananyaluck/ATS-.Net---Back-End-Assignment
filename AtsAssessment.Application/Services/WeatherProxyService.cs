using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtsAssessment.Application.Interfaces;
using AtsAssessment.Domain.DTOs;
using System.Net.Http;
using System.Text.Json;
public class WeatherProxyService : IWeatherProxyService
{
    private readonly IHttpClientFactory _factory;
    private const string FixedUrl = "https://goweather.herokuapp.com/weather/London";

    public WeatherProxyService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<WeatherProxyResult> CallWeatherApiAsync()
    {
        var client = _factory.CreateClient();

        HttpResponseMessage responseMessage;

        try
        {
            responseMessage = await client.GetAsync(FixedUrl);
        }
        catch (Exception ex)
        {
            return new WeatherProxyResult(
                FixedUrl,
                "GET",
                new { error = "Failed to call external API", detail = ex.Message }
            );
        }

        string raw = await responseMessage.Content.ReadAsStringAsync();

        object? json;
        try
        {
            json = JsonSerializer.Deserialize<object>(raw);
        }
        catch
        {
            json = raw;
        }

        return new WeatherProxyResult(FixedUrl, "GET", json);
    }
}
