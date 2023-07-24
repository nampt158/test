using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.Geocoding;
using WebApplication.Domain;

namespace WebApplication.Data.Forecast
{
    internal class CityQueryFactory
    {
        private readonly NoaaQuery _noaaQuery;
        private readonly NoaaGridQuery _noaaGridQuery;
        private readonly GeocodeQuery _geocodeQuery;

        public CityQueryFactory(
            NoaaQuery noaaQuery, 
            NoaaGridQuery noaaGridQuery, 
            GeocodeQuery geocodeQuery)
        {
            _noaaQuery = noaaQuery;
            _noaaGridQuery = noaaGridQuery;
            _geocodeQuery = geocodeQuery;
        }

        public IForecastProvider.ICityQuery GetCityQuery()
        {
            return new CityQuery(this);
        }
        
        private class CityQuery : IForecastProvider.ICityQuery
        {
            private readonly CityQueryFactory _factory;

            public CityQuery(CityQueryFactory factory)
            {
                _factory = factory;
            }

            public async Task<WeatherForecast[]> FromCityAsync(string name)
            {
                var coordinates = await _factory._geocodeQuery.QueryCityAsync(name);
                if (coordinates == null) return Array.Empty<WeatherForecast>();
                var (latitude, longitude) = coordinates.Value;

                var forecastUri = await _factory._noaaGridQuery.GetNoaaForecastQueryAsync(latitude, longitude);
                var forecasts = await _factory._noaaQuery.GetForecastsAsync(forecastUri);
                
                return forecasts.Select(x => new WeatherForecast(x.Date, x.Temperature, name)).ToArray();
            }
        }
    }
}