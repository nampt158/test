using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;

namespace WebApplication.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastRepository _repository;

        public WeatherForecastController(IForecastRepository repository)
        {
            _repository = repository;
        }
        
        [Route("{city}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get(string city)
        {
            var forecasts = (await _repository.GetDailyForecastsByCityAsync(city))
                .Select(x => new WeatherForecast(x.Date, x.Temperature));

            if (forecasts.Any())
            {
                return Ok(forecasts);
            }

            return NotFound();
        }
    }
}