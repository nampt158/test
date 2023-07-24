using System;
using System.Threading.Tasks;

namespace WebApplication.Domain
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly IForecastProvider _dataProvider;

        public ForecastRepository(IForecastProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        
        public async Task<WeatherForecast[]> GetDailyForecastsByCityAsync(string city)
        {
            var today = DateTime.Today;
            var forecasts = await _dataProvider
                .Forecasts
                .FromCityAsync(city);


            return forecasts;
        }
    }
}