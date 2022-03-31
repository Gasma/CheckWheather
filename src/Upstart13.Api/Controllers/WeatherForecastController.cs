using Microsoft.AspNetCore.Mvc;
using Upstart13.Application.Queries.WeatherForecast;

namespace Upstart13.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseApiController
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string street, [FromQuery] string city, [FromQuery] string state, [FromQuery] string zip)
        {
            return Ok(await Mediator.Send(new WeatherForecastQuery
            {
                Street = street,
                City = city,
                State = state,
                Zip = zip
            }));
        }
    }
}