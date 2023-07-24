using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Domain;

namespace WebApplication.Data.Forecast
{
    internal class NoaaQuery : QueryBase
    {
        public NoaaQuery(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public async Task<(DateTime Date, Celsius Temperature)[]> GetForecastsAsync(Uri forecastUri)
        {
            var responseString = await Client.GetStringAsync(forecastUri);
            var json = Deserialize<WeatherForecastResponse>(responseString);
            var periods = json?.Properties?.Periods;
            if (periods is null || periods.Length == 0)
            {
                return Array.Empty<(DateTime, Celsius)>();
            }

            return periods.Where(x => x.IsDaytime).Select(ToDomainObject).ToArray();
        }

        private static (DateTime, Celsius) ToDomainObject(Period period)
        {
            return (period.StartTime.Date, new Celsius(new Fahrenheit(period.Temperature)));
        }
    }
}