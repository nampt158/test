using System.Threading.Tasks;

namespace WebApplication.Domain
{
    public interface IForecastProvider
    {
        ICityQuery Forecasts { get; }

        public interface ICityQuery
        {
            Task<WeatherForecast[]> FromCityAsync(string name);
        }
    }
}