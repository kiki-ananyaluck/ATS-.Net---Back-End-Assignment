using AtsAssessment.Application.Interfaces;
using AtsAssessment.Application.Validators;
using AtsAssessment.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtsAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class WeatherProxyController : ControllerBase
    {
        private readonly IWeatherProxyService _service;

        public WeatherProxyController(IWeatherProxyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            var result = await _service.CallWeatherApiAsync();
            return Ok(result);
        }
    }
}
